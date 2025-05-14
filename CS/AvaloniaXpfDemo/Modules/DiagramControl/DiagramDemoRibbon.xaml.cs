using DevExpress.Diagram.Core;
using DevExpress.Mvvm.UI.Interactivity;
using DevExpress.Mvvm.UI.Native;
using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Diagram;

namespace DevExpress.AvaloniaXpfDemo.DiagramControlModules;

public partial class DiagramDemoRibbon : Grid {
    public static readonly DependencyProperty DiagramControlProperty;
    public DiagramDesignerControl? DiagramControl { get { return (DiagramDesignerControl?)GetValue(DiagramControlProperty); } set { SetValue(DiagramControlProperty, value); } }

    static DiagramDemoRibbon() {
        DependencyPropertyRegistrator<DiagramDemoRibbon>.New()
            .Register<DiagramDesignerControl?>(nameof(DiagramControl), out DiagramControlProperty, null, x => x.OnDiagramControlChanged());
    }
    public DiagramDemoRibbon() {
        DataContext = this;
        InitializeComponent();
        Init();
    }
    void Init() {
        var controllerBehavior = Interaction.GetBehaviors(diagramRibbonControl).OfType<ControllerBehavior>().First();

        if(!DemoRestrictions.Diagram.PrintPreview)
            SetBarItemIsEnabled(DefaultBarItemNames.ShowPrintPreview, false);
        if(!DemoRestrictions.Diagram.Print)
            SetBarItemIsEnabled(DefaultBarItemNames.PrintMenu, false);
        if(!DemoRestrictions.Diagram.ExportToGif)
            SetBarItemIsEnabled(DefaultBarItemNames.ExportDiagramGIF, false);
        if(!DemoRestrictions.Diagram.ExportToPdf)
            SetBarItemIsEnabled(DefaultBarItemNames.ExportDiagramPDF, false);

        void SetBarItemIsEnabled(string name, bool value) {
            controllerBehavior.Actions.Add(new UpdateAction() {
                ElementName = name,
                Property = BarButtonItem.IsEnabledProperty,
                Value = value
            });
        }
    }
    void OnDiagramControlChanged() {
        DiagramDesignerControl.SetDiagram(this, DiagramControl);
    }
}
