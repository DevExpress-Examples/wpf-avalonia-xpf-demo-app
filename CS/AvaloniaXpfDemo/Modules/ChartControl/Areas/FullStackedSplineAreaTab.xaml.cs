namespace DevExpress.AvaloniaXpfDemo.ChartControlModules;

public partial class FullStackedSplineAreaTab : TabItemModule {
    public FullStackedSplineAreaTab() {
        InitializeComponent();
    }
    protected override void OnSelected() {
        base.OnSelected();
        App.CommonRibbon.InitChartsRibbon(chart);
    }
}
