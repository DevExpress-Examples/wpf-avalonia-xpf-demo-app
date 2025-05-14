using DevExpress.Xpf.PivotGrid;

namespace DevExpress.AvaloniaXpfDemo.PivotGridModules;

public partial class PivotGridDemoRibbon : Grid {
    public static readonly DependencyProperty ExportPivotGridProperty =
            DependencyProperty.Register("ExportPivotGrid", typeof(PivotGridControl), typeof(PivotGridDemoRibbon), new PropertyMetadata(null));
    public PivotGridControl? ExportPivotGrid { get { return (PivotGridControl?)GetValue(ExportPivotGridProperty); } set { SetValue(ExportPivotGridProperty, value); } }

    public PivotGridDemoRibbon() {
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
