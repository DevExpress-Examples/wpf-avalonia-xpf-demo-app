namespace DevExpress.AvaloniaXpfDemo.ChartControlModules;

public partial class FullStackedAreaTab : TabItemModule {
    public FullStackedAreaTab() {
        InitializeComponent();
    }
    protected override void OnSelected() {
        base.OnSelected();
        App.CommonRibbon.InitChartsRibbon(chart);
    }
}