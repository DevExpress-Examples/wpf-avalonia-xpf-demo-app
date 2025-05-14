using DevExpress.Xpf.Grid;

namespace DevExpress.AvaloniaXpfDemo.DataGridModules;

public partial class GridDemoRibbon : Grid {
    public static readonly DependencyProperty ExportGridProperty =
            DependencyProperty.Register(nameof(ExportGrid), typeof(GridControl), typeof(GridDemoRibbon),
                new PropertyMetadata(null, (x, e) => ((GridDemoRibbon)x).OnExportGridChanged()));
    public GridControl? ExportGrid { get { return (GridControl?)GetValue(ExportGridProperty); } set { SetValue(ExportGridProperty, value); } }

    public GridDemoRibbon() {
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

        UpdatePrintAndExportVisibility();
    }
    void OnExportGridChanged() {
        UpdateDataAwareExport();
    }
    void UpdateDataAwareExport() {
        dataAwareExport.IsVisible =
            ExportGrid?.View != null
            && ExportGrid.View is not CardView;
        UpdatePrintAndExportVisibility();
    }
    private void UpdatePrintAndExportVisibility() {
        printAndExportGroup.IsVisible = printPreview.IsVisible ||
                                        dataAwareExport.IsVisible ||
                                        WYSIWYGExport.IsVisible;
    }
}
