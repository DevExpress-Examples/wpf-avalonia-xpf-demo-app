using DevExpress.AvaloniaXpfDemo.DemoShell;

namespace DevExpress.AvaloniaXpfDemo.ChartControlModules;

public partial class LinesDemo : DemoModuleView {
    public LinesDemo() {
        InitializeComponent();
        App.CommonRibbon.Clear();
    }
    protected override void OnModuleCompletelyLoaded() {
        lineTab.Animate();
    }
}