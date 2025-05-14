using DevExpress.Xpf.Gantt;

namespace DevExpress.AvaloniaXpfDemo.GanttControlModules;

public partial class GanttDemoRibbon : Grid {
    public static readonly DependencyProperty ExportGanttProperty =
            DependencyProperty.Register("ExportGantt", typeof(GanttControl), typeof(GanttDemoRibbon), new PropertyMetadata(null));
    public GanttControl? ExportGantt { get { return (GanttControl?)GetValue(ExportGanttProperty); } set { SetValue(ExportGanttProperty, value); } }

    public GanttDemoRibbon() {
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
        exportToImage.IsEnabled = DemoRestrictions.PrintingAndExport.WYSIWYGExportImage;
    }
}
