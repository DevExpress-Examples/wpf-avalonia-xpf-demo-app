namespace DevExpress.AvaloniaXpfDemo.ChartControlModules;

public partial class AreaTab : TabItemModule {
    public AreaTab() {
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
