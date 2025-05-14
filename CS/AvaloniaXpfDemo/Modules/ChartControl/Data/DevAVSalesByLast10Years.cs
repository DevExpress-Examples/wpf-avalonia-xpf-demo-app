#nullable disable
using System.Data;

namespace DevExpress.AvaloniaXpfDemo.ChartControlModules;

public class DevAVSalesByLast10Years {
    public DataTable Data {
        get { return GetData(); }
    }

    public DataTable GetData() {
        int lastYear = DateTime.Now.Year - 1;
        DataTable table = new DataTable();
        table.Columns.AddRange(new DataColumn[] { new DataColumn("Year", typeof(DateTime)), new DataColumn("Region", typeof(string)), new DataColumn("Sales", typeof(decimal)) });

        table.Rows.Add(new DateTime(lastYear - 10, 12, 31), "North America", 3.010M);
        table.Rows.Add(new DateTime(lastYear - 10, 12, 31), "Europe", 3.032M);
        table.Rows.Add(new DateTime(lastYear - 10, 12, 31), "Australia", 1.31M);

        table.Rows.Add(new DateTime(lastYear - 9, 12, 31), "North America", 3.212M);
        table.Rows.Add(new DateTime(lastYear - 9, 12, 31), "Europe", 3.050M);
        table.Rows.Add(new DateTime(lastYear - 9, 12, 31), "Australia", 1.64M);

        table.Rows.Add(new DateTime(lastYear - 8, 12, 31), "North America", 3.223M);
        table.Rows.Add(new DateTime(lastYear - 8, 12, 31), "Europe", 3.054M);
        table.Rows.Add(new DateTime(lastYear - 8, 12, 31), "Australia", 1.70M);

        table.Rows.Add(new DateTime(lastYear - 7, 12, 31), "North America", 3.001M);
        table.Rows.Add(new DateTime(lastYear - 7, 12, 31), "Europe", 2.775M);
        table.Rows.Add(new DateTime(lastYear - 7, 12, 31), "Australia", 1.083M);

        table.Rows.Add(new DateTime(lastYear - 6, 12, 31), "North America", 2.612M);
        table.Rows.Add(new DateTime(lastYear - 6, 12, 31), "Europe", 2.066M);
        table.Rows.Add(new DateTime(lastYear - 6, 12, 31), "Australia", 0.88M);

        table.Rows.Add(new DateTime(lastYear - 5, 12, 31), "North America", 2.666M);
        table.Rows.Add(new DateTime(lastYear - 5, 12, 31), "Europe", 2.078M);
        table.Rows.Add(new DateTime(lastYear - 5, 12, 31), "Australia", 1.09M);

        table.Rows.Add(new DateTime(lastYear - 4, 12, 31), "North America", 3.665M);
        table.Rows.Add(new DateTime(lastYear - 4, 12, 31), "Europe", 3.888M);
        table.Rows.Add(new DateTime(lastYear - 4, 12, 31), "Australia", 2.01M);

        table.Rows.Add(new DateTime(lastYear - 3, 12, 31), "North America", 3.555M);
        table.Rows.Add(new DateTime(lastYear - 3, 12, 31), "Europe", 3.008M);
        table.Rows.Add(new DateTime(lastYear - 3, 12, 31), "Australia", 1.85M);

        table.Rows.Add(new DateTime(lastYear - 2, 12, 31), "North America", 3.485M);
        table.Rows.Add(new DateTime(lastYear - 2, 12, 31), "Europe", 3.088M);
        table.Rows.Add(new DateTime(lastYear - 2, 12, 31), "Australia", 1.78M);

        table.Rows.Add(new DateTime(lastYear - 1, 12, 31), "North America", 3.747M);
        table.Rows.Add(new DateTime(lastYear - 1, 12, 31), "Europe", 3.357M);
        table.Rows.Add(new DateTime(lastYear - 1, 12, 31), "Australia", 1.957M);

        table.Rows.Add(new DateTime(lastYear, 12, 31), "North America", 4.182M);
        table.Rows.Add(new DateTime(lastYear, 12, 31), "Europe", 3.725M);
        table.Rows.Add(new DateTime(lastYear, 12, 31), "Australia", 2.272M);

        return table;
    }
}