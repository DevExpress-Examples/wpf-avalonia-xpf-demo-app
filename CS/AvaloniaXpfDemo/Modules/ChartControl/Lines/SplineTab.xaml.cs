namespace DevExpress.AvaloniaXpfDemo.ChartControlModules;

public partial class SplineTab : TabItemModule {
    public SplineTab() {
        InitializeComponent();
    }
    protected override void OnSelected() {
        base.OnSelected();
        App.CommonRibbon.InitChartsRibbon(chart);
    }
}