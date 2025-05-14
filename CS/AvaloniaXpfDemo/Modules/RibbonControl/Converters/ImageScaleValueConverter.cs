#nullable disable
using System.Globalization;
using System.Windows.Data;

namespace DevExpress.AvaloniaXpfDemo.RibbonControlModules;

public class ImageScaleValueConverter : IValueConverter {
    #region IValueConverter Members

    object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        return ((int)((double)value * 100)).ToString() + "%";
    }

    object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
        string val = value as string;
        return double.Parse(val.Substring(0, val.Length - 1)) / 100;
    }

    #endregion
}
