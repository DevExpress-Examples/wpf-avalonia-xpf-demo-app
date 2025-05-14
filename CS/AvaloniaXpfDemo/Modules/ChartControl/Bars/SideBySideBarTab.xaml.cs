namespace DevExpress.AvaloniaXpfDemo.ChartControlModules;

public partial class SideBySideBarTab : TabItemModule {
    public SideBySideBarTab() {
        InitializeComponent();
    }
    public void Animate() {
        chart.Animate();
    }
    protected override void OnSelected() {
        base.OnSelected();
        App.CommonRibbon.InitChartsRibbon(chart);
    }
}
