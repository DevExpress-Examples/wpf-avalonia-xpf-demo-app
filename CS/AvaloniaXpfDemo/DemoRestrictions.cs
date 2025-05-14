using DevExpress.Xpf.Docking;

namespace DevExpress.AvaloniaXpfDemo;

public static class DemoRestrictions {
    public enum OSType { WindowsWPF, WindowsXPF, Linux, MacOS }
    public static OSType OS { get => os ??= GetOSType(); }

    public static bool IsWindows { get => OS == OSType.WindowsWPF || OS == OSType.WindowsXPF; }

    public static bool MultiCoreJIT => GetValue(true, true, true, false);
    public static bool SplashScreen => GetValue(true, false, false, false);

    public static class Docking {
        public static FloatingMode FloatingMode => GetValue(FloatingMode.Desktop, FloatingMode.Desktop, FloatingMode.Window, FloatingMode.Window);
    }
    public static class PrintingAndExport {
        public static bool PrintPreview => GetValue(true, false, false, false);

        public static bool DataAwareExport =>
            DataAwareExportToXlsx | DataAwareExportToXls | DataAwareExportToCsv;
        public static bool DataAwareExportToXlsx => GetValue(true, true, true, true);
        public static bool DataAwareExportToXls => GetValue(true, true, true, true);
        public static bool DataAwareExportToCsv => GetValue(true, true, true, true);

        public static bool WYSIWYGExport =>
            WYSIWYGExportPdf | WYSIWYGExportHtml | WYSIWYGExportMht
            | WYSIWYGExportRtf | WYSIWYGExportXlsx | WYSIWYGExportXls
            | WYSIWYGExportTxt | WYSIWYGExportImage | WYSIWYGExportDocx;
        public static bool WYSIWYGExportPdf => GetValue(true, false, false, false);
        public static bool WYSIWYGExportHtml => GetValue(true, false, false, false);
        public static bool WYSIWYGExportMht => GetValue(true, false, false, false);
        public static bool WYSIWYGExportRtf => GetValue(true, false, false, false);
        public static bool WYSIWYGExportXlsx => GetValue(true, false, false, false);
        public static bool WYSIWYGExportXls => GetValue(true, false, false, false);
        public static bool WYSIWYGExportTxt => GetValue(true, false, false, false);
        public static bool WYSIWYGExportImage => GetValue(true, false, false, false);
        public static bool WYSIWYGExportDocx => GetValue(true, false, false, false);
    }
    public static class Diagram {
        public static bool PrintPreview => GetValue(true, false, false, false);
        public static bool Print => GetValue(true, false, true, false);
        public static bool ExportToGif => GetValue(true, false, false, false);
        public static bool ExportToPdf => GetValue(true, false, false, false);
    }
    public static class Charts {
        public static bool Export => GetValue(true, false, false, false);
    }
    public static class Scheduler {
        public static bool Print => GetValue(true, false, /*test*/false, /*test*/false);
    }


    static T GetValue<T>(T windowsWPF, T windowsXPF, T linux, T macOS) {
        switch(OS) {
            case OSType.WindowsWPF: return windowsWPF;
            case OSType.WindowsXPF: return windowsXPF;
            case OSType.Linux: return linux;
            case OSType.MacOS: return macOS;
            default: throw new NotSupportedException();
        }
    }
    static OSType GetOSType() {
#if !XPF
        return OSType.WindowsWPF;
#else
        if(OperatingSystem.IsWindows())
            return OSType.WindowsXPF;
        else if(OperatingSystem.IsLinux())
            return OSType.Linux;
        else if(OperatingSystem.IsMacOS())
            return OSType.MacOS;
        throw new NotSupportedException();
#endif
    }
    static OSType? os;
}