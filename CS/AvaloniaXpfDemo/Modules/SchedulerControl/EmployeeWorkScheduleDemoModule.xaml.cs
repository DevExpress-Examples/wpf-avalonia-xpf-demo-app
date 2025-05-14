#nullable disable
using DevExpress.AvaloniaXpfDemo.DemoShell;
using DevExpress.Xpf.Scheduling.VisualData;
using System.Windows;
using System.Windows.Controls;

namespace DevExpress.AvaloniaXpfDemo.SchedulerControlModules;

public partial class EmployeeWorkScheduleDemo : DemoModuleView {
    public EmployeeWorkScheduleDemo() {
        InitializeComponent();
        App.CommonRibbon.InitSchedulerRibbon(scheduler);
        App.CommonRibbon.DataContext = DataContext;
    }
}

public class TimeRegionTemplateSelector : DataTemplateSelector {
    public DataTemplate DinnerTemplate { get; set; }
    public object DinnerId { get; set; }

    public override DataTemplate SelectTemplate(object item, DependencyObject container) {
        var vm = (TimeRegionViewModel)item;
        return vm.TimeRegion.Id == DinnerId ? DinnerTemplate : null;
    }
}