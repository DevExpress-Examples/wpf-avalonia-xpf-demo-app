#nullable disable
using DevExpress.Mvvm.POCO;
using DevExpress.Xpf.Core;

namespace DevExpress.AvaloniaXpfDemo.ChartControlModules;

public class TabbedModuleViewModel {
    public static TabbedModuleViewModel Create() {
        return ViewModelSource.Create(() => new TabbedModuleViewModel());
    }

    public virtual DXTabItem SelectedTab { get; set; }

    protected TabbedModuleViewModel() { }
}