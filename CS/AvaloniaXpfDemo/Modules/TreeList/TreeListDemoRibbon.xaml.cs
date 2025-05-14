using DevExpress.Xpf.Grid;

namespace DevExpress.AvaloniaXpfDemo.TreeListModules;

public partial class TreeListDemoRibbon : Grid {
    public static readonly DependencyProperty ExportTreeListProperty =
            DependencyProperty.Register("ExportTreeList", typeof(TreeListControl), typeof(TreeListDemoRibbon),
                new PropertyMetadata(null));
    public TreeListControl? ExportTreeList { get { return (TreeListControl?)GetValue(ExportTreeListProperty); } set { SetValue(ExportTreeListProperty, value); } }

    public TreeListDemoRibbon() {
        DataContext = this;
        InitializeComponent();
        Init();
    }

    void Init() {
        printPreview.IsVisible = DemoRestrictions.PrintingAndExport.PrintPreview;

        dataAwareExport.IsEnabled = DemoRestrictions.PrintingAndExport.DataAwareExport;
        dataAwareExportToXlsx.IsEnabled = DemoRestrictions.PrintingAndExport.DataAwareExportToXlsx;
        dataAwareExportToXls.IsEnabled = DemoRestrictions.PrintingAndExport.DataAwareExportToXls;
        dataAwareExportToCsv.IsEnabled = DemoRestrictions.PrintingAndExport.DataAwareExportToCsv;

        WYSIWYGExport.IsVisible = DemoRestrictions.PrintingAndExport.WYSIWYGExport;
        exportToPDF.IsEnabled = DemoRestrictions.PrintingAndExport.WYSIWYGExportPdf;
        exportToHTML.IsEnabled = DemoRestrictions.PrintingAndExport.WYSIWYGExportHtml;
        exportToMHT.IsEnabled = DemoRestrictions.PrintingAndExport.WYSIWYGExportMht;
        exportToRTF.IsEnabled = DemoRestrictions.PrintingAndExport.WYSIWYGExportRtf;
        exportToXLSX.IsEnabled = DemoRestrictions.PrintingAndExport.WYSIWYGExportXlsx;
        exportToXLS.IsEnabled = DemoRestrictions.PrintingAndExport.WYSIWYGExportXls;
        exportToText.IsEnabled = DemoRestrictions.PrintingAndExport.WYSIWYGExportTxt;
        exportToImage.IsEnabled = DemoRestrictions.PrintingAndExport.WYSIWYGExportImage;
        exportToDOCX.IsEnabled = DemoRestrictions.PrintingAndExport.WYSIWYGExportDocx;
    }
}
