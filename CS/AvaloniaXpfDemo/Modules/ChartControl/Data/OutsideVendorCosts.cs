#nullable disable
using System.Data;

namespace DevExpress.AvaloniaXpfDemo.ChartControlModules;

public class OutsideVendorCosts {
    public DataTable Data {
        get { return GetData(); }
    }

    public DataTable GetData() {
        int lastYear = DateTime.Now.Year - 1;
        DataTable table = new DataTable();
        table.Columns.AddRange(new DataColumn[] { new DataColumn("Year", typeof(DateTime)), new DataColumn("Company", typeof(string)), new DataColumn("Costs", typeof(decimal)) });

        table.Rows.Add(new DateTime(lastYear - 6, 12, 31), "DevAV North", 362.5M);
        table.Rows.Add(new DateTime(lastYear - 5, 12, 31), "DevAV North", 348.4M);
        table.Rows.Add(new DateTime(lastYear - 4, 12, 31), "DevAV North", 279.0M);
        table.Rows.Add(new DateTime(lastYear - 3, 12, 31), "DevAV North", 230.9M);
        table.Rows.Add(new DateTime(lastYear - 2, 12, 31), "DevAV North", 203.5M);
        table.Rows.Add(new DateTime(lastYear - 1, 12, 31), "DevAV North", 197.1M);

        table.Rows.Add(new DateTime(lastYear - 6, 12, 31), "DevAV South", 277.0M);
        table.Rows.Add(new DateTime(lastYear - 5, 12, 31), "DevAV South", 328.5M);
        table.Rows.Add(new DateTime(lastYear - 4, 12, 31), "DevAV South", 297.0M);
        table.Rows.Add(new DateTime(lastYear - 3, 12, 31), "DevAV South", 255.3M);
        table.Rows.Add(new DateTime(lastYear - 2, 12, 31), "DevAV South", 173.5M);
        table.Rows.Add(new DateTime(lastYear - 1, 12, 31), "DevAV South", 131.8M);

        return table;
    }
}
