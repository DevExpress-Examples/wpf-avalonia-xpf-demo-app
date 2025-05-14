namespace DevExpress.AvaloniaXpfDemo.ChartControlModules;

public partial class LineTab : TabItemModule {
    public LineTab() {
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
