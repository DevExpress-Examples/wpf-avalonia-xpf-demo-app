namespace DevExpress.AvaloniaXpfDemo.ChartControlModules;

public partial class FunnelTab : TabItemModule {
    public FunnelTab() {
        InitializeComponent();
    }
    protected override void OnSelected() {
        base.OnSelected();
        App.CommonRibbon.InitChartsRibbon(chart);
    }
}
