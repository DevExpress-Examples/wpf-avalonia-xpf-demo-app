using System.Reflection;
using System.Windows.Data;
using System.Windows.Documents;
using DevExpress.Mvvm.UI.Native;
using DevExpress.Xpf.Core;
using static DevExpress.AvaloniaXpfDemo.DemoShell.DemoModuleView;

namespace DevExpress.AvaloniaXpfDemo.DemoShell;

public class DemoModuleView : Grid, IDemoModuleView {
    public static readonly DependencyProperty RibbonStyleProperty;
    public static readonly DependencyProperty ShowRibbonApplicationButtonProperty;
    public static readonly DependencyProperty ShowBorderProperty;
    public static readonly DependencyProperty OptionsIsExpandedProperty;
    public static readonly DependencyProperty OptionsProperty;
    public static readonly DependencyProperty OptionsDataContextProperty;
    static readonly DependencyPropertyKey OptionsPropertyKey;
    public static readonly DependencyProperty IsModuleCompletelyLoadedProperty;
    static readonly DependencyPropertyKey IsModuleCompletelyLoadedPropertyKey;

    public Style? RibbonStyle { get { return (Style?)GetValue(RibbonStyleProperty); } set { SetValue(RibbonStyleProperty, value); } }
    public bool ShowRibbonApplicationButton { get { return (bool)GetValue(ShowRibbonApplicationButtonProperty); } set { SetValue(ShowRibbonApplicationButtonProperty, value); } }
    public bool ShowBorder { get { return (bool)GetValue(ShowBorderProperty); } set { SetValue(ShowBorderProperty, value); } }
    public bool OptionsIsExpanded { get { return (bool)GetValue(OptionsIsExpandedProperty); } set { SetValue(OptionsIsExpandedProperty, value); } }
    public object? OptionsDataContext { get { return (object?)GetValue(OptionsDataContextProperty); } set { SetValue(OptionsDataContextProperty, value); } }
    public FrameworkElement? Options { get { return (FrameworkElement?)GetValue(OptionsProperty); } private set { SetValue(OptionsPropertyKey, value); } }
    public bool IsModuleCompletelyLoaded { get { return (bool)GetValue(IsModuleCompletelyLoadedProperty); } private set { SetValue(IsModuleCompletelyLoadedPropertyKey, value); } }

    static DemoModuleView() {
        DependencyPropertyRegistrator<DemoModuleView>.New()
            .Register<Style?>(nameof(RibbonStyle), out RibbonStyleProperty, null)
            .Register(nameof(ShowRibbonApplicationButton), out ShowRibbonApplicationButtonProperty, false)
            .Register(nameof(ShowBorder), out ShowBorderProperty, true)
            .Register(nameof(OptionsIsExpanded), out OptionsIsExpandedProperty, true)
            .Register(nameof(OptionsDataContext), out OptionsDataContextProperty, default(object?), d => d.UpdateOptionsDataContext())
            .RegisterReadOnly(nameof(Options), out OptionsPropertyKey, out OptionsProperty, default(FrameworkElement?))
            .RegisterReadOnly(nameof(IsModuleCompletelyLoaded), out IsModuleCompletelyLoadedPropertyKey, out IsModuleCompletelyLoadedProperty, false)
        ;
    }

    protected virtual void OnModuleUnloading() { }
    protected virtual void OnModuleUnloaded() { }
    protected virtual void OnModuleLoaded() { }
    protected virtual void OnModuleCompletelyLoaded() { }

    protected override void OnInitialized(EventArgs e) {
        base.OnInitialized(e);
        InitOptions();
        UpdateOptionsDataContext();
    }
    void InitOptions() {
        var options = (FrameworkElement)FindName("PART_Options");
        if(options == null) return;
        var optionsPanel = (DockPanel)options.Parent;
        var optionsIndex = optionsPanel.Children.IndexOf(options);

        var decorator = new NonVisualDecorator();
        DockPanel.SetDock(decorator, Dock.Right);
        optionsPanel.Children.Insert(optionsIndex, decorator);
        options.SetBinding(TextElement.ForegroundProperty, new Binding("Foreground") { RelativeSource = new RelativeSource { AncestorType = typeof(Window) } });
        Helper.MoveLogicalChild(options, decorator, () => optionsPanel.Children.RemoveAt(optionsIndex + 1), () => decorator.Child = options);
        Options = options;
    }
    void UpdateOptionsDataContext() {
        if(Options == null) return;
        if(OptionsDataContext == null)
            Options.ClearValue(FrameworkElement.DataContextProperty);
        else
            Options.DataContext = OptionsDataContext;
    }

    void IDemoModuleView.OnModuleUnloading() => OnModuleUnloading();
    void IDemoModuleView.OnModuleUnloaded() => OnModuleUnloaded();
    void IDemoModuleView.OnModuleLoaded() => OnModuleLoaded();
    void IDemoModuleView.OnModuleCompletelyLoaded() {
        IsModuleCompletelyLoaded = true;
        OnModuleCompletelyLoaded();
    }

    public interface IDemoModuleView {
        void OnModuleUnloading();
        void OnModuleUnloaded();
        void OnModuleLoaded();
        void OnModuleCompletelyLoaded();
    }
    static class Helper {
        static readonly FieldInfo parentField = typeof(FrameworkElement)
            .GetField("_parent", BindingFlags.Instance | BindingFlags.NonPublic)!;
        public static void MoveLogicalChild(FrameworkElement child, DependencyObject newParent, Action remove, Action add) {
            parentField.SetValue(child, newParent);
            try {
                remove();
            }
            finally {
                parentField.SetValue(child, null);
            }
            add();
        }
    }
}