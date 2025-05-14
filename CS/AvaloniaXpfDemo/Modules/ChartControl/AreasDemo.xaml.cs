using DevExpress.AvaloniaXpfDemo.DemoShell;

namespace DevExpress.AvaloniaXpfDemo.ChartControlModules;

public partial class AreasDemo : DemoModuleView {
    public AreasDemo() {
        InitializeComponent();
        App.CommonRibbon.Clear();
    }
    protected override void OnModuleCompletelyLoaded() {
        areaTab.Animate();
    }
}