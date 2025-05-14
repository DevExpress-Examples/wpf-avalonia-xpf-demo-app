#nullable disable
using DevExpress.Xpf.Charts;
using DevExpress.Xpf.Core;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace DevExpress.AvaloniaXpfDemo.ChartControlModules;

abstract class ForwardOnlyValueConverter : MarkupExtension, IValueConverter {
    public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
        return value;
    }

    public override object ProvideValue(IServiceProvider serviceProvider) {
        return this;
    }
}
class OptionsConverter : ForwardOnlyValueConverter {
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        if(value == null)
            return null;
        DXTabItem tabItem = (DXTabItem)value;
        TabItemModule tabModule = (TabItemModule)tabItem.Content;
        if(tabModule?.Options == null)
            return null;
        tabModule.Options.DataContext = tabModule.DataContext;
        return tabModule.Options;
    }
}
class Bar2DKindToTickmarksLengthConverter : ForwardOnlyValueConverter {
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        Bar2DKind bar2DKind = value as Bar2DKind;
        if(bar2DKind != null) {
            switch(bar2DKind.Name) {
                case "Glass Cylinder":
                    return 18;
                case "Quasi-3D Bar":
                    return 9;
            }
        }
        return 5;
    }
}
class MarkerSizeToLabelIndentConverter : ForwardOnlyValueConverter {
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        return ((double)value) / 2;
    }
}
class ShowTotalInToTitleVisibleConverter : ForwardOnlyValueConverter {
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        if(value == null || !(value is string))
            return value;
        string str = (string)value;
        return str == "Title";
    }
}
class ShowTotalInToPieTotalLabelVisibilityConverter : ForwardOnlyValueConverter {
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        if(value == null || !(value is string))
            return value;
        string str = (string)value;
        if(str == "Label")
            return Visibility.Visible;
        else
            return Visibility.Collapsed;
    }
}