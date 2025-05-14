using System.Windows.Markup;
using System.Windows.Media;
using DevExpress.Xpf.Core;

namespace DevExpress.AvaloniaXpfDemo;

public static class DemoHelper {
    public static string GetResourceString(string localPath) {
        return $"/AvaloniaXpfDemo;component/{localPath}";
    }
    public static string GetResourceUriString(string localPath) {
        return $"pack://application:,,,{GetResourceString(localPath)}";
    }
    public static Uri GetResourceUri(string localPath) {
        return new Uri(GetResourceUriString(localPath));
    }

    public static ImageSource GetImage(string localPath, Size? size = null) {
        var uri = GetResourceUri(localPath);
        if(!localPath.EndsWith(".svg"))
            return (ImageSource)imageSourceConverter.ConvertFrom(uri)!;

        SvgImageSourceExtension imageSource = new SvgImageSourceExtension() {
            Uri = uri,
            Size = size
        };
        return (ImageSource)imageSource.ProvideValue(null);
    }
    public static ImageSource GetDXImage(string localPath, Size? size = null) {
        var uriStr = $"pack://application:,,,/DevExpress.Images.v{AssemblyInfo.VersionShort};component/{localPath}";
        var uri = new Uri(uriStr);
        SvgImageSourceExtension imageSource = new SvgImageSourceExtension() {
            Uri = uri,
            Size = size
        };
        return (ImageSource)imageSource.ProvideValue(null);
    }

    readonly static ImageSourceConverter imageSourceConverter = new();
}

public class DemoResourceUriExtension : MarkupExtension {
    public string LocalPath { get; }

    public DemoResourceUriExtension(string localPath) {
        LocalPath = localPath;
    }

    public override object ProvideValue(IServiceProvider serviceProvider) {
        var uri = DemoHelper.GetResourceUri(LocalPath);
        return uri;
    }
}
public class DXImageExtension : MarkupExtension {
    public string LocalPath { get; }
    public Size? Size { get; set; }

    public DXImageExtension(string localPath) {
        LocalPath = localPath;
    }
    public override object ProvideValue(IServiceProvider serviceProvider) {
        return DemoHelper.GetDXImage(LocalPath, Size);
    }
}
public class DemoImageExtension : MarkupExtension {
    public string LocalPath { get; }
    public Size? Size { get; set; }

    public DemoImageExtension(string localPath) {
        LocalPath = localPath;
    }
    public override object? ProvideValue(IServiceProvider serviceProvider) {
        return DemoHelper.GetImage(LocalPath, Size);
    }
}