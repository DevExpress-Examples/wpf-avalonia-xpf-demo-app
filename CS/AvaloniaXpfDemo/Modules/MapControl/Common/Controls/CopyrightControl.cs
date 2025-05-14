namespace DevExpress.AvaloniaXpfDemo.MapControlModules;

public enum ProviderName {
    Azure,
    Bing,
    Osm,
    None
}
public class CopyrightControl : VisibleControl {
    public static readonly DependencyProperty ProviderNameProperty = DependencyProperty.Register("ProviderName",
        typeof(ProviderName), typeof(CopyrightControl), new PropertyMetadata(ProviderName.None));

    public ProviderName ProviderName {
        get { return (ProviderName)GetValue(ProviderNameProperty); }
        set { SetValue(ProviderNameProperty, value); }
    }

    public CopyrightControl() {
        DefaultStyleKey = typeof(CopyrightControl);
    }
}