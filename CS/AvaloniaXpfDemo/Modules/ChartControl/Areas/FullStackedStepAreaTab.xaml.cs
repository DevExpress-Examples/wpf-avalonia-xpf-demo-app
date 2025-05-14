namespace DevExpress.AvaloniaXpfDemo.ChartControlModules;

public partial class FullStackedStepAreaTab : TabItemModule {
    public FullStackedStepAreaTab() {
        InitializeComponent();
    }
    protected override void OnSelected() {
        base.OnSelected();
        App.CommonRibbon.InitChartsRibbon(chart);
    }
}
