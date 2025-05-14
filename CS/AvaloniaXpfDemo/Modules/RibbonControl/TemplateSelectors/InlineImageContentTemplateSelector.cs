#nullable disable

namespace DevExpress.AvaloniaXpfDemo.RibbonControlModules;

public class InlineImageContentTemplateSelector : DataTemplateSelector {
    public TemplateSelectorDictionary Dictionary { get; set; }
    public override DataTemplate SelectTemplate(object item, DependencyObject container) {
        return Dictionary[((InlineImageBorderType)item).ToString()];
    }
}