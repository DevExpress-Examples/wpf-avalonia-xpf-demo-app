#nullable disable
using System.Windows.Markup;

namespace DevExpress.AvaloniaXpfDemo.DataGridModules;

[ContentProperty("Content")]
public class ValueSelectorItem : DependencyObject {
    public object Content {
        get { return GetValue(ContentProperty); }
        set { SetValue(ContentProperty, value); }
    }
    public static readonly DependencyProperty ContentProperty = DependencyProperty.Register("Content", typeof(object), typeof(ValueSelectorItem), new PropertyMetadata(null));

    public object Tag {
        get { return GetValue(TagProperty); }
        set { SetValue(TagProperty, value); }
    }
    public static readonly DependencyProperty TagProperty = DependencyProperty.Register("Tag", typeof(object), typeof(ValueSelectorItem), new PropertyMetadata(null));

    public string DisplayName {
        get { return (string)GetValue(DisplayNameProperty); }
        set { SetValue(DisplayNameProperty, value); }
    }
    public static readonly DependencyProperty DisplayNameProperty = DependencyProperty.Register("DisplayName", typeof(string), typeof(ValueSelectorItem), new PropertyMetadata(null));
}
