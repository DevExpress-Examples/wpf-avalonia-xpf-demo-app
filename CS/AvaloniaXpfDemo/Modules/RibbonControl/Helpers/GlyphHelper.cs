#nullable disable
using DevExpress.Utils;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DevExpress.AvaloniaXpfDemo.RibbonControlModules;

public class GlyphHelper {
    public static ImageSource GetGlyph(string path) {
        if(path.EndsWith(".svg")) {
            return new DXImageExtension(path).ProvideValue(null) as ImageSource;
        }
        else {
            return new BitmapImage(AssemblyHelper.GetResourceUri(typeof(GlyphHelper).Assembly, path));
        }
    }
}
