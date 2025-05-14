#nullable disable
using DevExpress.AvaloniaXpfDemo.DemoData.Employees;
using DevExpress.AvaloniaXpfDemo.DemoShell;

namespace DevExpress.AvaloniaXpfDemo.AccordionControlModules;

public partial class DataBindingDemo : DemoModuleView {
    public DataBindingDemo() {
        InitializeComponent();
        App.CommonRibbon.Clear();
    }
}

public class EmployeeDetailsTemplateSelector : DataTemplateSelector {
    public DataTemplate EmployeeDetailsTemplate { get; set; }
    public DataTemplate EmptyDetailsTemplate { get; set; }

    public override DataTemplate SelectTemplate(object item, DependencyObject container) {
        if(item is Employee)
            return EmployeeDetailsTemplate;
        return EmptyDetailsTemplate;
    }
}