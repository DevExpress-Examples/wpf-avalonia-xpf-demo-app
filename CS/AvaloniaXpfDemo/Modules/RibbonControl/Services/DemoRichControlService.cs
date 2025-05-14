#nullable disable
using System.Windows.Documents;
using DevExpress.Mvvm.UI;

namespace DevExpress.AvaloniaXpfDemo.RibbonControlModules;

public interface IDemoRichControlService {
    void InsertImage(InlineImageViewModel imageViewModel);
    InlineImageViewModel GetViewModelFromContainer();
    void Clear();
}
public class DemoRichControlService : ServiceBase, IDemoRichControlService {
    protected DemoRichControl RichControl { get { return AssociatedObject as DemoRichControl; } }
    public void InsertImage(InlineImageViewModel imageViewModel) {
        RichControl.InsertContainer(new InlineUIContainer() { Child = new InlineImage(imageViewModel) });
    }
    public InlineImageViewModel GetViewModelFromContainer() {
        if(RichControl.Container != null)
            return ((InlineImage)((InlineUIContainer)RichControl.Container).Child).InlineImageViewModel;
        return null;
    }
    public void Clear() {
        RichControl.ClearCommand.Execute(null);
    }
}