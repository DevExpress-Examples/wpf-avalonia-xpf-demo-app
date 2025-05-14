using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using DevExpress.AvaloniaXpfDemo.DemoShell;
using DevExpress.Mvvm;

namespace DevExpress.AvaloniaXpfDemo.GanttControlModules;

public partial class StartupPlanDemo : DemoModuleView {
    public StartupPlanDemo() {
        InitializeComponent();
        App.CommonRibbon.InitGanttRibbon(gantt);
    }
}

public enum ContentDisplayMode {
    Resources,
    Name
}

public class StripLineTemplateSelector : DataTemplateSelector {
    public DataTemplate? StripLineTemplate { get; set; }
    public DataTemplate? WeeklyStripLineTemplate { get; set; }

    public override DataTemplate? SelectTemplate(object item, DependencyObject container) {
        if(item is GanttStripLine)
            return StripLineTemplate;
        if(item is WeeklyStripLine)
            return WeeklyStripLineTemplate;
        return base.SelectTemplate(item, container);
    }
}

public class DayOfWeekToDaysOfWeekConverter : MarkupExtension, IValueConverter {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        return Enum.Parse(typeof(DaysOfWeek), Enum.GetName((DayOfWeek)value)!);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
        throw new NotImplementedException();
    }

    public override object ProvideValue(IServiceProvider serviceProvider) {
        return this;
    }
}