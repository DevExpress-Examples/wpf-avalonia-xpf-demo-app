using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime;
using DevExpress.AvaloniaXpfDemo.DemoShell;
using DevExpress.Xpf.Core;

namespace DevExpress.AvaloniaXpfDemo;

public partial class App : Application {
    public static string Title => "DevExpress Avalonia XPF Demo";
    public static new DemoShellWindow MainWindow { get => (DemoShellWindow)Current.MainWindow; }
    public static CommonRibbon CommonRibbon { get => (CommonRibbon)MainWindow.CommonArea!; }

    static App() {
        StartPGO();
#if XPF
        AvaloniaUI.Xpf.WinApiShim.WinApiShimSetup.AutoEnable(asm => {
            var name = asm.GetName().Name!.ToLowerInvariant();
            if(name.Contains("sqlite") || name.Contains("EntityFramework"))
                return true;
            return false;
        });
#endif
    }
    public App() {
        SetupCulture();
        CompatibilitySettings.UseLightweightThemes = true;
        ApplicationThemeHelper.ApplicationThemeName = LightweightTheme.Win11Light.Name;
    }
    protected override void OnStartup(StartupEventArgs e) {
        base.MainWindow = new DemoShellWindow() {
            Title = Title,
            Icon = DemoHelper.GetImage("demoicon.ico"),
            Modules = DemoModules.Groups,
            CommonArea = new CommonRibbon()
        };
        MainWindow.Show();
    }

    static void SetupCulture() {
        var culture = CultureInfo.GetCultureInfo("en-US");
        Thread.CurrentThread.CurrentCulture = culture;
        Thread.CurrentThread.CurrentUICulture = culture;
    }
    static void StartPGO() {
        if(!DemoRestrictions.MultiCoreJIT)
            return;
        var exeAssembly = Assembly.GetEntryAssembly();
        var name = exeAssembly!.GetName().Name;
        string dir = Path.GetDirectoryName(exeAssembly.Location)!;
        ProfileOptimization.SetProfileRoot(dir);
        ProfileOptimization.StartProfile($"startup.profile");
    }
}

