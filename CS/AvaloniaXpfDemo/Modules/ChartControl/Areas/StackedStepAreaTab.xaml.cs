namespace DevExpress.AvaloniaXpfDemo.ChartControlModules;

public partial class StackedStepAreaTab : TabItemModule {
    public StackedStepAreaTab() {
        InitializeComponent();
    }
    protected override void OnSelected() {
        base.OnSelected();
        App.CommonRibbon.InitChartsRibbon(chart);
    }
}
