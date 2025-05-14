#nullable disable
using System.ComponentModel;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using DevExpress.Data.Utils;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;

namespace DevExpress.AvaloniaXpfDemo.DataEditorsModules;

static class EmployeeImageHelper {
    public const string ImagesPath = "pack://application:,,,/DevExpress.Images.v" + AssemblyInfo.VersionShort + ";component/SvgImages/";
}
public enum PersonPrefix {
    [Image(EmployeeImageHelper.ImagesPath + "Outlook Inspired/Doctor.svg")]
    Dr,
    [Image(EmployeeImageHelper.ImagesPath + "Outlook Inspired/Customers.svg")]
    Mr,
    [Image(EmployeeImageHelper.ImagesPath + "Outlook Inspired/Mr.svg")]
    Ms,
    [Image(EmployeeImageHelper.ImagesPath + "Outlook Inspired/Miss.svg")]
    Miss,
    [Image(EmployeeImageHelper.ImagesPath + "Outlook Inspired/Mrs.svg")]
    Mrs
}

public enum EmployeeStatus {
    Salaried,
    Commission,
    Terminated,
    OnLeave
}
public enum EmployeeDepartment { Sales, Support, Shipping, Engineering, HumanResources, Management, IT }
public enum StateEnum { CA, AR, AL, AK, AZ, CO, CT, DE, DC, FL, GA, HI, ID, IL, IN, IA, KS, KY, LA, ME, MD, MA, MI, MN, MS, MO, MT, NE, NV, NH, NJ, NM, NY, NC, OH, OK, OR, PA, RI, SC, SD, TN, TX, UT, VT, VA, WA, WV, WI, WY, ND }

public enum EmployeeTaskPriority {
    [Image(EmployeeImageHelper.ImagesPath + "Outlook Inspired/LowPriority.svg")]
    Low,
    [Image(EmployeeImageHelper.ImagesPath + "Outlook Inspired/NormalPriority.svg")]
    Normal,
    [Image(EmployeeImageHelper.ImagesPath + "Outlook Inspired/MediumPriority.svg")]
    High,
    [Image(EmployeeImageHelper.ImagesPath + "Outlook Inspired/HighPriority.svg")]
    Urgent
}

public class EmployeeTask {
    public int Completion { get; set; }
    public string Description { get; set; }
    public DateTime? DueDate { get; set; }
    public EmployeeTaskPriority Priority { get; set; }
    public DateTime? StartDate { get; set; }
    public string Subject { get; set; }
}
public class Evaluation {
    public DateTime CreatedOn { get; set; }
    public string Manager { get; set; }
    public string Subject { get; set; }
}
public class Address : ViewModelBase {
    string city;
    string line;
    StateEnum state;
    string zipCode;
    public string City { get { return city; } set { SetProperty(ref city, value, "City"); } }
    public string Line { get { return line; } set { SetProperty(ref line, value, "Line"); } }
    public StateEnum State { get { return state; } set { SetProperty(ref state, value, "State"); } }
    public string ZipCode { get { return zipCode; } set { SetProperty(ref zipCode, value, "ZipCode"); } }
    public Address() {
        Initialize();
    }
    void Initialize() {
        Line = "6755 Newlin Ave";
        City = "Whittier";
        State = StateEnum.AK;
        ZipCode = "90601";
    }
}

public class EmployeeViewModel : ViewModelBase, IDataErrorInfo {
    Address address;
    List<EmployeeTask> assignedTasks;
    DateTime? birthDate;
    EmployeeDepartment department;
    string email;
    List<Evaluation> evaluations;
    string firstName;
    DateTime? hireDate;
    string homePhone;
    string lastName;
    string mobilePhone;
    string personalProfile;
    ImageSource photo;
    PersonPrefix prefix;
    string probationReason;
    string skype;
    EmployeeStatus status;
    string title;
    public Address Address { get { return address; } set { SetProperty(ref address, value, "Address"); } }
    public List<EmployeeTask> AssignedTasks { get { return assignedTasks; } set { SetProperty(ref assignedTasks, value, "AssignedTasks"); } }
    public DateTime? BirthDate { get { return birthDate; } set { SetProperty(ref birthDate, value, "BirthDate"); } }
    public EmployeeDepartment Department { get { return department; } set { SetProperty(ref department, value, "Department"); } }
    public string Email { get { return email; } set { SetProperty(ref email, value, "Email"); } }
    public List<Evaluation> Evaluations { get { return evaluations; } set { SetProperty(ref evaluations, value, "Evaluations"); } }
    public string FirstName { get { return firstName; } set { SetProperty(ref firstName, value, "FirstName", RaiseFullNamePropertyChanged); } }
    public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }
    public DateTime? HireDate { get { return hireDate; } set { SetProperty(ref hireDate, value, "HireDate"); } }
    public string HomePhone { get { return homePhone; } set { SetProperty(ref homePhone, value, "HomePhone"); } }
    public string LastName { get { return lastName; } set { SetProperty(ref lastName, value, "LastName", RaiseFullNamePropertyChanged); } }
    public string MobilePhone { get { return mobilePhone; } set { SetProperty(ref mobilePhone, value, "MobilePhone"); } }
    public string PersonalProfile { get { return personalProfile; } set { SetProperty(ref personalProfile, value, "PersonalProfile"); } }
    public ImageSource Photo { get { return photo; } set { SetProperty(ref photo, value, "Photo"); } }
    public PersonPrefix Prefix { get { return prefix; } set { SetProperty(ref prefix, value, "Prefix"); } }
    public string ProbationReason { get { return probationReason; } set { SetProperty(ref probationReason, value, "ProbationReason"); } }
    public string Skype { get { return skype; } set { SetProperty(ref skype, value, "Skype"); } }
    public EmployeeStatus Status { get { return status; } set { SetProperty(ref status, value, "Status"); } }
    public string Title { get { return title; } set { SetProperty(ref title, value, "Title"); } }
    public EmployeeViewModel() {
        Initialize();
    }
    void Initialize() {
        Address = new Address();
        FirstName = "Leah";
        LastName = "Simpson";
        BirthDate = new DateTime(1983, 4, 19);
        Title = "Test Coordinator";
        Prefix = PersonPrefix.Mrs;
        HomePhone = "(562) 555-7372";
        MobilePhone = "(562) 559-5830";
        Email = "leahs@dx-email.com";
        Skype = "leahs_DX_skype";
        Department = EmployeeDepartment.Engineering;
        Status = EmployeeStatus.Salaried;
        HireDate = new DateTime(2009, 2, 14);
        Photo = new BitmapImage(DemoHelper.GetResourceUri("Images/Persons/w03.jpg"));
        GenerateAssignedTasks();
        GenerateEvaluations();
    }
    void RaiseFullNamePropertyChanged() {
        RaisePropertyChanged("FullName");
    }
    void GenerateAssignedTasks() {
        AssignedTasks = new List<EmployeeTask>();
        EmployeeTask employeeTask1 = new EmployeeTask();
        employeeTask1.Priority = EmployeeTaskPriority.Normal;
        employeeTask1.DueDate = DateTime.Now + new TimeSpan(10, 10, 0, 0, 0);
        employeeTask1.Subject = string.Format("{0} QA Strategy Report", DateTime.Now.Year);
        employeeTask1.Description = string.Format("In final stages of the {0} R & D Report to Management.Need QA strategy report asap.Remember, {1} was a difficult year product quality-wise and we must step it up in {0}. Leah Simpson: Bart, my apologies about {1}.My report includes remedies to issues we encountered.", DateTime.Now.Year, DateTime.Now.Year - 1);
        employeeTask1.Completion = 100;
        AssignedTasks.Add(employeeTask1);

        EmployeeTask employeeTask2 = new EmployeeTask();
        employeeTask2.Priority = EmployeeTaskPriority.Urgent;
        employeeTask2.DueDate = DateTime.Now + new TimeSpan(40, 10, 0, 0, 0);
        employeeTask2.Subject = "Review Training Course for any Commissions";
        employeeTask2.Description = "Leah, consider this most important item on your agenda. I need this new training material reviewed so it can be submitted to management. Leah Simpson: I only found a few spelling mistakes.";
        employeeTask2.Completion = 70;
        AssignedTasks.Add(employeeTask2);


        EmployeeTask employeeTask3 = new EmployeeTask();
        employeeTask3.Priority = EmployeeTaskPriority.Low;
        employeeTask3.DueDate = DateTime.Now + new TimeSpan(80, 10, 0, 0, 0);
        employeeTask3.Subject = "Review New Training Material";
        employeeTask3.Description = "Just getting ready to push out some new training material for our customers so they can better understand how our product line fits together.Can I get a review of the content so I can send it out to the printer ? Leah Simpson: Nat, I've reviewed everything and it looks really nice.";
        employeeTask3.Completion = 55;
        AssignedTasks.Add(employeeTask3);

        EmployeeTask employeeTask4 = new EmployeeTask();
        employeeTask4.Priority = EmployeeTaskPriority.High;
        employeeTask4.DueDate = DateTime.Now + new TimeSpan(95, 10, 0, 0, 0);
        employeeTask4.Subject = "Test New Automation App";
        employeeTask4.Description = "We are in a rush to ship this and you need to put all your energy behind finding bugs.If you do find bugs, use standard reporting mechanisms. We'll fix what we can as soon as we can.";
        employeeTask4.Completion = 40;
        AssignedTasks.Add(employeeTask4);

        EmployeeTask employeeTask5 = new EmployeeTask();
        employeeTask5.Priority = EmployeeTaskPriority.Urgent;
        employeeTask5.DueDate = DateTime.Now + new TimeSpan(30, 10, 0, 0, 0);
        employeeTask5.Subject = "Email Test Report on New Products";
        employeeTask5.Description = "Leah, we cannot fix our products until we get the test report from you.Please send everything you have by email to me so I can distribute it in the engineering dept. Leah Simpson: Still collecting these";
        employeeTask5.Completion = 15;
        AssignedTasks.Add(employeeTask5);
    }
    void GenerateEvaluations() {
        NonCryptographicRandom rand = NonCryptographicRandom.Default;
        Evaluations = new List<Evaluation>();
        for(int i = HireDate.Value.Year; i < DateTime.Now.Year; i++)
            Evaluations.Add(new Evaluation() { CreatedOn = new DateTime(i, rand.Next(1, 12), rand.Next(1, 25)), Manager = "Bart Simpson", Subject = string.Format("{0} Employee Review", i) });
    }
    public string this[string columnName] {
        get {
            if(columnName == "FirstName" && string.IsNullOrEmpty(FirstName))
                return "The First Name field is required.";
            if(columnName == "LastName" && string.IsNullOrEmpty(LastName))
                return "The Last Name field is required.";
            if(columnName == "Title" && string.IsNullOrEmpty(Title))
                return "The Title field is required.";
            if(columnName == "MobilePhone" && string.IsNullOrEmpty(MobilePhone))
                return "The Mobile Phone field is required.";
            if(columnName == "Email" && string.IsNullOrEmpty(Email))
                return "The Email field is required.";
            return null;
        }
    }
    public string Error {
        get {
            string error =
                this["FirstName"] +
                this["LastName"] +
                this["Title"] +
                this["MobilePhone"] +
                this["Email"];
            if(!string.IsNullOrEmpty(error))
                return "Please check inputted data.";
            return null;
        }
    }
}
public class OverviewDemoViewModel : ViewModelBase {
    public EmployeeViewModel Employee { get; set; }
}

public class EnumToItemSourceProvider : MarkupExtension {
    public Type EnumType { get; set; }
    public override object ProvideValue(IServiceProvider serviceProvider) {
        List<object> result = new List<object>();
        Array values = Enum.GetValues(EnumType);
        foreach(var value in values)
            result.Add(new { Name = Enum.GetName(EnumType, value), Value = value });

        return result;
    }
}