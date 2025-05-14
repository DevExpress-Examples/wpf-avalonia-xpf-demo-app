#nullable disable
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;

namespace DevExpress.AvaloniaXpfDemo.DemoData {
    [XmlRoot("EmployeeTasks")]
    public class EmployeedTasks : List<EmployeeTask> {
        static IList<EmployeeTask> dataSource = null;
        static ObservableCollection<EmployeeTask> editableDataSource;
        static List<string> employeeNames;
        public static IList<EmployeeTask> DataSource {
            get {
                if(dataSource != null)
                    return dataSource;
                dataSource = GetEmployeeTasks();
                return dataSource;
            }

        }
#pragma warning disable DX0008
        static IList<EmployeeTask> GetEmployeeTasks() {
            Assembly assembly = typeof(EmployeedTasks).Assembly;
            Stream stream = DataProvider.GetEmployeeTasksStream();
            XmlSerializer s = new XmlSerializer(typeof(EmployeedTasks), new XmlRootAttribute("EmployeeTasks"));
            return (IList<EmployeeTask>)s.Deserialize(stream);
        }
#pragma warning restore DX0008
        public static ObservableCollection<EmployeeTask> EditableDataSource {
            get {
                if(editableDataSource != null)
                    return editableDataSource;
                editableDataSource = new ObservableCollection<EmployeeTask>(GetEmployeeTasks().Take(28));
                return editableDataSource;
            }
        }
        public static List<string> EmployeeNames {
            get {
                if(employeeNames != null)
                    return employeeNames;
                employeeNames = DataSource.Select(e => e.Employee).ToList();
                return employeeNames;
            }
        }
    }
    public class EmployeeTask : IEditableObject {
        public EmployeeTask() {
            Priority = Status = -1;
        }
        public int ID { get; set; }
        public int ParentID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Employee { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public int Priority { get; set; }
        public bool HasDescription { get { return !string.IsNullOrEmpty(Description); } }
        public bool IsCompleted { get { return Status == 100; } }
        public int Status { get; set; }
        public bool IsUpdated { get; set; }

        void IEditableObject.BeginEdit() { IsUpdated = false; }
        void IEditableObject.CancelEdit() { IsUpdated = false; }
        void IEditableObject.EndEdit() { IsUpdated = true; }
    }
}