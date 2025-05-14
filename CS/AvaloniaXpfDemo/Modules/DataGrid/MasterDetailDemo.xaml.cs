using DevExpress.Xpf.Grid;

namespace DevExpress.AvaloniaXpfDemo.DataGridModules;

public partial class MasterDetailDemo : GridDemoModule {
    protected override GridControl GridControl => grid;

    public MasterDetailDemo() {
        InitializeComponent();
        App.CommonRibbon.InitGridRibbon(grid);
    }
}
