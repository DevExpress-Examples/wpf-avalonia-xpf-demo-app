#nullable disable
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DevExpress.AvaloniaXpfDemo.DemoData;

public static class ImageSourceHelper {
    public static ImageSource GetImageSource(Uri uri) {
        if(uri == null) return null;
        try {
            return BitmapFrame.Create(uri);
        } catch {
            return null;
        }
    }
    public static ImageSource GetImageSource(Stream stream) {
        if(stream == null) return null;
        try {
            return BitmapFrame.Create(stream);
        } catch {
            return null;
        }
    }
}
