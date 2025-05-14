using DevExpress.AvaloniaXpfDemo.DemoShell;

namespace DevExpress.AvaloniaXpfDemo.ToolbarsModules;

public partial class SimplePadDemo : DemoModuleView {
    public SimplePadDemo() {
        InitializeComponent();
        App.CommonRibbon.Clear();
    }
    protected override void OnModuleCompletelyLoaded() {
        base.OnModuleCompletelyLoaded();
        richControl.SetFocus();
    }
}