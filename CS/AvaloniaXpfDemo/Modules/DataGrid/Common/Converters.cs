#nullable disable
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;
using DevExpress.Xpf.Core;

namespace DevExpress.AvaloniaXpfDemo.DataGridModules;

public abstract class BaseValueConverter : MarkupExtension, IValueConverter {
    public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);
    public virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
        throw new NotImplementedException();
    }

    public sealed override object ProvideValue(IServiceProvider serviceProvider) {
        return this;
    }
}
public class BirthdayImageVisibilityConverterExtension : BaseValueConverter {
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        if(value == null || !(value is DateTime))
            return Visibility.Collapsed;
        DateTime birthDate = (DateTime)value;
        DateTime someDate = DateTime.Now.AddMonths(3);
        int someMonth = someDate.Month < 3 ? someDate.Month + 12 : someDate.Month;
        int birthMonth = birthDate.Month < 3 ? birthDate.Month + 12 : birthDate.Month;
        return (birthMonth >= DateTime.Now.Month && birthMonth <= someMonth && (birthDate.Month == DateTime.Now.Month ? birthDate.Day > DateTime.Now.Day : true)) ? Visibility.Visible : Visibility.Collapsed;
    }
}
public class GroupNameToImageConverterExtension : BaseValueConverter {
    public static List<string> images = new List<string> { "administration", "inventory", "manufacturing", "quality", "research", "sales" };
    public static string GetImagePathByGroupName(string groupName) {
        groupName = groupName.ToLowerInvariant();
        foreach(string item in images) {
            if(groupName.Contains(item)) {
                return DemoHelper.GetResourceUriString("Images/DataGrid/GroupName/" + item + ".svg");
            }
        }
        return groupName;
    }
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        if(value == null)
            return null;
        return GetImagePathByGroupName((string)value);
    }
}
public class CountToVisibilityConverter : IValueConverter {
    public bool Invert { get; set; }
    #region IValueConverter Members
    object IValueConverter.Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
        return ((int)value > 0) ^ Invert ? Visibility.Visible : Visibility.Collapsed;
    }
    object IValueConverter.ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
        throw new NotImplementedException();
    }
    #endregion
}

public class DemoHeaderImageExtension : MarkupExtension {
    readonly string imageName;

    public DemoHeaderImageExtension(string imageName) {
        this.imageName = imageName;
    }

    public override object ProvideValue(IServiceProvider serviceProvider) {
        var path = DemoHelper.GetResourceUriString("Images/DataGrid/HeaderImages/" + imageName.Replace(" ", String.Empty) + ".svg");
        var extension = new SvgImageSourceExtension() { Uri = new Uri(path), Size = new Size(16, 16) };
        return (ImageSource)extension.ProvideValue(null);
    }
}