using DevExpress.Xpf.Grid;

namespace DevExpress.AvaloniaXpfDemo.DataGridModules;

public partial class CardTemplatesDemo : GridDemoModule {
    #region SelectedTabIndex attached property
    public static readonly DependencyProperty SelectedTabIndexProperty
        = DependencyProperty.RegisterAttached("SelectedTabIndex", typeof(int), typeof(CardTemplatesDemo),
            new PropertyMetadata(0, null, (d, baseValue) => ((int)baseValue == -1) ? GetSelectedTabIndex(d) : baseValue));
    public static void SetSelectedTabIndex(DependencyObject element, int value) {
        element.SetValue(SelectedTabIndexProperty, value);
    }
    public static int GetSelectedTabIndex(DependencyObject element) {
        return (int)element.GetValue(SelectedTabIndexProperty);
    }
    #endregion
    protected override GridControl GridControl => grid;

    public CardTemplatesDemo() {
        InitializeComponent();
        App.CommonRibbon.InitGridRibbon(grid);
    }
}
