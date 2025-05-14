using System.Windows.Input;
using System.Windows.Media.Animation;
using DevExpress.Mvvm.UI.Interactivity;
using DevExpress.Xpf.Charts;

namespace DevExpress.AvaloniaXpfDemo.ChartControlModules;

public partial class PieTab : TabItemModule {
    public PieTab() {
        InitializeComponent();
    }
    public void Animate() {
        chart.Animate();
    }
    protected override void OnSelected() {
        base.OnSelected();
        App.CommonRibbon.InitChartsRibbon(chart);
    }

    void chart_QueryChartCursor(object sender, QueryChartCursorEventArgs e) {
        ChartHitInfo hitInfo = this.chart.CalcHitInfo(e.Position);
        if(hitInfo != null && hitInfo.SeriesPoint != null)
            e.Cursor = Cursors.Hand;
    }
    bool isAnimationCompleted = false;
    public override bool IsAnimationCompleted {
        get {
            return isAnimationCompleted;
        }
    }
    private void Storyboard_Completed(object sender, EventArgs e) {
        isAnimationCompleted = true;
    }
}

public class PieChartRotationBehavior : Behavior<ChartControl> {
    ChartControl Chart { get { return AssociatedObject; } }
    PieSeries2D Series { get { return (PieSeries2D)Chart.Diagram.Series[0]; } }
    bool rotate;
    Point startPosition;

    protected override void OnAttached() {
        base.OnAttached();
        Chart.MouseDown += Chart_MouseDown;
        Chart.MouseMove += Chart_MouseMove;
        Chart.MouseUp += Chart_MouseUp;
    }

    void Chart_MouseDown(object sender, MouseButtonEventArgs e) {
        Point position = e.GetPosition(Chart);
        ChartHitInfo hitInfo = Chart.CalcHitInfo(position);
        if(hitInfo != null && hitInfo.SeriesPoint != null) {
            this.rotate = true;
            this.startPosition = position;
        }
    }
    void Chart_MouseMove(object sender, MouseEventArgs e) {
        var position = e.GetPosition(Chart);
        var hitInfo = Chart.CalcHitInfo(position);
        if(hitInfo != null && this.rotate) {
            var angleDelta = CalcAngle(this.startPosition, position);
            angleDelta *= Series.SweepDirection == PieSweepDirection.Clockwise ? -1.0 : 1.0;
            var newAngle = Series.Rotation + angleDelta;
            if(Math.Abs(newAngle) > 360)
                newAngle += -720 * Math.Sign(newAngle);
            Series.Rotation = newAngle;
            this.startPosition = position;
        }
    }
    void Chart_MouseUp(object sender, MouseButtonEventArgs e) {
        this.rotate = false;
    }
    double CalcAngle(Point p1, Point p2) {
        var center = new Point(Chart.Diagram.ActualWidth / 2, Chart.ActualHeight / 2);
        Vector startVector = p1 - center;
        Vector endVector = p2 - center;
        return Vector.AngleBetween(endVector, startVector);
    }
}
public class PieChartSelectionBehavior : Behavior<ChartControl> {
    public static readonly DependencyProperty ExpandAnimationProperty =
        DependencyProperty.Register("ExpandAnimation", typeof(DoubleAnimation), typeof(PieChartSelectionBehavior), new PropertyMetadata(null));
    public static readonly DependencyProperty CollapseAnimationProperty =
        DependencyProperty.Register("CollapseAnimation", typeof(DoubleAnimation), typeof(PieChartSelectionBehavior), new PropertyMetadata(null));

    const int clickDelta = 200;

    DateTime mouseDownTime;

    ChartControl Chart { get { return AssociatedObject; } }

    public DoubleAnimation ExpandAnimation {
        get { return (DoubleAnimation)GetValue(ExpandAnimationProperty); }
        set { SetValue(ExpandAnimationProperty, value); }
    }
    public DoubleAnimation CollapseAnimation {
        get { return (DoubleAnimation)GetValue(CollapseAnimationProperty); }
        set { SetValue(CollapseAnimationProperty, value); }
    }

    void Chart_MouseDown(object sender, MouseButtonEventArgs e) {
        this.mouseDownTime = DateTime.Now;
    }
    void Chart_MouseUp(object sender, MouseButtonEventArgs e) {
        ChartHitInfo hitInfo = Chart.CalcHitInfo(e.GetPosition(Chart));
        if(hitInfo == null || hitInfo.SeriesPoint == null || !IsClick(DateTime.Now))
            return;
        double distance = PieSeries.GetExplodedDistance(hitInfo.SeriesPoint);
        Storyboard storyBoard = new Storyboard();
        var animation = distance > 0 ? CollapseAnimation : ExpandAnimation;
        storyBoard.Children.Add(animation);
        Storyboard.SetTarget(animation, hitInfo.SeriesPoint);
        Storyboard.SetTargetProperty(animation, new PropertyPath(PieSeries.ExplodedDistanceProperty));
        storyBoard.Begin();
    }
    bool IsClick(DateTime mouseUpTime) {
        return (mouseUpTime - this.mouseDownTime).TotalMilliseconds < clickDelta;
    }

    protected override void OnAttached() {
        base.OnAttached();
        Chart.MouseDown += Chart_MouseDown;
        Chart.MouseUp += Chart_MouseUp;
    }
}