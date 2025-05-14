#nullable disable

namespace DevExpress.AvaloniaXpfDemo.RibbonControlModules;

public static class StringHelper {
    public static string[] Split(string str, string separators) {           
        return str.Split(separators.ToCharArray());
    }
}