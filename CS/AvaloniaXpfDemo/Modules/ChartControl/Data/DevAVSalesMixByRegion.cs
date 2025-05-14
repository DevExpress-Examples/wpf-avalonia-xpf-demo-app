#nullable disable
using System.Data;

namespace DevExpress.AvaloniaXpfDemo.ChartControlModules;

public class DevAVSalesMixByRegion {
    public DataTable Data {
        get { return GetData(); }
    }

    public DataTable GetData() {
        DataTable table = new DataTable();
        table.Columns.AddRange(new DataColumn[] { new DataColumn("ProductCategory", typeof(string)), new DataColumn("Region", typeof(string)), new DataColumn("Sales", typeof(decimal)) });

        table.Rows.Add("Video players", "Asia", 853M);
        table.Rows.Add("Video players", "Australia", 321M);
        table.Rows.Add("Video players", "Europe", 655M);
        table.Rows.Add("Video players", "North America", 1325M);
        table.Rows.Add("Video players", "South America", 653M);

        table.Rows.Add("Automation", "Asia", 172M);
        table.Rows.Add("Automation", "Australia", 255M);
        table.Rows.Add("Automation", "Europe", 981M);
        table.Rows.Add("Automation", "North America", 963M);
        table.Rows.Add("Automation", "South America", 123M);

        table.Rows.Add("Monitors", "Asia", 1011M);
        table.Rows.Add("Monitors", "Australia", 359M);
        table.Rows.Add("Monitors", "Europe", 721M);
        table.Rows.Add("Monitors", "North America", 565M);
        table.Rows.Add("Monitors", "South America", 532M);

        table.Rows.Add("Projectors", "Asia", 998M);
        table.Rows.Add("Projectors", "Australia", 222M);
        table.Rows.Add("Projectors", "Europe", 865M);
        table.Rows.Add("Projectors", "North America", 787M);
        table.Rows.Add("Projectors", "South America", 332M);

        table.Rows.Add("Televisions", "Asia", 1356M);
        table.Rows.Add("Televisions", "Australia", 232M);
        table.Rows.Add("Televisions", "Europe", 1323M);
        table.Rows.Add("Televisions", "North America", 1125M);
        table.Rows.Add("Televisions", "South America", 865M);

        return table;
    }
}
