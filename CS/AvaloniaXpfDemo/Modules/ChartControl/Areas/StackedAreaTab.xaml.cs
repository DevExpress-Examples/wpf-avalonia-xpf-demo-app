namespace DevExpress.AvaloniaXpfDemo.ChartControlModules;

public partial class StackedAreaTab : TabItemModule {
    public StackedAreaTab() {
        InitializeComponent();
    }
    protected override void OnSelected() {
        base.OnSelected();
        App.CommonRibbon.InitChartsRibbon(chart);
    }
}
