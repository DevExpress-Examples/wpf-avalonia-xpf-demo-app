using DevExpress.AvaloniaXpfDemo.DemoShell;

namespace DevExpress.AvaloniaXpfDemo.DataEditorsModules;

public partial class ContactDetailsDemo : DemoModuleView {
    public ContactDetailsDemo() {
        DataContext = new EmployeeViewModel();
        InitializeComponent();
        App.CommonRibbon.Clear();
    }
}
