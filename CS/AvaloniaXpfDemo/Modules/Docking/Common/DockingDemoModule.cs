using DevExpress.AvaloniaXpfDemo.DemoShell;
using DevExpress.Data.Utils;
using DevExpress.Xpf;
using DevExpress.Xpf.Docking;

namespace DevExpress.AvaloniaXpfDemo.DockingModules {
    public class DockingDemoModule : DemoModuleView {
        public static readonly DependencyProperty ShouldRestoreOnActivateProperty = DependencyProperty.RegisterAttached("ShouldRestoreOnActivate", typeof(bool), typeof(DockingDemoModule));

        public DockingDemoModule() {
            Loaded += OnLoaded;
        }

        protected bool IsModuleLoaded { get; private set; }

        public static bool GetShouldRestoreOnActivate(DependencyObject target) {
            return (bool)target.GetValue(ShouldRestoreOnActivateProperty);
        }
        public static void SetShouldRestoreOnActivate(DependencyObject target, bool value) {
            target.SetValue(ShouldRestoreOnActivateProperty, value);
        }
        protected void NavigateHomePage() {
            var fileName = "http://www.devexpress.com";
            SafeProcess.Start(fileName, null, startInfo => { startInfo.UseShellExecute = true; });
        }
        protected virtual void OnLoaded(object sender, RoutedEventArgs e) {
            if(IsModuleLoaded) return;
            var containerList = DevExpress.Mvvm.UI.LayoutTreeHelper.GetVisualChildren(this).OfType<DockLayoutManager>();
            foreach(var container in containerList) {
                HideFloatGroups(container);
            }
        }
        protected void ShowAbout() {
            string platformName = "WPF";
            AboutToolInfo ati = new AboutToolInfo();
            ati.LicenseState = LicenseState.Licensed;
            ati.ProductEULAUri = "http://www.devexpress.com/";
            ati.ProductName = "DXDocking for " + platformName;
            ati.Version = AssemblyInfo.MarketingVersion;

            ToolAbout tAbout = new ToolAbout(ati);
            AboutWindow aWindow = new AboutWindow();
            aWindow.Content = tAbout;
            aWindow.ShowDialog();
        }
        void HideFloatGroups(DockLayoutManager dockLayoutManager) {
            if(dockLayoutManager.IsDisposing) return;
            foreach(FloatGroup floatGroup in dockLayoutManager.FloatGroups) {
                if(floatGroup.IsOpen) {
                    SetShouldRestoreOnActivate(floatGroup, true);
                    floatGroup.IsOpen = false;
                }
            }
        }
        void ShowFloatGroups(DockLayoutManager dockLayoutManager) {
            if(dockLayoutManager.IsDisposing) return;
            foreach(FloatGroup floatGroup in dockLayoutManager.FloatGroups) {
                if(GetShouldRestoreOnActivate(floatGroup)) {
                    SetShouldRestoreOnActivate(floatGroup, false);
                    if(!dockLayoutManager.IsVisible)
                        floatGroup.ShouldRestoreOnActivate = true;
                    else
                        floatGroup.IsOpen = true;
                }
            }
        }
    }
}