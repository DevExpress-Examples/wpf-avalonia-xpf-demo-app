using System.ComponentModel;
using DevExpress.Mvvm.UI.Native;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Docking;
using DevExpress.Xpf.Docking.Base;

namespace DevExpress.AvaloniaXpfDemo.DemoShell;

public enum DemoShellModuleOptionsBorderMode { Left, Full }

public partial class DemoShellModuleOptions : DockPanel {
    public static readonly DependencyProperty IsExpandedProperty;
    public static readonly DependencyProperty OptionsContentProperty;
    public static readonly DependencyProperty OptionsCaptionProperty;
    public static readonly DependencyProperty BorderModeProperty;
    public bool IsExpanded { get { return (bool)GetValue(IsExpandedProperty); } set { SetValue(IsExpandedProperty, value); } }
    public FrameworkElement? OptionsContent { get { return (FrameworkElement?)GetValue(OptionsContentProperty); } set { SetValue(OptionsContentProperty, value); } }
    public string? OptionsCaption { get { return (string?)GetValue(OptionsCaptionProperty); } set { SetValue(OptionsCaptionProperty, value); } }
    public DemoShellModuleOptionsBorderMode BorderMode { get { return (DemoShellModuleOptionsBorderMode)GetValue(BorderModeProperty); } set { SetValue(BorderModeProperty, value); } }

    static DemoShellModuleOptions() {
        DependencyPropertyRegistrator<DemoShellModuleOptions>.New()
            .Register<bool>(nameof(IsExpanded), out IsExpandedProperty, true, x => x.OnIsExpandedChanged())
            .Register<FrameworkElement?>(nameof(OptionsContent), out OptionsContentProperty, null)
            .Register<string?>(nameof(OptionsCaption), out OptionsCaptionProperty, "Options")
            .Register<DemoShellModuleOptionsBorderMode>(nameof(BorderMode), out BorderModeProperty, DemoShellModuleOptionsBorderMode.Left, x => x.UpdateBorder());
    }
    public DemoShellModuleOptions() {
        DataContext = null;
        InitializeComponent();
        UpdateLayoutPanelState();
        UpdateBorder();
        layoutPanel.Loaded += OnLayoutPanelLoaded;
        LightweightThemeManager.CurrentThemeChangedWeakEvent += (s, e) => UpdateBorder();
        DependencyPropertyDescriptor.FromProperty(LayoutPanel.AutoHideExpandStateProperty,  typeof(LayoutPanel))
            .AddValueChanged(layoutPanel, OnLayoutPanelAutoHideExpandStateChanged);
    }
    void OnHideButtonClick(object sender, RoutedEventArgs e) {
        IsExpanded = !IsExpanded;
    }
    void OnIsExpandedChanged() {
        UpdateLayoutPanelState();
    }
    void OnLayoutPanelLoaded(object sender, RoutedEventArgs e) {
        UpdateLayoutPanelState();
    }
    void OnLayoutPanelAutoHideExpandStateChanged(object? sender, EventArgs e) {
        IsExpanded = layoutPanel.AutoHideExpandState != AutoHideExpandState.Hidden;
    }
    void UpdateLayoutPanelState() {
        layoutPanel.AutoHideExpandState =
            IsExpanded
            ? AutoHideExpandState.Visible
            : AutoHideExpandState.Hidden;
    }
    void UpdateBorder() {
        var isWin11 = LightweightThemeManager.CurrentTheme.CategoryName == "Win11";
        if(isWin11 && BorderMode == DemoShellModuleOptionsBorderMode.Full) {
            border.BorderThickness = new Thickness(1);
            border.CornerRadius = new CornerRadius(7);
        } else {
            border.BorderThickness = new Thickness(1, 0, 0, 0);
            border.CornerRadius = new CornerRadius(0);
        }
    }
}