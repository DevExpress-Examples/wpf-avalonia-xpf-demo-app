namespace DevExpress.AvaloniaXpfDemo.ChartControlModules;

public partial class OverlappedRangeBarTab : TabItemModule {
    public OverlappedRangeBarTab() {
        InitializeComponent();
    }
    protected override void OnSelected() {
        base.OnSelected();
        App.CommonRibbon.InitChartsRibbon(chart);
    }
}