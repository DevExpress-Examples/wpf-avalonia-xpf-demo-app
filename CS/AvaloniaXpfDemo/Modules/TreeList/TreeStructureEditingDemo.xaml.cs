using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using DevExpress.AvaloniaXpfDemo.DemoShell;
using DevExpress.Xpf.Core;

namespace DevExpress.AvaloniaXpfDemo.TreeListModules;

public partial class TreeStructureEditingDemo : DemoModuleView {
    public TreeStructureEditingDemo() {
        InitializeComponent();
        App.CommonRibbon.InitTreeListRibbon(treeList);
    }
}

public class PriorityIconConverter : IValueConverter {
    static List<ImageSource> PriorityImages;
    static PriorityIconConverter() {
        PriorityImages = [
            ImageHelper.GetSvgImage("Flag_Yellow"),
            ImageHelper.GetSvgImage("Flag_Red")
        ];
    }
    public object? Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        int status = (int)value;
        if(status < 0)
            return null;
        return PriorityImages[status];
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
        throw new NotImplementedException();
    }
}
public static class ImageHelper {
    public static ImageSource GetSvgImage(string imageName) {
        var extension = new SvgImageSourceExtension() { Uri = DemoHelper.GetResourceUri($"Images/TreeList/{imageName}.svg"), Size = new Size(16, 16) };
        return (ImageSource)extension.ProvideValue(null);
    }
}