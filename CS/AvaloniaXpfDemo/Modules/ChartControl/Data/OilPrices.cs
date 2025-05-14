#nullable disable
using System.Xml.Serialization;
using DevExpress.Utils;

namespace DevExpress.AvaloniaXpfDemo.ChartControlModules;

[XmlRoot("OilPrices")]
public class OilPrices : List<OilPricesByCompany> {
    public static OilPrices Load() {
        return SafeXml.Deserialize<OilPrices>(DataProvider.GetOilPricesStream());
    }
    public static List<OilPriceByDate> GetEuropeBrentPrices() {
        OilPrices prices = Load();
        return prices.First(x => x.CompanyName == "Europe Brent").Prices;
    }
}


public class OilPricesByCompany {
    public string CompanyName { get; set; }
    public List<OilPriceByDate> Prices { get; set; }
}


public class OilPriceByDate {
    public DateTime Timestamp { get; set; }
    public double MinValue { get; set; }
    public double MaxValue { get; set; }
}