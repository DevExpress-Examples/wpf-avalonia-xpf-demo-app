#nullable disable
using System.IO;
using System.Windows.Threading;
using DevExpress.Data.Utils;
using DevExpress.Mvvm;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.PivotGrid;
using DevExpress.Xpf.Printing;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Native;
using SaveFileDialog = Microsoft.Win32.SaveFileDialog;

namespace DevExpress.AvaloniaXpfDemo;

public static class DemoModuleWYSIWYGExportHelper {
    public static void DoExportToPdf(DataViewBase view) => DoExport(view, ExportFormat.Pdf);
    public static void DoExportToHtm(DataViewBase view) => DoExport(view, ExportFormat.Htm);
    public static void DoExportToMht(DataViewBase view) => DoExport(view, ExportFormat.Mht);
    public static void DoExportToRtf(DataViewBase view) => DoExport(view, ExportFormat.Rtf);
    public static void DoExportToXlsx(DataViewBase view) => DoExport(view, ExportFormat.Xlsx);
    public static void DoExportToXls(DataViewBase view) => DoExport(view, ExportFormat.Xls);
    public static void DoExportToTxt(DataViewBase view) => DoExport(view, ExportFormat.Txt);
    public static void DoExportToImage(DataViewBase view) => DoExport(view, ExportFormat.Image);
    public static void DoExportToDocx(DataViewBase view) => DoExport(view, ExportFormat.Docx);

    public static void DoExportToPdf(PivotGridControl view) => DoExport(view, ExportFormat.Pdf);
    public static void DoExportToHtm(PivotGridControl view) => DoExport(view, ExportFormat.Htm);
    public static void DoExportToMht(PivotGridControl view) => DoExport(view, ExportFormat.Mht);
    public static void DoExportToRtf(PivotGridControl view) => DoExport(view, ExportFormat.Rtf);
    public static void DoExportToXlsx(PivotGridControl view) => DoExport(view, ExportFormat.Xlsx);
    public static void DoExportToXls(PivotGridControl view) => DoExport(view, ExportFormat.Xls);
    public static void DoExportToTxt(PivotGridControl view) => DoExport(view, ExportFormat.Txt);
    public static void DoExportToImage(PivotGridControl view) => DoExport(view, ExportFormat.Image);
    public static void DoExportToDocx(PivotGridControl view) => DoExport(view, ExportFormat.Docx);

    public static void DoExport(DataViewBase view, ExportFormat format) {
        switch(format) {
            case ExportFormat.Xls:
                Export(view, link => new Action<Stream, XlsExportOptions>(link.ExportToXls));
                break;
            case ExportFormat.Xlsx:
                Export(view, link => new Action<Stream, XlsxExportOptions>(link.ExportToXlsx));
                break;
            case ExportFormat.Pdf:
                Export(view, link => new Action<Stream, PdfExportOptions>(link.ExportToPdf));
                break;
            case ExportFormat.Htm:
                Export(view, link => new Action<Stream, HtmlExportOptions>(link.ExportToHtml));
                break;
            case ExportFormat.Mht:
                Export(view, link => new Action<Stream, MhtExportOptions>(link.ExportToMht));
                break;
            case ExportFormat.Rtf:
                Export(view, link => new Action<Stream, RtfExportOptions>(link.ExportToRtf));
                break;
            case ExportFormat.Txt:
                Export(view, link => new Action<Stream, TextExportOptions>(link.ExportToText));
                break;
            case ExportFormat.Image:
                Export(view, link => new Action<Stream, ImageExportOptions>(link.ExportToImage));
                break;
            case ExportFormat.Xps:
                Export(view, link => new Action<Stream, XpsExportOptions>(link.ExportToXps));
                break;
            case ExportFormat.Docx:
                Export(view, link => new Action<Stream, DocxExportOptions>(link.ExportToDocx));
                break;
        }
    }
    public static void DoExport(PivotGridControl view, ExportFormat format) {
        switch(format) {
            case ExportFormat.Xls:
                Export(view, link => new Action<Stream, XlsExportOptions>(link.ExportToXls));
                break;
            case ExportFormat.Xlsx:
                Export(view, link => new Action<Stream, XlsxExportOptions>(link.ExportToXlsx));
                break;
            case ExportFormat.Pdf:
                Export(view, link => new Action<Stream, PdfExportOptions>(link.ExportToPdf));
                break;
            case ExportFormat.Htm:
                Export(view, link => new Action<Stream, HtmlExportOptions>(link.ExportToHtml));
                break;
            case ExportFormat.Mht:
                Export(view, link => new Action<Stream, MhtExportOptions>(link.ExportToMht));
                break;
            case ExportFormat.Rtf:
                Export(view, link => new Action<Stream, RtfExportOptions>(link.ExportToRtf));
                break;
            case ExportFormat.Txt:
                Export(view, link => new Action<Stream, TextExportOptions>(link.ExportToText));
                break;
            case ExportFormat.Image:
                Export(view, link => new Action<Stream, ImageExportOptions>(link.ExportToImage));
                break;
            case ExportFormat.Xps:
                Export(view, link => new Action<Stream, XpsExportOptions>(link.ExportToXps));
                break;
            case ExportFormat.Docx:
                Export(view, link => new Action<Stream, DocxExportOptions>(link.ExportToDocx));
                break;
        }
    }
    static void Export<T>(DataViewBase view, Func<PrintableControlLink, Action<Stream, T>> getExportToStreamMethod) where T : ExportOptionsBase, new() {
        var link = new PrintableControlLink(view);
        using(MemoryStream stream = new MemoryStream()) {
            ExportHelper.ExportCore(getExportToStreamMethod(link), stream);
        }
    }
    static void Export<T>(PivotGridControl view, Func<PrintableControlLink, Action<Stream, T>> getExportToStreamMethod) where T : ExportOptionsBase, new() {
        var link = new PrintableControlLink(view);
        using(MemoryStream stream = new MemoryStream()) {
            ExportHelper.ExportCore(getExportToStreamMethod(link), stream);
        }
    }
}
public static class DemoModuleExportHelper {
    public static void ExportToXlsx(DataViewBase view) {
        Export(new Action<Stream, XlsxExportOptionsEx>(view.ExportToXlsx));
    }
    public static void ExportToXls(DataViewBase view) {
        Export(new Action<Stream, XlsExportOptionsEx>(view.ExportToXls));
    }
    public static void ExportToCsv(DataViewBase view) {
        Export(new Action<Stream, CsvExportOptionsEx>(view.ExportToCsv));
    }
    public static void ExportToXlsx(PivotGridControl view) {
        Export(new Action<Stream, XlsxExportOptionsEx>(view.ExportToXlsx));
    }
    public static void ExportToXls(PivotGridControl view) {
        Export(new Action<Stream, XlsExportOptionsEx>(view.ExportToXls));
    }
    public static void ExportToCsv(PivotGridControl view) {
        Export(new Action<Stream, CsvExportOptionsEx>(view.ExportToCsv));
    }

    static void Export<T>(Action<Stream, T> exportToStreamMethod) where T : ExportOptionsBase, new() {
        Dispatcher.CurrentDispatcher.BeginInvoke(new Action<Action<Stream, T>>(ExportCore), DispatcherPriority.ContextIdle, exportToStreamMethod);
    }
    static void ExportCore<T>(Action<Stream, T> exportToStreamMethod) where T : ExportOptionsBase, new() {
        using(MemoryStream stream = new MemoryStream()) {
            ExportHelper.ExportCore(exportToStreamMethod, stream);
        }
    }
}

static class ExportHelper {
    public static void ExportCore<T>(Action<Stream, T> exportToStream, Stream stream)
        where T : ExportOptionsBase, new() {
        if(stream == null)
            return;
        try {
            var options = new T();
            exportToStream(stream, options);
            stream.Seek(0, SeekOrigin.Begin);

            
            var extension = options.GetFileExtension();
            var file = SaveFile(stream, extension);
            if(string.IsNullOrEmpty(file))
                return;
            OpenFile(file);
        }
        catch(Exception e) {
            ThemedMessageBox.Show("Error", e.Message, MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
    static string SaveFile(Stream stream, string extension) {
        SaveFileDialog d = new SaveFileDialog() {
            Title = "Save As",
            DefaultExt = $".{extension}",
            Filter = $"(*.{extension})|*.{extension}|AllFiles (*.*)|*.*"
        };
        if(d.ShowDialog() != true)
            return null;
        var file = d.FileName;
        using(FileStream fileStream = new FileStream(file, FileMode.Create, FileAccess.Write))
            stream.CopyTo(fileStream);
        return d.FileName;
    }
    static void OpenFile(string file) {
        var openButton = new UICommand(MessageBoxResult.OK, "Open", null);
        var cancelButton = new UICommand(MessageBoxResult.Cancel, "Cancel", null);
        var res = ThemedMessageBox.Show(
            App.Title,
            $"File saved: {file}. Would you like to open it?",
            new[] { openButton, cancelButton });
        if(res == openButton) {
            SafeProcess.Start(file);
        }
    }
}