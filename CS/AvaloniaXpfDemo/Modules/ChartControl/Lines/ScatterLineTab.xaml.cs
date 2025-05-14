namespace DevExpress.AvaloniaXpfDemo.ChartControlModules;

public partial class ScatterLineTab : TabItemModule {
    public ScatterLineTab() {
        InitializeComponent();
    }
    protected override void OnSelected() {
        base.OnSelected();
        App.CommonRibbon.InitChartsRibbon(chart);
    }
}