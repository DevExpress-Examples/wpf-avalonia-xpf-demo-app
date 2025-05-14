#nullable disable
using System;
using System.Windows;
using DevExpress.Mvvm.POCO;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Scheduling;
using DevExpress.Xpf.Scheduling.OutlookExchange;

namespace DevExpress.AvaloniaXpfDemo.SchedulerControlModules;

public enum OutlookExchangeType { Import, Export };
public class OutlookExchangeOptionsWindowViewModel {
    public static OutlookExchangeOptionsWindowViewModel Create(SchedulerControl scheduler, OutlookExchangeType type, string[] outlookCalendarPaths) {
        return ViewModelSource.Create(() => new OutlookExchangeOptionsWindowViewModel(scheduler, type, outlookCalendarPaths));
    }

    readonly SchedulerControl scheduler;
    readonly OutlookExchangeType type;

    protected OutlookExchangeOptionsWindowViewModel(SchedulerControl scheduler, OutlookExchangeType type, string[] outlookCalendarPaths) {
        this.scheduler = scheduler;
        this.type = type;
        OutlookCalendarPaths = outlookCalendarPaths;
        ProgressBarValue = 0;
        Title = type == OutlookExchangeType.Import ? "Outlook Import Options" : "Outlook Export Options";
        ActionCaption = type == OutlookExchangeType.Import ? "Cancel import for appointments:" : "Cancel export for appointments:";
    }

    public virtual string Title { get; set; }
    public virtual string ActionCaption { get; set; }
    public virtual string[] OutlookCalendarPaths { get; set; }
    public virtual string OutlookCalendarPath { get; set; }
    public virtual DevExpress.XtraScheduler.UsedAppointmentType UsedAppointmentType { get; set; }
    public virtual double MaxProgressBarValue { get; set; }
    public virtual double ProgressBarValue { get; set; }

    bool IsCancelForRecurring { get { return Object.Equals(UsedAppointmentType, DevExpress.XtraScheduler.UsedAppointmentType.Recurring); } }
    bool IsCancelForNonRecurring { get { return Object.Equals(UsedAppointmentType, DevExpress.XtraScheduler.UsedAppointmentType.NonRecurring); } }

    public void Exchange() {
        if(type == OutlookExchangeType.Import)
            Import();
        else
            Export();
    }

    void Import() {
        OutlookImporter importer = new OutlookImporter(scheduler);
        importer.CalendarFolderName = OutlookCalendarPath;
        importer.AppointmentItemSynchronizing += OnAppointmentItemSynchronizing;

        ProgressBarValue = 0;
        MaxProgressBarValue = importer.SourceObjectCount;

        try {
            importer.Import();
        }
        finally {
            ProgressBarValue = 0;
        }
    }
    void Export() {
        OutlookExporter exporter = new OutlookExporter(scheduler);
        exporter.CalendarFolderName = OutlookCalendarPath;
        exporter.AppointmentItemSynchronizing += OnAppointmentItemSynchronizing;

        ProgressBarValue = 0;
        MaxProgressBarValue = exporter.SourceObjectCount;

        try {
            exporter.Export();
        }
        finally {
            ProgressBarValue = 0;
        }
    }
    void OnAppointmentItemSynchronizing(object sender, AppointmentItemSynchronizingEventArgs args) {
        ProgressBarValue += 1;

        if(args.Appointment == null)
            return;

        bool cancel = args.Appointment.IsRecurring ? IsCancelForRecurring : IsCancelForNonRecurring;
        if(cancel)
            args.Cancel = true;
    }
}