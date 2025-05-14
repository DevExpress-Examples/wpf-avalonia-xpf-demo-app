using DevExpress.AvaloniaXpfDemo.DemoShell;

namespace DevExpress.AvaloniaXpfDemo.ChartControlModules;

public partial class BarsDemo : DemoModuleView {
    public BarsDemo() {
        InitializeComponent();
        App.CommonRibbon.Clear();
    }
    protected override void OnModuleCompletelyLoaded() {
        sideBySideBarTab.Animate();
    }
}