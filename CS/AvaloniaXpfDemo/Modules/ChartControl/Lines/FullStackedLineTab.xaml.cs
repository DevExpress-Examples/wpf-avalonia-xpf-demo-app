namespace DevExpress.AvaloniaXpfDemo.ChartControlModules;

public partial class FullStackedLineTab : TabItemModule {
    public FullStackedLineTab() {
        InitializeComponent();
    }
    protected override void OnSelected() {
        base.OnSelected();
        App.CommonRibbon.InitChartsRibbon(chart);
    }
}
