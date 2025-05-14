#nullable disable
using System.Data;

namespace DevExpress.AvaloniaXpfDemo.ChartControlModules;

public class FuelPrices {
    public DataTable Data {
        get { return GetData(); }
    }

    public DataTable GetData() {
        DataTable table = new DataTable();
        table.Columns.AddRange(new DataColumn[] { new DataColumn("Date", typeof(DateTime)), new DataColumn("Price", typeof(decimal)) });
        table.Rows.Add(new DateTime(2016, 1, 1, 0, 0, 0), 2.143M);
        table.Rows.Add(new DateTime(2016, 2, 1, 0, 0, 0), 1.998M);
        table.Rows.Add(new DateTime(2016, 3, 1, 0, 0, 0), 2.090M);
        table.Rows.Add(new DateTime(2016, 4, 1, 0, 0, 0), 2.152M);
        table.Rows.Add(new DateTime(2016, 5, 1, 0, 0, 0), 2.315M);
        table.Rows.Add(new DateTime(2016, 6, 1, 0, 0, 0), 2.423M);
        table.Rows.Add(new DateTime(2016, 7, 1, 0, 0, 0), 2.405M);
        table.Rows.Add(new DateTime(2016, 8, 1, 0, 0, 0), 2.351M);
        table.Rows.Add(new DateTime(2016, 9, 1, 0, 0, 0), 2.394M);
        table.Rows.Add(new DateTime(2016, 10, 1, 0, 0, 0), 2.454M);
        table.Rows.Add(new DateTime(2016, 11, 1, 0, 0, 0), 2.439M);
        table.Rows.Add(new DateTime(2016, 12, 1, 0, 0, 0), 2.510M);
        return table;
    }
}