#nullable disable
using System.Windows.Data;

namespace DevExpress.AvaloniaXpfDemo.RibbonControlModules;

public class EnumValueToImageSourceConverter : IValueConverter {
    public string Prefix { get; set; }
    public string Folder { get; set; }
    public string Suffix { get; set; }
    public Type EnumType { get; set; }

    public EnumValueToImageSourceConverter() {
        Prefix = Folder = Suffix = string.Empty;
    }

    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
        if(value == null)
            return DependencyProperty.UnsetValue;
        string fileName = string.Format("{0}/{1}{2}{3}", Folder, Prefix, Enum.GetName(EnumType, value), Suffix);
        return new Uri(DemoHelper.GetResourceUriString($@"Images/RibbonControl/{fileName}.png"), UriKind.Absolute);
    }
    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
        throw new NotImplementedException();
    }
}
public class TextMarkerStyleValueToImageSourceConverter : IValueConverter {
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
        if(value == null)
            return DependencyProperty.UnsetValue;
        string fileName = string.Format("Bullets-{0}-76x76", Enum.GetName(typeof(TextMarkerStyle), value));
        return new Uri(DemoHelper.GetResourceUriString($@"Images/RibbonControl/Icons/{fileName}.png"), UriKind.Absolute);
    }
    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
        throw new NotImplementedException();
    }
}