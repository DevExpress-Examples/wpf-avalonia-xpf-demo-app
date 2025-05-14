namespace DevExpress.AvaloniaXpfDemo.ChartControlModules;

public partial class FullStackedBarTab : TabItemModule {
    public FullStackedBarTab() {
        InitializeComponent();
    }
    protected override void OnSelected() {
        base.OnSelected();
        App.CommonRibbon.InitChartsRibbon(chart);
    }
}