using System.IO;

namespace DevExpress.AvaloniaXpfDemo;

public static class DataProvider {
    public static Stream GetCountriesResourceStream() => GetResourceStream("Countries.xml")!;
    public static Stream GetEmployeesResourceStream() => GetResourceStream("Employees.xml")!;
    public static Stream GetEmployeesWithPhotoResourceStream() => GetResourceStream("EmployeesWithPhoto.xml")!;
    public static Stream GetNWindOrdToNewEmployeeResourceStream() => GetResourceStream("NWindOrdToNewEmployee.xml")!;
    public static Stream GetShapesResourceStream() => GetResourceStream("Shapes.xml")!;
    public static Stream GetEmployeeTasksStream() => GetResourceStream("EmployeeTasks.xml")!;
    public static Stream GetPopulationStream() => GetResourceStream("Population.xml")!;
    public static Stream GetOilPricesStream() => GetResourceStream("OilPrices.xml")!;
    public static Stream GetCommentsDataStream() => GetResourceStream("CommentsData.xml")!;

    public static string NWindDBPath => GetDBPath("nwind.db");
    public static string VehiclesDBPath => GetDBPath("vehicles.db");

    static string GetDBPath(string name) {
        var dir = Path.GetDirectoryName(typeof(App).Assembly.Location)!;
        return Path.Combine(dir, $@"DBs/{name}");
    }
    static Stream GetResourceStream(string name) {
        return typeof(DataProvider).Assembly.GetManifestResourceStream($"{Prefix}.{name}")!;
    }
    const string Prefix = "DevExpress.AvaloniaXpfDemo.DBs";
}