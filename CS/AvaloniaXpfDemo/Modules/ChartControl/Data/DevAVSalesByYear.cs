#nullable disable
using System.Data;

namespace DevExpress.AvaloniaXpfDemo.ChartControlModules;

public class DevAVSalesByYear {
    public DataTable Data {
        get { return GetData(); }
    }
    public DataTable Series1Source {
        get {
            return GetData().AsEnumerable()
                      .Where(r => r.Field<int>("Year") == DateTime.Now.Year - 1)
                      .CopyToDataTable();
        }
    }
    public DataTable Series2Source {
        get {
            return GetData().AsEnumerable()
                      .Where(r => r.Field<int>("Year") == DateTime.Now.Year - 2)
                      .CopyToDataTable();
        }
    }
    public DataTable Series3Source {
        get {
            return GetData().AsEnumerable()
                      .Where(r => r.Field<int>("Year") == DateTime.Now.Year - 3)
                      .CopyToDataTable();
        }
    }
    public string Series1DisplayName {
        get { return (DateTime.Now.Year - 1).ToString(); }
    }
    public string Series2DisplayName {
        get { return (DateTime.Now.Year - 2).ToString(); }
    }
    public string Series3DisplayName {
        get { return (DateTime.Now.Year - 3).ToString(); }
    }

    public DataTable GetData() {
        int lastYear = DateTime.Now.Year - 1;
        DataTable table = new DataTable();
        table.Columns.AddRange(new DataColumn[] { new DataColumn("Year", typeof(int)), new DataColumn("Region", typeof(string)), new DataColumn("Sales", typeof(decimal)) });

        table.Rows.Add(lastYear - 2, "Asia", 4.23M);
        table.Rows.Add(lastYear - 2, "North America", 3.485M);
        table.Rows.Add(lastYear - 2, "Europe", 3.088M);
        table.Rows.Add(lastYear - 2, "Australia", 1.78M);
        table.Rows.Add(lastYear - 2, "South America", 1.602M);

        table.Rows.Add(lastYear - 1, "Asia", 4.768M);
        table.Rows.Add(lastYear - 1, "North America", 3.747M);
        table.Rows.Add(lastYear - 1, "Europe", 3.357M);
        table.Rows.Add(lastYear - 1, "Australia", 1.957M);
        table.Rows.Add(lastYear - 1, "South America", 1.823M);

        table.Rows.Add(lastYear, "Asia", 5.289M);
        table.Rows.Add(lastYear, "North America", 4.182M);
        table.Rows.Add(lastYear, "Europe", 3.725M);
        table.Rows.Add(lastYear, "Australia", 2.272M);
        table.Rows.Add(lastYear, "South America", 2.117M);

        return table;
    }
}