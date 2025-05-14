using DevExpress.AvaloniaXpfDemo.DemoShell;
using DevExpress.Xpf.Grid;

namespace DevExpress.AvaloniaXpfDemo.DataGridModules;

public abstract class GridDemoModule : DemoModuleView {
    protected abstract GridControl GridControl { get; }

    protected override void OnModuleUnloading() {
        if(GridControl == null)
            return;
        GridControl.View.HideColumnChooser();
        GridControl.View.CommitEditing();
    }
}