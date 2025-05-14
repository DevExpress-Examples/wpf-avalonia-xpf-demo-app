using DevExpress.AvaloniaXpfDemo.DemoData;
using DevExpress.Xpf.Grid;

namespace DevExpress.AvaloniaXpfDemo.DataGridModules;

public partial class ExcelStyleFilteringDemo : GridDemoModule {
    protected override GridControl GridControl => grid;

    public ExcelStyleFilteringDemo() {
        InitializeComponent();
        App.CommonRibbon.InitGridRibbon(grid);
        grid.ItemsSource = OrderDataGenerator.GenerateVehicleOrders(10000);
    }
}
