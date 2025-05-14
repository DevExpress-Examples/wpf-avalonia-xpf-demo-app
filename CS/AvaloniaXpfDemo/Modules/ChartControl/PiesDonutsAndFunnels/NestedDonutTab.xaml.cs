using DevExpress.Xpf.Charts;

namespace DevExpress.AvaloniaXpfDemo.ChartControlModules;

public partial class NestedDonutTab : TabItemModule {
    public NestedDonutTab() {
        InitializeComponent();
    }
    protected override void OnSelected() {
        base.OnSelected();
        App.CommonRibbon.InitChartsRibbon(chart);
    }

    void ChartControlBoundDataChanged(object sender, RoutedEventArgs e) {
        var seriesCollection = this.chart.Diagram.Series;
        if(seriesCollection.Count > 0) {
            foreach(NestedDonutSeries2D series in seriesCollection) {
                series.ShowInLegend = false;
                AgePopulation population = (AgePopulation)series.Points[0].Tag;
                if(population != null) series.Group = population.Name;
            }
            seriesCollection[0].ShowInLegend = true;
        }
    }
}