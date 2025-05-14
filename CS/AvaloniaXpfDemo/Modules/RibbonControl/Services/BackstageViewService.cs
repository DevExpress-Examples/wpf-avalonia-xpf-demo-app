#nullable disable
using DevExpress.Mvvm.UI;
using DevExpress.Xpf.Ribbon;

namespace DevExpress.AvaloniaXpfDemo.RibbonControlModules;

public interface IBackstageViewService {
    void Close();
}
public class BackstageViewService : ServiceBase, IBackstageViewService {
    RibbonControl Ribbon { get { return AssociatedObject as RibbonControl; } }
    public void Close() {
        if(Ribbon != null || Ribbon.MergedParent != null) {
            Ribbon.MergedParent.CloseApplicationMenu();
        }
    }
}