namespace DevExpress.AvaloniaXpfDemo.ChartControlModules;

public partial class StackedLineTab : TabItemModule {
    public StackedLineTab() {
        InitializeComponent();
    }
    protected override void OnSelected() {
        base.OnSelected();
        App.CommonRibbon.InitChartsRibbon(chart);
    }
}
