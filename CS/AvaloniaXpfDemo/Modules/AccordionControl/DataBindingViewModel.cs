#nullable disable
using System.Collections.ObjectModel;
using DevExpress.AvaloniaXpfDemo.DemoData;
using DevExpress.AvaloniaXpfDemo.DemoData.Employees;

namespace DevExpress.AvaloniaXpfDemo.AccordionControlModules;

public class DataBindingViewModel {
    public ReadOnlyCollection<EmployeeDepartment> Departments { get; private set; }
    public virtual object SelectedItem { get; set; }

    public DataBindingViewModel() {
        var departments = EmployeesWithPhotoData.DataSource
            .GroupBy(x => x.GroupName)
            .Select(x => CreateEmployeeDepartment(x.Key, x.Take(10).ToArray()))
            .ToArray();
        Departments = new ReadOnlyCollection<EmployeeDepartment>(departments);
        SelectedItem = Departments[1].Employees[0];
    }

    static EmployeeDepartment CreateEmployeeDepartment(string name, IList<Employee> employees) {
        var image = ImageHelper.GetEmployeeDepartmentImage(name);
        return new EmployeeDepartment(name, image, employees);
    }
}
public class EmployeeDepartment {
    public string Name { get; private set; }
    public Uri SvgImage { get; private set; }
    public ReadOnlyCollection<Employee> Employees { get; private set; }

    public EmployeeDepartment(string name, Uri svgImage, IList<Employee> employees) {
        this.Name = name;
        this.SvgImage = svgImage;
        this.Employees = new ReadOnlyCollection<Employee>(employees);
    }

    public override string ToString() {
        return Name;
    }
}
public static class ImageHelper {
    static readonly List<string> EmployeeDepartmentImages = new List<string> { "administration", "inventory", "manufacturing", "quality", "research", "sales" };
    public static Uri GetEmployeeDepartmentImage(string departmentName) {
        var imageName = EmployeeDepartmentImages
            .FirstOrDefault(x => departmentName.ToLower().Contains(x));
        if(string.IsNullOrEmpty(imageName))
            return null;
        return DemoHelper.GetResourceUri("Images/Departments/" + imageName + ".svg");
    }
}