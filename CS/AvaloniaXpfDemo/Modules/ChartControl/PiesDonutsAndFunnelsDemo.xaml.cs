using DevExpress.AvaloniaXpfDemo.DemoShell;

namespace DevExpress.AvaloniaXpfDemo.ChartControlModules;

public partial class PiesDonutsAndFunnelsDemo : DemoModuleView {
    public PiesDonutsAndFunnelsDemo() {
        InitializeComponent();
        App.CommonRibbon.Clear();
    }
    protected override void OnModuleCompletelyLoaded() {
        pieTab.Animate();
    }
}