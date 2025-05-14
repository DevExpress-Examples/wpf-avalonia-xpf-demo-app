#nullable disable
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace DevExpress.AvaloniaXpfDemo.MapControlModules;

public class ProviderNameToImageSourceConverter : IValueConverter {
    object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        if(value is ProviderName && targetType == typeof(ImageSource)) {
            switch((ProviderName)value) {
                case ProviderName.Azure:
                    return DemoHelper.GetResourceString("Images/MapControl/AzureMapLogo.png");
                case ProviderName.Bing:
                    return DemoHelper.GetResourceString("Images/MapControl/BingLogo.png");
                default:
                    return null;
            }
        }
        return null;
    }
    object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
        return null;
    }
}
public class ProviderNameToCopyrightTextConverter : IValueConverter {
    object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        if(value is ProviderName) {
            ProviderName providerName = (ProviderName)value;
            if(providerName == ProviderName.Azure || providerName == ProviderName.Bing)
                return "Copyright © " + DateTime.Now.Year + " Microsoft and its suppliers. All rights reserved.";
            if(providerName == ProviderName.Osm)
                return "© OpenStreetMap contributors";
            return null;
        }
        return null;
    }
    object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
        return null;
    }
}