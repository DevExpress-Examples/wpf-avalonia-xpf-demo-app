#nullable disable
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Scheduling;
using DevExpress.Xpf.Scheduling.iCalendar;
using Microsoft.Win32;

namespace DevExpress.AvaloniaXpfDemo.SchedulerControlModules;

public class EmployeeWorkScheduleDemoViewModel {
    public virtual DateTime Start { get; set; }
    public IEnumerable<WorkCalendar> Calendars { get { return WorkData.Calendars; } }
    public IEnumerable<WorkAppointment> Appointments { get { return WorkData.Appointments; } }

    public EmployeeWorkScheduleDemoViewModel() {
        Start = WorkData.TodayStart;
        Init();
    }
    void Init() {
        WorkData.Calendars.ToList()
            .ForEach(x => x.IsVisible = false);
        WorkData.CalendarsSupport.ToList()
            .ForEach(x => x.IsVisible = true);
    }

    public void OutlookImport(SchedulerControl scheduler) {
        OutlookExchange(scheduler, OutlookExchangeType.Import);
    }
    public void OutlookExport(SchedulerControl scheduler) {
        OutlookExchange(scheduler, OutlookExchangeType.Export);
    }
    public void iCalendarImport(SchedulerControl scheduler) {
        ICalendarImporter importer = new ICalendarImporter(scheduler);
        using(Stream stream = OpenRead("Calendar", "iCalendar files (*.ics)|*.ics")) {
            if(stream != null)
                importer.Import(stream);
        }
    }
    public void iCalendarExport(SchedulerControl scheduler) {
        ICalendarExporter exporter = new ICalendarExporter(scheduler);
        using(Stream stream = OpenWrite("Calendar", "iCalendar files (*.ics)|*.ics")) {
            if(stream != null) {
                exporter.Export(stream);
                stream.Flush();
            }
        }
    }
    void OutlookExchange(SchedulerControl scheduler, OutlookExchangeType exchangeType) {
        try {
            string[] outlookCalendarPaths = DevExpress.XtraScheduler.Outlook.OutlookExchangeHelper.GetOutlookCalendarPaths();
            if(outlookCalendarPaths == null || outlookCalendarPaths.Length == 0)
                return;

            OutlookExchangeOptionsWindow optionsWindow = new OutlookExchangeOptionsWindow();
            optionsWindow.DataContext = OutlookExchangeOptionsWindowViewModel.Create(scheduler, exchangeType, outlookCalendarPaths);
            optionsWindow.Owner = Window.GetWindow(scheduler);
            optionsWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            optionsWindow.ShowDialog();
        }
        catch {
            ThemedMessageBox.Show(
                "Import from MS Outlook",
                String.Format("Unable to {0}.\nCheck whether MS Outlook is installed.", "get the list of available calendars from Microsoft Outlook"),
                MessageBoxButton.OK,
                MessageBoxImage.Warning);
        }
    }
    Stream OpenRead(string fileName, string filter) {
        OpenFileDialog dialog = new OpenFileDialog() { FileName = fileName, Filter = filter, FilterIndex = 1 };
        if(dialog.ShowDialog() != true)
            return null;
        return dialog.OpenFile();
    }
    Stream OpenWrite(string fileName, string filter) {
        SaveFileDialog dialog = new SaveFileDialog() { FileName = fileName, Filter = filter, FilterIndex = 1 };
        if(dialog.ShowDialog() != true)
            return null;
        return dialog.OpenFile();
    }
}