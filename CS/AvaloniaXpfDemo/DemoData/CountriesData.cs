#nullable disable
using System.Reflection;
using System.Xml.Serialization;
using DevExpress.Utils;

namespace DevExpress.AvaloniaXpfDemo.DemoData {
    [XmlRoot("Countries")]
    public class CountriesData : List<Country> {
        static List<Country> dataSource = null;
        public static List<Country> DataSource {
            get {
                if(dataSource != null)
                    return dataSource;
                dataSource = SafeXml.Deserialize<CountriesData>(DataProvider.GetCountriesResourceStream());
                return dataSource;
            }
        }
    }

    public class Country {
        public string ActualNWindName { get { return NWindName ?? Name; } }
        public string ActualName { get { return Name ?? NWindName; } }
        public string Name { get; set; }
        public string NWindName { get; set; }
        public byte[] Flag { get; set; }
    }
}
