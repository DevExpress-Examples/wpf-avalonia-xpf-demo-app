#nullable disable
using DevExpress.Charts.Designer;
using DevExpress.Charts.Native;
using DevExpress.Drawing;
using DevExpress.Mvvm;
using DevExpress.Xpf.Charts;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Native;

namespace DevExpress.AvaloniaXpfDemo.ChartControlModules;

public partial class ChartsDemoRibbon : Grid {
    ChartsDemoRibbonViewModel vm;
    public ChartsDemoRibbon() {
        vm = new ChartsDemoRibbonViewModel();
        DataContext = vm;
        InitializeComponent();
        export.IsEnabled = DemoRestrictions.Charts.Export;
    }
    public void Init(ChartControlBase chart, bool showPaletteButton, bool showRunChartDesignerButton) {
        vm.Chart = chart;
        vm.ShowPaletteButton = showPaletteButton;
        vm.ShowRunChartDesignerButton = showRunChartDesignerButton;
    }
    public void Clear() {
        vm.Chart = null;
    }

    public class ChartsDemoRibbonViewModel : ViewModelBase {
        const string sTR_DXChart = "Exported DXChart";
        ChartControlBase chart;
        bool showPaletteButton = true;
        bool showChartGroup = true;
        bool showRunChartDesignerButton = false;
        ISaveFileDialogService SaveFileDialogService { get { return GetService<ISaveFileDialogService>(); } }
        IMessageBoxService MessageBoxService { get { return GetService<IMessageBoxService>(ServiceSearchMode.PreferParents); } }

        public ChartControlBase Chart { get { return chart; } set { SetProperty(ref chart, value, nameof(Chart), SetChartGroupVisibility); } }

        public DelegateCommand RunChartDesignerCommand { get; private set; }
        public DelegateCommand ExportToImageCommand { get; private set; }
        public DelegateCommand ExportToXlsCommand { get; private set; }
        public DelegateCommand ExportToDocxCommand { get; private set; }
        public DelegateCommand ExportToXlsxCommand { get; private set; }
        public DelegateCommand ExportToMhtCommand { get; private set; }
        public DelegateCommand ExportToHtmlCommand { get; private set; }
        public DelegateCommand ExportToPdfCommand { get; private set; }
        public DelegateCommand ExportToRtfCommand { get; private set; }
        public DelegateCommand ExportToXpsCommand { get; private set; }

        public bool ShowPaletteButton { get { return this.showPaletteButton; } set { SetProperty(ref this.showPaletteButton, value, nameof(ShowPaletteButton), SetChartGroupVisibility); } }
        public bool ShowChartGroup { get { return this.showChartGroup; } set { SetProperty(ref this.showChartGroup, value, nameof(ShowChartGroup)); } }
        public bool ShowRunChartDesignerButton {
            get { return this.showRunChartDesignerButton; }
            set { SetProperty(ref this.showRunChartDesignerButton, value, nameof(ShowRunChartDesignerButton), SetChartGroupVisibility); }
        }
        public bool ShowExportButton { get { return true; } }

        public ChartsDemoRibbonViewModel() {
            RunChartDesignerCommand = new DelegateCommand(() => {
                ChartControl chartControl = Chart as ChartControl;
                if(chartControl == null) {
                    ChartDebug.WriteWarning("ChartDemoRibbon can't run the designer because the Chart is null or it is a 3D Chart Control.");
                    return;
                }
                ChartDesigner designer = new ChartDesigner(chartControl);
                Window window = Window.GetWindow(Chart);
                designer.Show(window);
            }, false);
            ExportToImageCommand = new DelegateCommand(() => {
                ChartControlBase chartControl = Chart;
                if(chartControl == null) {
                    ChartDebug.WriteWarning("ChartDemoRibbon can't be exported because the Chart is null.");
                    return;
                }
                SaveFileDialogService.DefaultFileName = sTR_DXChart;
                SaveFileDialogService.Filter = "BMP Image|*.BMP|Gif Image|*.GIF|JPEG Image|*.JPG|PNG Image|*.PNG|TIFF Image|*.TIFF";
                var dialogResult = SaveFileDialogService.ShowDialog();
                if(!dialogResult)
                    return;
                else {
                    ImageExportOptions options = new ImageExportOptions();
                    switch(SaveFileDialogService.FilterIndex) {
                        case 1:
                            options.Format = DXImageFormat.Bmp;
                            break;
                        case 2:
                            options.Format = DXImageFormat.Gif;
                            break;
                        case 3:
                            options.Format = DXImageFormat.Jpeg;
                            break;
                        case 4:
                            options.Format = DXImageFormat.Png;
                            break;
                        case 5:
                            options.Format = DXImageFormat.Tiff;
                            break;
                        default:
                            MessageBoxService.ShowMessage("The selected format is not supported.", "Error", MessageButton.OK, MessageIcon.Error);
                            return;
                    }
                    var fileName = SaveFileDialogService.GetFullFileName();
                    chartControl.ExportToImage(fileName, options);
                    AskAndOpenResultFile(fileName);

                }
            }, false);
            ExportToXlsxCommand = new DelegateCommand(() => {
                ChartControlBase chartControl = Chart;
                if(chartControl == null) {
                    ChartDebug.WriteWarning("ChartDemoRibbon can't be exported because the Chart is null.");
                    return;
                }
                SaveFileDialogService.DefaultFileName = sTR_DXChart;
                SaveFileDialogService.Filter = "XLSX Document|*.XLSX";
                var dialogResult = SaveFileDialogService.ShowDialog();
                if(!dialogResult)
                    return;
                else {
                    var fileName = SaveFileDialogService.GetFullFileName();
                    chartControl.ExportToXlsx(fileName);
                    AskAndOpenResultFile(fileName);

                }
            }, false);
            ExportToXlsCommand = new DelegateCommand(() => {
                ChartControlBase chartControl = Chart;
                if(chartControl == null) {
                    ChartDebug.WriteWarning("ChartDemoRibbon can't be exported because the Chart is null.");
                    return;
                }
                SaveFileDialogService.DefaultFileName = sTR_DXChart;
                SaveFileDialogService.Filter = "XLS Document|*.XLS";
                var dialogResult = SaveFileDialogService.ShowDialog();
                if(!dialogResult)
                    return;
                else {
                    var fileName = SaveFileDialogService.GetFullFileName();
                    chartControl.ExportToXls(fileName);
                    AskAndOpenResultFile(fileName);
                }
            }, false);
            ExportToDocxCommand = new DelegateCommand(() => {
                ChartControlBase chartControl = Chart;
                if(chartControl == null) {
                    ChartDebug.WriteWarning("ChartDemoRibbon can't be exported because the Chart is null.");
                    return;
                }
                SaveFileDialogService.DefaultFileName = sTR_DXChart;
                SaveFileDialogService.Filter = "DOCX Document|*.DOCX";
                var dialogResult = SaveFileDialogService.ShowDialog();
                if(!dialogResult)
                    return;
                else {
                    var fileName = SaveFileDialogService.GetFullFileName();
                    chartControl.ExportToDocx(fileName);
                    AskAndOpenResultFile(fileName);
                }

            }, false);
            ExportToMhtCommand = new DelegateCommand(() => {
                ChartControlBase chartControl = Chart;
                if(chartControl == null) {
                    ChartDebug.WriteWarning("ChartDemoRibbon can't be exported because the Chart is null.");
                    return;
                }
                SaveFileDialogService.DefaultFileName = sTR_DXChart;
                SaveFileDialogService.Filter = "MHT Document|*.MHT";
                var dialogResult = SaveFileDialogService.ShowDialog();
                if(!dialogResult)
                    return;
                else {
                    var fileName = SaveFileDialogService.GetFullFileName();
                    chartControl.ExportToMht(fileName);
                    AskAndOpenResultFile(fileName);
                }

            }, false);
            ExportToHtmlCommand = new DelegateCommand(() => {
                ChartControlBase chartControl = Chart;
                if(chartControl == null) {
                    ChartDebug.WriteWarning("ChartDemoRibbon can't be exported because the Chart is null.");
                    return;
                }
                SaveFileDialogService.DefaultFileName = sTR_DXChart;
                SaveFileDialogService.Filter = "HTML Document|*.HTML";
                var dialogResult = SaveFileDialogService.ShowDialog();
                if(!dialogResult)
                    return;
                else {
                    var fileName = SaveFileDialogService.GetFullFileName();
                    chartControl.ExportToHtml(fileName);
                    AskAndOpenResultFile(fileName);
                }
            }, false);
            ExportToPdfCommand = new DelegateCommand(() => {
                ChartControlBase chartControl = Chart;
                if(chartControl == null) {
                    ChartDebug.WriteWarning("ChartDemoRibbon can't be exported because the Chart is null.");
                    return;
                }
                SaveFileDialogService.DefaultFileName = sTR_DXChart;
                SaveFileDialogService.Filter = "PDF Document|*.PDF";
                var dialogResult = SaveFileDialogService.ShowDialog();
                if(!dialogResult)
                    return;
                else {
                    var fileName = SaveFileDialogService.GetFullFileName();
                    chartControl.ExportToPdf(fileName);
                    AskAndOpenResultFile(fileName);
                }
            }, false);
            ExportToRtfCommand = new DelegateCommand(() => {
                ChartControlBase chartControl = Chart;
                if(chartControl == null) {
                    ChartDebug.WriteWarning("ChartDemoRibbon can't be exported because the Chart is null.");
                    return;
                }
                SaveFileDialogService.DefaultFileName = sTR_DXChart;
                SaveFileDialogService.Filter = "RTF Document|*.RTF";
                var dialogResult = SaveFileDialogService.ShowDialog();
                if(!dialogResult)
                    return;
                else {
                    var fileName = SaveFileDialogService.GetFullFileName();
                    chartControl.ExportToRtf(fileName);
                    AskAndOpenResultFile(fileName);
                }
            }, false);
            ExportToXpsCommand = new DelegateCommand(() => {
                ChartControlBase chartControl = Chart;
                if(chartControl == null) {
                    ChartDebug.WriteWarning("ChartDemoRibbon can't be exported because the Chart is null.");
                    return;
                }
                SaveFileDialogService.DefaultFileName = sTR_DXChart;
                SaveFileDialogService.Filter = "XPS Document|*.XPS";
                var dialogResult = SaveFileDialogService.ShowDialog();
                if(!dialogResult)
                    return;
                else {
                    var fileName = SaveFileDialogService.GetFullFileName();
                    chartControl.ExportToXps(fileName);
                    AskAndOpenResultFile(fileName);
                }
            }, false);
        }

        private void AskAndOpenResultFile(string fileName) {
            if(MessageBoxService.ShowMessage("Do you want to open the result file?", string.Empty, MessageButton.YesNo, MessageIcon.Question) == MessageResult.Yes)
                ProcessLaunchHelper.StartConfirmed(fileName);
        }

        void SetChartGroupVisibility() {
            ShowChartGroup = Chart != null && (ShowPaletteButton || ShowRunChartDesignerButton || ShowExportButton);
        }
    }
}
