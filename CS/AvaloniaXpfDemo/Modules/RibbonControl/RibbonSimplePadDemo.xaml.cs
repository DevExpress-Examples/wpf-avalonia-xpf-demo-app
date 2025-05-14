using System.Windows.Documents;
using DevExpress.AvaloniaXpfDemo.DemoShell;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Ribbon;

namespace DevExpress.AvaloniaXpfDemo.RibbonControlModules;

public partial class RibbonSimplePadDemo : DemoModuleView {
    static RibbonSimplePadDemo() { GridControl.AllowInfiniteGridSize = true; }

    public RibbonSimplePadDemo() {
        InitializeComponent();
        App.CommonRibbon.Clear();
        richControl.Document.Blocks.Clear();
        richControl.Document.Blocks.Add(new Paragraph(new Run("Select the image below to show a contextual tab.")));
        richControl.Document.Blocks.Add(new Paragraph(new InlineUIContainer() { Child = new InlineImage(InlineImageViewModel.Create(DemoHelper.GetResourceUriString("Images/RibbonControl/Clipart/caCompClientEnabled.png"))) }));
    }
    protected override void OnModuleUnloading() {
        RibbonControl.CloseApplicationMenu();
    }
    protected override void OnModuleCompletelyLoaded() {
        richControl.SetFocus();
    }
}