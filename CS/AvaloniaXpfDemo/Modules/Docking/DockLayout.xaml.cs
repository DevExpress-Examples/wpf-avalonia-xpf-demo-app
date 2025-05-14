namespace DevExpress.AvaloniaXpfDemo.DockingModules;

public partial class DockLayout : DockingDemoModule {
    public DockLayout() {
        InitializeComponent();
        App.CommonRibbon.Clear();
        DemoDockContainer.FloatingMode = DemoRestrictions.Docking.FloatingMode;
    }
}