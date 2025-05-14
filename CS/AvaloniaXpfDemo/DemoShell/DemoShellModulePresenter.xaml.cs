using System.Windows.Documents;
using DevExpress.Mvvm.UI.Native;
using DevExpress.Xpf.Core;

namespace DevExpress.AvaloniaXpfDemo.DemoShell;

public partial class DemoShellModulePresenter : DockPanel {
    public static readonly DependencyProperty ShowDescriptionProperty;
    public bool ShowDescription { get { return (bool)GetValue(ShowDescriptionProperty); } set { SetValue(ShowDescriptionProperty, value); } }

    public DemoModule? Module { get; private set; }
    public DemoModuleView? ModuleView { get; private set; }
    public string? Error { get; private set; }

    static DemoShellModulePresenter() {
        DependencyPropertyRegistrator<DemoShellModulePresenter>.New()
            .Register<bool>(nameof(ShowDescription), out ShowDescriptionProperty, true, x => x.OnShowDescriptionChanged());
    }
    public DemoShellModulePresenter() {
        DataContext = null;
        InitializeComponent();
        LightweightThemeManager.CurrentThemeChangedWeakEvent += (s, e) => UpdateBorder();
    }

    public void SetModule(DemoModule? value, Action? moduleViewInitialized) {
        var oldModule = Module;
        if(oldModule == value)
            return;
        Module = value;
        OnModuleChanged(moduleViewInitialized);
    }
    void OnModuleChanged(Action? initialized) {
        errorPresenter.Text = null;
        contentPresenter.Child = null;
        descriptionPresenter.Document = null;
        optionsPresenter.OptionsContent = null;
        optionsPresenter.IsExpanded = true;
        ModuleView = null;

        if(Module == null) {
            UpdateVisibilities();
            UpdateBorder();
            return;
        }
        
        LoadModule(Module, out var moduleView, out var error);
        ModuleView = moduleView;
        Error = error;
        if(ModuleView != null)
            initialized?.Invoke();

        errorPresenter.Text = Error;
        contentPresenter.Child = ModuleView;
        descriptionPresenter.Document = Module.Description;
        optionsPresenter.OptionsContent = ModuleView?.Options;
        optionsPresenter.IsExpanded = ModuleView?.OptionsIsExpanded ?? true;
        UpdateVisibilities();
        UpdateBorder();

        static void LoadModule(DemoModule module, out DemoModuleView? moduleView, out string? error) {
            try {
                moduleView = module.CreateModuleView();
                error = null;
            }
            catch(Exception e) {
                moduleView = null;
                error = ExceptionHelper.GetMessage(e);
            }
        }
    }
    void OnShowDescriptionChanged() {
        UpdateVisibilities();
    }

    void UpdateVisibilities() {
        if(Module == null) {
            errorPresenter.Visibility = Visibility.Collapsed;
            contentPresenter.Visibility = Visibility.Collapsed;
            descriptionContainer.Visibility = Visibility.Collapsed;
            optionsPresenter.Visibility = Visibility.Collapsed;
            return;
        }
        if(!string.IsNullOrEmpty(Error)) {
            errorPresenter.Visibility = Visibility.Visible;
            contentPresenter.Visibility = Visibility.Collapsed;
            descriptionContainer.Visibility = Visibility.Collapsed;
            optionsPresenter.Visibility = Visibility.Collapsed;
        } else {
            errorPresenter.Visibility = Visibility.Collapsed;
            contentPresenter.Visibility = Visibility.Visible;
            descriptionContainer.Visibility =
                ShowDescription && !string.IsNullOrEmpty(Module.Description)
                ? Visibility.Visible
                : Visibility.Collapsed;
            optionsPresenter.Visibility =
                ModuleView?.Options != null
                ? Visibility.Visible
                : Visibility.Collapsed;
        }
    }
    void UpdateBorder() {
        var isWin11 = LightweightThemeManager.CurrentTheme.CategoryName == "Win11";
        if(ModuleView?.ShowBorder == false) {
            border.BorderThickness = new Thickness(0);
            optionsPresenter.BorderMode = DemoShellModuleOptionsBorderMode.Full;
        }
        else {
            border.BorderThickness = isWin11 ? new Thickness(1) : new Thickness(0);
            optionsPresenter.BorderMode = DemoShellModuleOptionsBorderMode.Left;
        }
    }
}
