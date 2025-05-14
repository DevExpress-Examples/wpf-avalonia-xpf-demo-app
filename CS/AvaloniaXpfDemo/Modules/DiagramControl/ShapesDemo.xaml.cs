using DevExpress.AvaloniaXpfDemo.DemoShell;

namespace DevExpress.AvaloniaXpfDemo.DiagramControlModules;

public partial class ShapesDemo : DemoModuleView {
    public ShapesDemo() {
        InitializeComponent();
        App.CommonRibbon.InitDiagramRibbon(diagramControl);
        diagramControl.LoadDocument(DataProvider.GetShapesResourceStream());
    }
}
