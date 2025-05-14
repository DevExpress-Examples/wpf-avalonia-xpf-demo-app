using DevExpress.AvaloniaXpfDemo.DemoShell;

namespace DevExpress.AvaloniaXpfDemo.PivotGridModules;

public partial class ExcelStyleFilteringDemo : DemoModuleView {
    public ExcelStyleFilteringDemo() {
        InitializeComponent();
        App.CommonRibbon.InitPivotRibbon(pivot);
        pivot.DataSource = VehiclesData.GetMDBData();
        pivot.CollapseAllColumns();
    }
}