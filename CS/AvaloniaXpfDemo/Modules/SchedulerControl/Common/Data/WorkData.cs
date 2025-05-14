#nullable disable
using DevExpress.Mvvm.Native;
using DevExpress.Xpf.Scheduling;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Native;
using DevExpress.XtraScheduler.Xml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DevExpress.Data.Utils;

namespace DevExpress.AvaloniaXpfDemo.SchedulerControlModules;

public class WorkCalendar {
    public long Id { get; set; }
    public string Name { get; set; }
    public bool IsVisible { get; set; }
    public string Group { get; set; }
    public object Tag { get; set; }
}
public class WorkAppointment {
    public long Id { get; set; }
    public int AppointmentType { get; set; }
    public bool AllDay { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }

    public string Subject { get; set; }
    public string Description { get; set; }
    public int Status { get; set; }
    public int Label { get; set; }
    public string Location { get; set; }
    public IEnumerable<long> CalendarIds { get; set; }
    public long CalendarId { set { CalendarIds = new long[] { value }; } }

    public string RecurrenceInfo { get; set; }
    public string ReminderInfo { get; set; }

    public string TimeZoneId { get; set; }
    public bool IsPrivate { get; set; }
}
public class WorkLabel {
    public int Id { get; set; }
    public string Caption { get; set; }
}
public static class WorkData {
    public static long CalendarConferenceRoomId { get { return CalendarConferenceRoom.Id; } }
    public static long CalendarTrainingRoomId { get { return CalendarTrainingRoom.Id; } }
    public static DateTime Start { get; private set; }
    public static DateTime TodayStart { get; private set; }
    public static ObservableCollection<WorkCalendar> Calendars { get; private set; }
    public static ObservableCollection<WorkCalendar> CalendarsEmployees { get; private set; }
    public static ObservableCollection<WorkCalendar> CalendarsSupport { get; private set; }
    public static ObservableCollection<WorkCalendar> CalendarsRD { get; private set; }
    public static ObservableCollection<WorkCalendar> CalendarsRooms { get; private set; }
    public static WorkCalendar CalendarMark { get; private set; }
    public static WorkCalendar CalendarNancy { get; private set; }
    public static WorkCalendar CalendarAndrew { get; private set; }
    public static WorkCalendar CalendarJanet { get; private set; }
    public static WorkCalendar CalendarMichael { get; private set; }
    public static WorkCalendar CalendarCarolyn { get; private set; }
    public static WorkCalendar CalendarAnthony { get; private set; }
    public static WorkCalendar CalendarFrancine { get; private set; }
    public static WorkCalendar CalendarAaron { get; private set; }
    public static WorkCalendar CalendarDailiah { get; private set; }
    public static WorkCalendar CalendarAnita { get; private set; }
    public static WorkCalendar CalendarConferenceRoom { get; private set; }
    public static WorkCalendar CalendarTrainingRoom { get; private set; }

    public static ObservableCollection<WorkAppointment> Appointments { get; private set; }

    static NonCryptographicRandom random;
    static WorkData() {
        random = NonCryptographicRandom.Default;
        Start = GetMonday(DateTime.Today);
        TodayStart = DateTime.Today.Date;
        Appointments = new ObservableCollection<WorkAppointment>();
        Calendars = new ObservableCollection<WorkCalendar>();
        CalendarsEmployees = new ObservableCollection<WorkCalendar>();
        CalendarsSupport = new ObservableCollection<WorkCalendar>();
        CalendarsRD = new ObservableCollection<WorkCalendar>();
        CalendarsRooms = new ObservableCollection<WorkCalendar>();
        InitCalendars();
        InitApts();
    }
    static void InitCalendars() {
        CalendarMark = new WorkCalendar() { Id = 0, Name = "Mark Oliver", Group = "Support Team" };
        CalendarNancy = new WorkCalendar() { Id = 1, Name = "Nancy Davolio", Group = "Support Team" };
        CalendarAndrew = new WorkCalendar() { Id = 2, Name = "Andrew Fuller", Group = "Support Team" };
        CalendarJanet = new WorkCalendar() { Id = 3, Name = "Janet Leverling", Group = "Support Team" };
        CalendarMichael = new WorkCalendar() { Id = 4, Name = "Michael Suyama", Group = "Support Team" };
        CalendarCarolyn = new WorkCalendar() { Id = 5, Name = "Carolyn Baker", Group = "R&D Team" };
        CalendarAnthony = new WorkCalendar() { Id = 6, Name = "Anthony Rounds", Group = "R&D Team" };
        CalendarFrancine = new WorkCalendar() { Id = 7, Name = "Francine Bing", Group = "R&D Team" };
        CalendarAaron = new WorkCalendar() { Id = 8, Name = "Aaron Borrmann", Group = "R&D Team" };
        CalendarDailiah = new WorkCalendar() { Id = 9, Name = "Dailiah Campbell", Group = "R&D Team" };
        CalendarAnita = new WorkCalendar() { Id = 10, Name = "Anita Andrews", Group = "R&D Team" };
        CalendarConferenceRoom = new WorkCalendar() { Id = 11, Name = "Conference Room", Group = "Rooms" };
        CalendarTrainingRoom = new WorkCalendar() { Id = 12, Name = "Training Room", Group = "Rooms" };

        CalendarsSupport.Add(CalendarMark);
        CalendarsSupport.Add(CalendarNancy);
        CalendarsSupport.Add(CalendarAndrew);
        CalendarsSupport.Add(CalendarJanet);
        CalendarsSupport.Add(CalendarMichael);
        CalendarsRD.Add(CalendarCarolyn);
        CalendarsRD.Add(CalendarAnthony);
        CalendarsRD.Add(CalendarFrancine);
        CalendarsRD.Add(CalendarAaron);
        CalendarsRD.Add(CalendarDailiah);
        CalendarsRD.Add(CalendarAnita);
        CalendarsRooms.Add(CalendarConferenceRoom);
        CalendarsRooms.Add(CalendarTrainingRoom);

        CalendarsSupport.ForEach(x => CalendarsEmployees.Add(x));
        CalendarsRD.ForEach(x => CalendarsEmployees.Add(x));
        CalendarsEmployees.ForEach(x => Calendars.Add(x));
        CalendarsRooms.ForEach(x => Calendars.Add(x));

    }
    static void InitApts() {
        AddSupportTeamApts();
        AddRDTeamApts();
        AddConferences();
        AddTrainings();
    }

    static void AddSupportTeamApts() {
        Appointments.Add(SecondShift(Start, CalendarAndrew.Id));
        Appointments.Add(SecondShift(Start.AddDays(7), CalendarJanet.Id));
        Appointments.Add(SecondShift(Start.AddDays(14), CalendarMichael.Id));
        Appointments.Add(SecondShift(Start.AddDays(21), CalendarNancy.Id));
        Appointments.Add(SecondShift(Start.AddDays(28), CalendarMark.Id));

        Appointments.Add(DayOff(Start, CalendarNancy.Id));
        Appointments.Add(DayOff(Start.AddDays(7).AddDays(3), CalendarAndrew.Id));
        Appointments.Add(DayOff(Start.AddDays(14).AddDays(4), CalendarJanet.Id));
        Appointments.Add(DayOff(Start.AddDays(14).AddDays(2), CalendarMark.Id));

        Appointments.Add(Vacation(Start.AddDays(21), CalendarMichael.Id));
        Appointments.Add(Vacation(Start.AddDays(42), CalendarJanet.Id));
        Appointments.Add(Vacation(Start.AddDays(49), CalendarMark.Id));
    }
    static void AddRDTeamApts() {
        Appointments.Add(DayOff(Start, CalendarCarolyn.Id));
        Appointments.Add(DayOff(Start.AddDays(7).AddDays(2), CalendarAnthony.Id));
        Appointments.Add(DayOff(Start.AddDays(14).AddDays(2), CalendarFrancine.Id));
        Appointments.Add(DayOff(Start.AddDays(14).AddDays(3), CalendarAaron.Id));
        Appointments.Add(DayOff(Start.AddDays(21).AddDays(3), CalendarDailiah.Id));
        Appointments.Add(DayOff(Start.AddDays(28).AddDays(4), CalendarAnita.Id));

        Appointments.Add(Vacation(Start, CalendarDailiah.Id));
        Appointments.Add(Vacation(Start.AddDays(28), CalendarCarolyn.Id));
        Appointments.Add(Vacation(Start.AddDays(63), CalendarAnthony.Id));
        Appointments.Add(Vacation(Start.AddDays(126), CalendarFrancine.Id));
        Appointments.Add(Vacation(Start.AddDays(105), CalendarAaron.Id));
    }
    static void AddConferences() {
        Appointments.Add(Conference1(Start.AddDays(1).AddHours(10), CalendarsEmployees.Select(x => x.Id).Concat(new[] { CalendarConferenceRoom.Id })));
        Appointments.Add(Conference2(Start.AddDays(2).AddHours(9), new[] { CalendarMark.Id, CalendarNancy.Id, CalendarJanet.Id, CalendarMichael.Id, CalendarConferenceRoom.Id }));
        Appointments.Add(Conference3(Start.AddDays(3).AddHours(9), CalendarsEmployees.Select(x => x.Id).Concat(new[] { CalendarConferenceRoom.Id })));
        Appointments.Add(Conference4(Start.AddDays(-14).AddDays(4).AddHours(17), CalendarsSupport.Select(x => x.Id).Concat(new[] { CalendarConferenceRoom.Id })));

        Appointments.Add(Conference5(Start.AddHours(9), CalendarsRD.Select(x => x.Id).Concat(new[] { CalendarConferenceRoom.Id })));
        Appointments.Add(Conference6(Start.AddDays(11).AddHours(15.5), CalendarsRD.Select(x => x.Id).Concat(new[] { CalendarConferenceRoom.Id })));
        Appointments.Add(Conference7(Start.AddDays(4).AddHours(12).AddMinutes(15), CalendarsRD.Select(x => x.Id).Concat(new[] { CalendarConferenceRoom.Id })));
    }
    static void AddTrainings() {
        Appointments.Add(TrainingFrenchLesson(Start.AddDays(-7).AddHours(11).AddMinutes(10), new[] { CalendarJanet.Id, CalendarMichael.Id, CalendarTrainingRoom.Id }));
        Appointments.Add(TrainingTrainStaffOnNewRemoteControls(Start.AddDays(3).AddHours(14).AddMinutes(10), new[] { CalendarMark.Id, CalendarNancy.Id, CalendarJanet.Id, CalendarTrainingRoom.Id }));
        var germanLessons = TrainingGermanLesson(Start.AddHours(15).AddMinutes(40), new[] { CalendarMark.Id, CalendarNancy.Id, CalendarAndrew.Id, CalendarTrainingRoom.Id });
        germanLessons.ForEach(x => Appointments.Add(x));
    }

    static WorkAppointment DayOff(DateTime start, long calendarId) {
        DateTime newStart = start;
        DateTime newEnd = newStart.AddDays(1);
        var appt = new WorkAppointment() {
            AppointmentType = (int)AppointmentType.Normal,
            AllDay = true,
            Start = newStart,
            End = newEnd,
            Subject = "Day off",
            CalendarId = calendarId,
        };
        return appt;
    }
    static WorkAppointment SecondShift(DateTime start, long calendarId) {
        DateTime newStart = start;
        DateTime newEnd = newStart.AddDays(5);
        var appt = new WorkAppointment() {
            AppointmentType = (int)AppointmentType.Normal,
            AllDay = true,
            Start = newStart,
            End = newEnd,
            Subject = "Second shift",
            CalendarId = calendarId,
        };
        return appt;
    }
    static WorkAppointment Vacation(DateTime start, long calendarId) {
        DateTime newStart = start;
        DateTime newEnd = newStart.AddDays(12);
        var appt = new WorkAppointment() {
            AppointmentType = (int)AppointmentType.Normal,
            AllDay = true,
            Start = newStart,
            End = newEnd,
            Subject = "Vacation",
            CalendarId = calendarId,
        };
        return appt;
    }

    static WorkAppointment Conference1(DateTime start, IEnumerable<long> calendarIds) {
        DateTime newStart = start;
        DateTime newEnd = newStart.AddHours(1);
        var appt = new WorkAppointment() {
            AppointmentType = (int)AppointmentType.Normal,
            Start = newStart,
            End = newEnd,
            Subject = "Company-wide meeting",
            Location = "Conference Room",
            Description = "Everyone must be ready to ask questions and inform leadership team why they are not performing as expected and what we need to do as a team to improve morale.",
            CalendarIds = calendarIds,
            Label = 1,
        };
        return appt;
    }
    static WorkAppointment Conference2(DateTime start, IEnumerable<long> calendarIds) {
        DateTime newStart = start;
        DateTime newEnd = newStart.AddHours(1);
        var appt = new WorkAppointment() {
            AppointmentType = (int)AppointmentType.Normal,
            Start = newStart,
            End = newEnd,
            Subject = "Customer retention review",
            Location = "Conference Room",
            Description = "Discuss ways in which we can improve our relationship with customers and prove to them that we are the long term source for all their A/V needs.",
            CalendarIds = calendarIds,
        };
        return appt;
    }
    static WorkAppointment Conference3(DateTime start, IEnumerable<long> calendarIds) {
        DateTime newStart = start;
        DateTime newEnd = newStart.AddHours(2);
        var appt = new WorkAppointment() {
            AppointmentType = (int)AppointmentType.Normal,
            Start = newStart,
            End = newEnd,
            Subject = "Final website design review",
            Location = "Conference Room",
            Description = "It's time to launch our new website. Management can no longer tolerate delays nor accept excuses. We've been waiting long enough for the overhaul.",
            CalendarIds = calendarIds,
            Label = 1,
        };
        return appt;
    }
    static WorkAppointment Conference4(DateTime start, IEnumerable<long> calendarIds) {
        DateTime newStart = start.AddMinutes(15);
        DateTime newEnd = newStart.AddMinutes(45);
        var appt = new WorkAppointment() {
            AppointmentType = (int)AppointmentType.Pattern,
            Start = newStart,
            End = newEnd,
            Subject = "Support Team - Weekly meeting",
            CalendarIds = calendarIds,
        };
        appt.RecurrenceInfo = RecurrenceBuilder.Weekly(newStart).ByDay(WeekDays.Friday).Build().ToXml();
        return appt;
    }
    static WorkAppointment Conference5(DateTime start, IEnumerable<long> calendarIds) {
        DateTime newStart = start;
        DateTime newEnd = newStart.AddHours(1);
        var appt = new WorkAppointment() {
            AppointmentType = (int)AppointmentType.Normal,
            Start = newStart,
            End = newEnd,
            Subject = "UL testing and certification",
            Description = "Discuss Underwriters Laboratories requirements. Review testing status, expected costs, and determine likelihood of certification.",
            Location = "Conference Room",
            CalendarIds = calendarIds,
        };
        return appt;
    }
    static WorkAppointment Conference6(DateTime start, IEnumerable<long> calendarIds) {
        DateTime newStart = start;
        DateTime newEnd = newStart.AddHours(1.5);
        var appt = new WorkAppointment() {
            AppointmentType = (int)AppointmentType.Normal,
            Start = newStart,
            End = newEnd,
            Subject = "OLED and 8K transition plans",
            Description = "Review final OLED schematics. Verify supply-chain requirements and finalize 8K specs for marketing.",
            Location = "Conference Room",
            CalendarIds = calendarIds,
        };
        return appt;
    }
    static WorkAppointment Conference7(DateTime start, IEnumerable<long> calendarIds) {
        DateTime newStart = start;
        DateTime newEnd = newStart.AddHours(1).AddMinutes(45);
        var appt = new WorkAppointment() {
            AppointmentType = (int)AppointmentType.Normal,
            Start = newStart,
            End = newEnd,
            Subject = "Home automation protocol",
            Description = "Discuss HDMI-CEC protocols and decide whether to introduce control protocol via IP interface.",
            Location = "Conference Room",
            CalendarIds = calendarIds,
        };
        return appt;
    }

    static WorkAppointment TrainingFrenchLesson(DateTime start, IEnumerable<long> calendarIds) {
        DateTime newStart = start;
        DateTime newEnd = newStart.AddHours(1.5);
        var appt = new WorkAppointment() {
            AppointmentType = (int)AppointmentType.Pattern,
            Start = newStart,
            End = newEnd,
            Subject = "French lesson",
            Location = "Training Room",
            Description = "Another french lesson.Once again, without mastering French, our success on the Continent will be less likely.Everyone needs to learn French.",
            CalendarIds = calendarIds,
        };
        appt.RecurrenceInfo = RecurrenceBuilder.Weekly(newStart, 10).ByDay(WeekDays.Monday | WeekDays.Wednesday).Build().ToXml();
        return appt;
    }
    static List<WorkAppointment> TrainingGermanLesson(DateTime start, IEnumerable<long> calendarIds) {
        DateTime newStart = start.AddDays(1);
        DateTime newEnd = newStart.AddHours(1.5);
        var appt = new WorkAppointment() {
            AppointmentType = (int)AppointmentType.Pattern,
            Start = newStart,
            End = newEnd,
            Subject = "German lesson",
            Location = "Training Room",
            Description = "We're learning French but we also need to become fluent in German. The German market for A/V products is huge. We need to be able to communicate in German if we are to have any luck in Germany.",
            CalendarIds = calendarIds,
        };
        var recInfo = RecurrenceBuilder.Weekly(newStart, 10).ByDay(WeekDays.Tuesday | WeekDays.Friday).Build();
        appt.RecurrenceInfo = recInfo.ToXml();
        var changed = ChangedOccurrence(appt, newStart.AddDays(7).AddHours(-1), recInfo.Id, 2, calendarIds);
        var deleted = DeletedOccurrence(appt, newStart.AddDays(14), recInfo.Id, 4, calendarIds);
        return new[] { appt, changed, deleted }.ToList();
    }
    static WorkAppointment TrainingTrainStaffOnNewRemoteControls(DateTime start, IEnumerable<long> calendarIds) {
        DateTime newStart = start;
        DateTime newEnd = newStart.AddHours(1).AddMinutes(50);
        var appt = new WorkAppointment() {
            AppointmentType = (int)AppointmentType.Normal,
            Start = newStart,
            End = newEnd,
            Subject = "Train staff on new remote controls",
            Location = "Training Room",
            Description = "Our newest remote controls are ready for production. Everyone needs to understand how our new universal remote works and our long term plans for better automation.",
            CalendarIds = calendarIds,
        };
        return appt;
    }

    static WorkAppointment ChangedOccurrence(WorkAppointment pattern, DateTime start, object recId, int index, IEnumerable<long> calendarIds) {
        var duration = pattern.End - pattern.Start;
        var appt = new WorkAppointment() {
            AppointmentType = (int)AppointmentType.ChangedOccurrence,
            AllDay = pattern.AllDay,
            Start = start,
            End = start + duration,
            Subject = pattern.Subject,
            Location = pattern.Location,
            Description = pattern.Description,
            CalendarIds = calendarIds,
            IsPrivate = pattern.IsPrivate,
            Label = pattern.Label,
            Status = pattern.Status,
        };
        appt.RecurrenceInfo = new PatternReferenceXmlPersistenceHelper(new PatternReference(recId, index)).ToXml();
        return appt;
    }
    static WorkAppointment DeletedOccurrence(WorkAppointment pattern, DateTime start, object recId, int index, IEnumerable<long> calendarIds) {
        var duration = pattern.End - pattern.Start;
        var appt = new WorkAppointment() {
            AppointmentType = (int)AppointmentType.DeletedOccurrence,
            AllDay = pattern.AllDay,
            Start = start,
            End = start + duration,
            Subject = pattern.Subject,
            Location = pattern.Location,
            Description = pattern.Description,
            CalendarIds = calendarIds,
            IsPrivate = pattern.IsPrivate,
            Label = pattern.Label,
            Status = pattern.Status,
        };
        appt.RecurrenceInfo = new PatternReferenceXmlPersistenceHelper(new PatternReference(recId, index)).ToXml();
        return appt;
    }

    static DateTime GetMonday(DateTime date) {
        DayOfWeek dayOfWeek = date.DayOfWeek;
        if(dayOfWeek == DayOfWeek.Monday)
            return date.Date;
        if(dayOfWeek == DayOfWeek.Saturday)
            return date.Date.AddDays(2);
        if(dayOfWeek == DayOfWeek.Sunday)
            return date.Date.AddDays(1);
        return date.Date.AddDays(-((int)dayOfWeek - 1));
    }

}