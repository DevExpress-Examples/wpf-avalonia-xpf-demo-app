#nullable disable
namespace DevExpress.AvaloniaXpfDemo.ChartControlModules;

public class DevAVDataItem {
    public int Year { get; private set; }
    public decimal Sales { get; private set; }
    public decimal Charges { get; private set; }
    public string Company { get; private set; }

    public DevAVDataItem(int year, string company, decimal sales, decimal charges) {
        Year = year;
        Company = company;
        Sales = sales;
        Charges = charges;
    }
}


public class DevAVBranchesSales {
    public List<DevAVDataItem> GetList() {
        int lastYear = DateTime.Now.Year - 1;

        List<DevAVDataItem> list = new List<DevAVDataItem>(46);

        list.Add(new DevAVDataItem(lastYear - 10, "DevAV North", 1.010M, 0.430M));
        list.Add(new DevAVDataItem(lastYear - 10, "DevAV Central", 3.032M, 0.412M));
        list.Add(new DevAVDataItem(lastYear - 10, "DevAV South", 1.31M, 0.312M));

        list.Add(new DevAVDataItem(lastYear - 9, "DevAV North", 1.512M, 0.351M));
        list.Add(new DevAVDataItem(lastYear - 9, "DevAV Central", 3.050M, 0.411M));
        list.Add(new DevAVDataItem(lastYear - 9, "DevAV South", 1.34M, 0.333M));

        list.Add(new DevAVDataItem(lastYear - 8, "DevAV North", 1.723M, 0.431M));
        list.Add(new DevAVDataItem(lastYear - 8, "DevAV West", 0.005M, 0.215M));
        list.Add(new DevAVDataItem(lastYear - 8, "DevAV Central", 3.054M, 0.315M));
        list.Add(new DevAVDataItem(lastYear - 8, "DevAV South", 1.30M, 0.410M));

        list.Add(new DevAVDataItem(lastYear - 7, "DevAV West", 0.31M, 0.412M));
        list.Add(new DevAVDataItem(lastYear - 7, "DevAV North", 2.001M, 0.321M));
        list.Add(new DevAVDataItem(lastYear - 7, "DevAV Central", 2.975M, 0.327M));
        list.Add(new DevAVDataItem(lastYear - 7, "DevAV South", 1.283M, 0.412M));

        list.Add(new DevAVDataItem(lastYear - 6, "DevAV West", 0.41M, 0.323M));
        list.Add(new DevAVDataItem(lastYear - 6, "DevAV North", 2.612M, 0.411M));
        list.Add(new DevAVDataItem(lastYear - 6, "DevAV Central", 2.066M, 0.442M));
        list.Add(new DevAVDataItem(lastYear - 6, "DevAV South", 0.88M, 0.398M));

        list.Add(new DevAVDataItem(lastYear - 5, "DevAV West", 0.95M, 0.398M));
        list.Add(new DevAVDataItem(lastYear - 5, "DevAV North", 2.666M, 0.389M));
        list.Add(new DevAVDataItem(lastYear - 5, "DevAV Central", 2.078M, 0.421M));
        list.Add(new DevAVDataItem(lastYear - 5, "DevAV South", 1.09M, 0.401M));

        list.Add(new DevAVDataItem(lastYear - 4, "DevAV West", 1.53M, 0.435M));
        list.Add(new DevAVDataItem(lastYear - 4, "DevAV North", 3.665M, 0.444M));
        list.Add(new DevAVDataItem(lastYear - 4, "DevAV Central", 3.888M, 0.381M));
        list.Add(new DevAVDataItem(lastYear - 4, "DevAV South", 1.01M, 0.412M));

        list.Add(new DevAVDataItem(lastYear - 3, "DevAV East", 0.003M, 0.332M));
        list.Add(new DevAVDataItem(lastYear - 3, "DevAV West", 1.75M, 0.412M));
        list.Add(new DevAVDataItem(lastYear - 3, "DevAV North", 3.555M, 0.229M));
        list.Add(new DevAVDataItem(lastYear - 3, "DevAV Central", 3.008M, 0.431M));
        list.Add(new DevAVDataItem(lastYear - 3, "DevAV South", 1.11M, 0.223M));

        list.Add(new DevAVDataItem(lastYear - 2, "DevAV East", 0.32M, 0.450M));
        list.Add(new DevAVDataItem(lastYear - 2, "DevAV West", 1.31M, 0.413M));
        list.Add(new DevAVDataItem(lastYear - 2, "DevAV North", 3.485M, 0.426M));
        list.Add(new DevAVDataItem(lastYear - 2, "DevAV Central", 3.088M, 0.385M));
        list.Add(new DevAVDataItem(lastYear - 2, "DevAV South", 1.12M, 0.338M));

        list.Add(new DevAVDataItem(lastYear - 1, "DevAV East", 0.51M, 0.325M));
        list.Add(new DevAVDataItem(lastYear - 1, "DevAV West", 1.31M, 0.421M));
        list.Add(new DevAVDataItem(lastYear - 1, "DevAV North", 3.747M, 0.324M));
        list.Add(new DevAVDataItem(lastYear - 1, "DevAV Central", 3.357M, 0.441M));
        list.Add(new DevAVDataItem(lastYear - 1, "DevAV South", 1.12M, 0.524M));

        list.Add(new DevAVDataItem(lastYear, "DevAV East", 1.71M, 0.998M));
        list.Add(new DevAVDataItem(lastYear, "DevAV West", 1.22M, 0.324M));
        list.Add(new DevAVDataItem(lastYear, "DevAV North", 4.182M, 0.325M));
        list.Add(new DevAVDataItem(lastYear, "DevAV Central", 3.725M, 0.341M));
        list.Add(new DevAVDataItem(lastYear, "DevAV South", 1.111M, 0.439M));

        return list;
    }
}
