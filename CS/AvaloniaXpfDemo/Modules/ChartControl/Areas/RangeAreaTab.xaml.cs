namespace DevExpress.AvaloniaXpfDemo.ChartControlModules;

public partial class RangeAreaTab : TabItemModule {
    public RangeAreaTab() {
        InitializeComponent();
    }
    protected override void OnSelected() {
        base.OnSelected();
        App.CommonRibbon.InitChartsRibbon(chart);
    }
}
