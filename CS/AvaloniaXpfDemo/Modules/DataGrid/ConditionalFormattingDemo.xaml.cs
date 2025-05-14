using DevExpress.Xpf.Grid;

namespace DevExpress.AvaloniaXpfDemo.DataGridModules;

public partial class ConditionalFormattingDemo : GridDemoModule {
    protected override GridControl GridControl => grid;

    public ConditionalFormattingDemo() {
        InitializeComponent();
        App.CommonRibbon.InitGridRibbon(grid);
    }
}
