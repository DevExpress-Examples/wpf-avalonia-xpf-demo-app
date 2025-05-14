namespace DevExpress.AvaloniaXpfDemo.ChartControlModules;

public partial class StackedBarTab : TabItemModule {
    public StackedBarTab() {
        InitializeComponent();
    }
    protected override void OnSelected() {
        base.OnSelected();
        App.CommonRibbon.InitChartsRibbon(chart);
    }
}
