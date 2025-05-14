namespace DevExpress.AvaloniaXpfDemo.ChartControlModules;

public partial class SplineAreaTab : TabItemModule {
    public SplineAreaTab() {
        InitializeComponent();
    }
    protected override void OnSelected() {
        base.OnSelected();
        App.CommonRibbon.InitChartsRibbon(chart);
    }
}
