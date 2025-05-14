#nullable disable

namespace DevExpress.AvaloniaXpfDemo.RibbonControlModules;

public class RecentItemViewModel {
    static int count = 0;
    public string Caption { get; set; }
    public string Description { get; set; }
    public DateTime DateModified { get; set; }
    public RecentItemViewModel() { }
    public RecentItemViewModel(string caption, string description) {
        Caption = caption;
        Description = description;
        DateModified = DateTime.Now.AddDays(count);
        count++;
    }
}