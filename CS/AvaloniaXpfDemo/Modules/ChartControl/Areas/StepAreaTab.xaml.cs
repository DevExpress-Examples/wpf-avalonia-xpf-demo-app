namespace DevExpress.AvaloniaXpfDemo.ChartControlModules;

public partial class StepAreaTab : TabItemModule {
    public StepAreaTab() {
        InitializeComponent();
    }
    protected override void OnSelected() {
        base.OnSelected();
        App.CommonRibbon.InitChartsRibbon(chart);
    }
}
