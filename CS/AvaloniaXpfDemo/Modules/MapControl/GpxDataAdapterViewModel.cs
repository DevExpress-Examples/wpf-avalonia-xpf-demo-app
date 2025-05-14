#nullable disable
using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.UI.Interactivity;
using DevExpress.Xpf.Charts;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Map;

namespace DevExpress.AvaloniaXpfDemo.MapControlModules;

[POCOViewModel]
public class GpxDataAdapterViewModel {
    MapDot highlightedPoint;

    public virtual MapItemStorage Storage { get; set; }
    public virtual DataTable Activities { get; set; }
    public virtual GpxTrackInfo Info { get; set; }
    public virtual Uri CurrentTrackUri { get; set; }
    public virtual DataRowView CurrentActivity { get; set; }
    public virtual bool IsMovingPointVisible { get; set; }
    public virtual GeoPoint MovingPointLocation { get; set; }

    public GpxDataAdapterViewModel() {
        FillActivities();
    }

    void PopulatePoints(MapPath track) {
        DataTemplate titleTemplate = XamlHelper.GetTemplate("<Grid> <TextBlock Text=\"{Binding Path=Text}\" Foreground=\"White\" HorizontalAlignment=\"Center\" VerticalAlignment=\"Center\"/> </Grid>");

        CoordPointCollection points = ((MapPolyLineSegment)((MapPathGeometry)track.Data).Figures[0].Segments[0]).Points;
        MapItemStorage storage = new MapItemStorage();
        this.highlightedPoint = new MapDot() { Visible = false, Size = 14 };
        this.highlightedPoint.Location = points.First();
        storage.Items.Add(this.highlightedPoint);
        storage.Items.Add(new MapDot() {
            Location = points.First(),
            Size = 20,
            TitleOptions = new ShapeTitleOptions() {
                Pattern = "A",
                VisibilityMode = VisibilityMode.Visible,
                Template = titleTemplate
            }
        });

        storage.Items.Add(new MapDot() {
            Location = points.Last(),
            Size = 20,
            TitleOptions = new ShapeTitleOptions() {
                Pattern = "B",
                VisibilityMode = VisibilityMode.Visible,
                Template = titleTemplate
            }
        });
        Storage = storage;
    }
    void FillActivities() {
        DataSet xmlDataSet = new DataSet("XML DataSet");
        xmlDataSet.ReadXml(Application.GetResourceStream(new Uri(CreateGpxDataPath("Activities.xml"), UriKind.Relative)).Stream);
        DataTable activities = xmlDataSet.Tables["Activity"];
        activities.Columns["Data"].ColumnMapping = MappingType.Hidden;
        Activities = activities;
        CurrentActivity = activities.DefaultView[0];
    }
    string CreateGpxDataPath(string fileName) {
        return DemoHelper.GetResourceString($"DBs/MapControl/{fileName}");
    }
    protected void OnIsMovingPointVisibleChanged() {
        this.highlightedPoint.Visible = IsMovingPointVisible;
    }
    protected void OnMovingPointLocationChanged() {
        if(MovingPointLocation != null)
            this.highlightedPoint.Location = MovingPointLocation;
    }
    protected void OnCurrentActivityChanged() {
        string path = string.Empty;
        if(CurrentActivity != null)
            path = CurrentActivity["Data"] as string;
        Uri uri = string.IsNullOrEmpty(path) ? null : new Uri(CreateGpxDataPath(path + ".gpx"), UriKind.RelativeOrAbsolute);
        CurrentTrackUri = uri;
    }
    public void OnShapesLoaded(object sender, ShapesLoadedEventArgs e) {
        PopulatePoints(e.Shapes.First() as MapPath);
        Info = TrackInfoCalculator.Calculate(sender as IListSource);
    }
}

public class GpxTrackInfo {
    public TimeSpan Duration { get; set; }
    public double Distance { get; set; }
    public int AverageHeartRate { get; set; }
    public int MinHeartRate { get; set; }
    public int MaxHeartRate { get; set; }
    public TimeSpan AveragePace { get; set; }
    public TimeSpan MaxPace { get; set; }
}

public static class TrackInfoCalculator {
    public static GpxTrackInfo Calculate(IListSource source) {
        GpxTrackInfo info = new GpxTrackInfo();
        DataView data = source.GetList() as DataView;
        if(data == null)
            return info;
        info.Duration = (DateTime)data[data.Count - 1]["time"] - (DateTime)data[0]["time"];
        info.Distance = ((double)data[data.Count - 1]["gpxdata:distance"] - (double)data[0]["gpxdata:distance"]);
        CalculatePace(data, info);
        CalculateHeartRate(data, info);
        info.Distance /= 1000;
        return info;
    }
    static void CalculateHeartRate(DataView data, GpxTrackInfo info) {
        string heartRate = "gpxtpx:hr";
        if(!data.Table.Columns.Contains(heartRate))
            return;
        int minHeartRate = Convert.ToInt32(data[0][heartRate]), maxHeartRate = minHeartRate, heartRateSum = 0;
        foreach(DataRowView row in data) {
            minHeartRate = Math.Min(minHeartRate, Convert.ToInt32(row[heartRate]));
            maxHeartRate = Math.Max(maxHeartRate, Convert.ToInt32(row[heartRate]));
            heartRateSum += Convert.ToInt32(row[heartRate]);
        }
        info.MinHeartRate = minHeartRate;
        info.MaxHeartRate = maxHeartRate;
        info.AverageHeartRate = (int)(heartRateSum / data.Count);
    }
    static void CalculatePace(DataView data, GpxTrackInfo info) {
        if(!data.Table.Columns.Contains("Pace"))
            data.Table.Columns.Add("Pace");
        string distance = "gpxdata:distance", time = "time";
        int window = 10;
        long minTicks = long.MaxValue;
        for(int i = 1; i < window; i++) {
            double d = (double)data[i][distance] - (double)data[i - 1][distance];
            TimeSpan pace = TimeSpan.FromMilliseconds(0);
            if(d > double.Epsilon) {
                TimeSpan dTime = (DateTime)data[i][time] - (DateTime)data[i - 1][time];
                pace = TimeSpan.FromMinutes(dTime.TotalMinutes / (d * 0.001));
                minTicks = Math.Min(minTicks, pace.Ticks);
            }
            data[i]["Pace"] = pace;
        }
        for(int j = window; j < data.Count; j++) {
            double d = (double)data[j][distance] - (double)data[j - window][distance];
            TimeSpan dTime = (DateTime)data[j][time] - (DateTime)data[j - window][time];
            TimeSpan pace = TimeSpan.FromMinutes(dTime.TotalMinutes / (d * 0.001));
            minTicks = Math.Min(minTicks, pace.Ticks);
            data[j]["Pace"] = pace;
        }
        info.AveragePace = TimeSpan.FromMinutes(info.Duration.TotalMinutes / (info.Distance * 0.001));
        info.MaxPace = TimeSpan.FromTicks(minTicks);
    }
}

public class MapCrosshairBehavior : Behavior<ChartControl> {
    public static readonly DependencyProperty IsMovingPointVisibleProperty = DependencyProperty.Register("IsMovingPointVisible", typeof(bool), typeof(MapCrosshairBehavior), new PropertyMetadata(false));
    public static readonly DependencyProperty MovingPointLocationProperty = DependencyProperty.Register("MovingPointLocation", typeof(GeoPoint), typeof(MapCrosshairBehavior), new PropertyMetadata(null));

    public bool IsMovingPointVisible {
        get { return (bool)GetValue(IsMovingPointVisibleProperty); }
        set { SetValue(IsMovingPointVisibleProperty, value); }
    }
    public GeoPoint MovingPointLocation {
        get { return (GeoPoint)GetValue(MovingPointLocationProperty); }
        set { SetValue(MovingPointLocationProperty, value); }
    }

    void OnCustomDrawCrosshair(object sender, CustomDrawCrosshairEventArgs e) {
        if(e.CrosshairElementGroups.Count > 0) {
            DataRowView sourceItem = (DataRowView)e.CrosshairElementGroups[0].CrosshairElements[0].SeriesPoint.Tag;
            MovingPointLocation = new GeoPoint((double)sourceItem["lat"], (double)sourceItem["lon"]);
        }
    }

    void OnMouseMove(object sender, System.Windows.Input.MouseEventArgs e) {
        IsMovingPointVisible = AssociatedObject.CalcHitInfo(e.GetPosition(AssociatedObject)).InDiagram;
    }

    protected override void OnAttached() {
        base.OnAttached();
        AssociatedObject.MouseMove += OnMouseMove;
        AssociatedObject.CustomDrawCrosshair += OnCustomDrawCrosshair;
    }

    protected override void OnDetaching() {
        AssociatedObject.MouseMove -= OnMouseMove;
        AssociatedObject.CustomDrawCrosshair -= OnCustomDrawCrosshair;
        base.OnDetaching();
    }
}