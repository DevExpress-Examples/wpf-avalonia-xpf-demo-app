namespace DevExpress.AvaloniaXpfDemo.ChartControlModules;

public partial class StepLineTab : TabItemModule {
    public StepLineTab() {
        InitializeComponent();
    }
    protected override void OnSelected() {
        base.OnSelected();
        App.CommonRibbon.InitChartsRibbon(chart);
    }
}
