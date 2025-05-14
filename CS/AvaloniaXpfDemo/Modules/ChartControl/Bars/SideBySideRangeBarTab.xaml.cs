namespace DevExpress.AvaloniaXpfDemo.ChartControlModules;

public partial class SideBySideRangeBarTab : TabItemModule {
    public SideBySideRangeBarTab() {
        InitializeComponent();
    }
    protected override void OnSelected() {
        base.OnSelected();
        App.CommonRibbon.InitChartsRibbon(chart);
    }
}