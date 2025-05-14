namespace DevExpress.AvaloniaXpfDemo.ChartControlModules;

public partial class StackedSplineAreaTab : TabItemModule {
    public StackedSplineAreaTab() {
        InitializeComponent();
    }
    protected override void OnSelected() {
        base.OnSelected();
        App.CommonRibbon.InitChartsRibbon(chart);
    }
}
