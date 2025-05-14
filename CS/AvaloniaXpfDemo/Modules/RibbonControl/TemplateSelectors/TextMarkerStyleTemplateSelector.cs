#nullable disable

namespace DevExpress.AvaloniaXpfDemo.RibbonControlModules;

public class TextMarkerStyleTemplateSelector : DataTemplateSelector {
    public TemplateSelectorDictionary Dictionary { get; set; }
    public override DataTemplate SelectTemplate(object item, DependencyObject container) {
        return Dictionary[((TextMarkerStyle)item).ToString()];
    }
}
