#nullable disable
using System.ComponentModel;
using System.IO;
using System.Windows.Media;
using System.Xml.Serialization;
using DevExpress.AvaloniaXpfDemo.DemoData.Employees;
using DevExpress.Utils;

namespace DevExpress.AvaloniaXpfDemo.DemoData {
    [XmlRoot("Employees")]
    public class EmployeesData : List<Employee> {
#pragma warning disable DX0008
        static readonly XmlSerializer Serializer = new Serialization.GeneratedSerializers.EmployeesData.EmployeesDataSerializer();
        public static List<Employee> DataSource { get { return (List<Employee>)Serializer.Deserialize(GetDataStream()); } }
#pragma warning restore DX0008
        static Stream GetDataStream() {
            return DataProvider.GetEmployeesResourceStream();
        }

        static readonly Lazy<ImageSource> imageMale = new Lazy<ImageSource>(() => ImageSourceHelper.GetImageSource(DemoHelper.GetResourceUri("Images/EmployeesData/Person_Male.png")));
        internal static ImageSource ImageMale { get { return imageMale.Value; } }
        static readonly Lazy<ImageSource> imageFemale = new Lazy<ImageSource>(() => ImageSourceHelper.GetImageSource(DemoHelper.GetResourceUri("Images/EmployeesData/Person_Female.png")));
        internal static ImageSource ImageFemale { get { return imageFemale.Value; } }

        static Dictionary<string, Uri> personImages = CreatePersonImages();
        internal static Dictionary<string, Uri> PersonImages { get { return personImages; } }

        static Dictionary<string, Uri> CreatePersonImages() {
            var result = new Dictionary<string, Uri>();
            result.Add("Mr", GetPersonImage("Mr"));
            result.Add("Miss", GetPersonImage("Miss"));
            result.Add("Mrs", GetPersonImage("Mrs"));
            result.Add("Ms", GetPersonImage("Ms"));
            return result;
        }
        static Uri GetPersonImage(string person) {
            return DemoHelper.GetResourceUri($"Images/EmployeesData/Person_{person}.svg");
        }
    }
#pragma warning disable DX0008
    [XmlRoot("Employees")]
    public class EmployeesWithPhotoData : List<Employee> {
        static readonly XmlSerializer Serializer = new Serialization.GeneratedSerializers.EmployeesWithPhotoData.EmployeesWithPhotoDataSerializer();
        static readonly XmlSerializer OrdersRelationsSerializer = new Serialization.GeneratedSerializers.NWindOrderToNewEmployeeArray.ArrayOfNWindOrderToNewEmployeeSerializer();
        public static List<Employee> DataSource { get { return (List<Employee>)Serializer.Deserialize(GetDataStream()); } }

        static NWindOrderToNewEmployee[] GetOrdersRelationsList() { return (NWindOrderToNewEmployee[])OrdersRelationsSerializer.Deserialize(GetOrdersRelationsStream()); }
        static readonly Lazy<Dictionary<int, int>> ordersRelations = new Lazy<Dictionary<int, int>>(() => GetOrdersRelationsList().ToDictionary(x => x.NWindOrderId, x => x.EmployeeId));
        public static Dictionary<int, int> OrdersRelations { get { return ordersRelations.Value; } }

        public static Stream GetDataStream() {
            return DataProvider.GetEmployeesWithPhotoResourceStream();
        }
        static Stream GetOrdersRelationsStream() {
            return DataProvider.GetNWindOrdToNewEmployeeResourceStream();
        }
    }
#pragma warning restore DX0008
    public class NWindOrderToNewEmployee {
        public int NWindOrderId { get; set; }
        public int EmployeeId { get; set; }
    }
}
namespace DevExpress.AvaloniaXpfDemo.DemoData.Employees {
    public class Movie {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get { return Price * Quantity; } }
        public string Preview { get; set; }
    }
    public class Order {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get { return Price * Quantity; } }
        public string Preview { get; set; }
    }
    public class Employee : IComparable, INotifyPropertyChanged {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string Phone { get; set; }
        public string EmailAddress { get; set; }
        public string AddressLine1 { get; set; }
        public string City { get; set; }
        public string StateProvinceName { get; set; }
        public string PostalCode { get; set; }
        public string CountryRegionName { get; set; }
        [XmlIgnore]
        string groupNameCore;
        public string GroupName {
            get { return groupNameCore; }
            set {
                if(groupNameCore != value) {
                    RaisePropertyChanged(nameof(GroupName));
                    groupNameCore = value;
                }
            }
        }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string Title { get; set; }
        public byte[] ImageData { get; set; }
        public ImageSource Image { get { return Gender == "F" ? EmployeesData.ImageFemale : EmployeesData.ImageMale; } }
        public Uri SvgImage { get { return GetSvgImageUri(); } }
        public override string ToString() {
            return FirstName + " " + LastName;
        }
        #region Equality
        public int CompareTo(object obj) {
            Employee empl = obj as Employee;
            if(empl == null)
                throw new ArgumentException();
            return string.Compare(FirstName + LastName, empl.FirstName + empl.LastName);
        }
        #endregion
        public override bool Equals(object obj) {
            if(obj == null) return false;
            return ToString() == obj.ToString();
        }

        public override int GetHashCode() {
            return Id;
        }

        void RaisePropertyChanged(string propertyName) {
            if(PropertyChanged != null) {
                PropertyChangedEventArgs e = new PropertyChangedEventArgs(propertyName);
                PropertyChanged(this, e);
            }
        }
        Uri GetSvgImageUri() {
            if(Gender == "M")
                return EmployeesData.PersonImages["Mr"];
            if(MaritalStatus == "M")
                return EmployeesData.PersonImages["Mrs"];
            if(MaritalStatus == "S")
                return EmployeesData.PersonImages["Miss"];
            return EmployeesData.PersonImages["Ms"];
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
    public class OrderDataSourceCreator {
        public static List<Order> CreateDataSource() { return CreateDataSource(1000); }
        public static List<Order> CreateDataSource(int rowCount) {
            List<Order> list = new List<Order>();
            for(int i = 0; i < rowCount; i++) {
                list.Add(CreateItem(i + 1));
            }
            return list;
        }
        static Order CreateItem(int id) {
            Order order = new Order();
            order.ID = id;
            order.Name = "Name " + id.ToString();
            order.OrderDate = DateTime.Today.AddDays(-id % 20);
            order.Price = 100 + id % 10;
            order.Quantity = 10 + id % 15;
            order.Preview = "c:/0.png";
            return order;
        }
    }
    public class MovieDataSourceCreator {
        public static List<Movie> CreateDataSource() { return CreateDataSource(10); }
        public static List<Movie> CreateDataSource(int rowCount) {
            List<Movie> list = new List<Movie>();
            for(int i = 0; i < 1000; i++) {
                list.Add(CreateItem(i + 1));
            }
            return list;
        }
        static Movie CreateItem(int id) {
            Movie order = new Movie();
            order.ID = id;
            order.Name = "Name " + id.ToString();
            order.OrderDate = DateTime.Today.AddDays(-id % 20);
            order.Price = 100 + id % 10;
            order.Quantity = 10 + id % 15;
            order.Preview = "movies/0.wmv";
            return order;
        }
    }
}