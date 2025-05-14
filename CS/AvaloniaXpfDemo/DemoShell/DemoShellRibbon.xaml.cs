using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Media;
using DevExpress.Mvvm;
using DevExpress.Mvvm.Native;
using DevExpress.Mvvm.UI.Interactivity;
using DevExpress.Mvvm.UI.Native;
using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Core.Native;
using DevExpress.Xpf.Ribbon;
using RibbonControl = DevExpress.Xpf.Ribbon.RibbonControl;

namespace DevExpress.AvaloniaXpfDemo.DemoShell;

public partial class DemoShellRibbon : Grid {
    public static readonly DependencyProperty ModulesProperty;
    public static readonly DependencyProperty RibbonStyleProperty;
    public static readonly DependencyProperty ShowApplicationButtonProperty;
    public static readonly DependencyProperty IsFullWindowModeCheckedProperty;
    public static readonly DependencyProperty PrevCommandProperty;
    public static readonly DependencyProperty NextCommandProperty;
    public static readonly DependencyProperty SelectCommandProperty;
    public static readonly DependencyProperty OpenLinkGetStartedCommandProperty;
    public static readonly DependencyProperty OpenLinkGetSupportCommandProperty;
    public static readonly DependencyProperty OpenLinkBuyNowCommandProperty;

    public IReadOnlyList<DemoModuleGroup>? Modules { get { return (IReadOnlyList<DemoModuleGroup>?)GetValue(ModulesProperty); } set { SetValue(ModulesProperty, value); } }
    public Style? RibbonStyle { get { return (Style?)GetValue(RibbonStyleProperty); } set { SetValue(RibbonStyleProperty, value); } }
    public bool ShowApplicationButton { get { return (bool)GetValue(ShowApplicationButtonProperty); } set { SetValue(ShowApplicationButtonProperty, value); } }
    public bool IsFullWindowModeChecked { get { return (bool)GetValue(IsFullWindowModeCheckedProperty); } set { SetValue(IsFullWindowModeCheckedProperty, value); } }
    public ICommand? PrevCommand { get { return (ICommand?)GetValue(PrevCommandProperty); } set { SetValue(PrevCommandProperty, value); } }
    public ICommand? NextCommand { get { return (ICommand?)GetValue(NextCommandProperty); } set { SetValue(NextCommandProperty, value); } }
    public ICommand<DemoModule>? SelectCommand { get { return (ICommand<DemoModule>?)GetValue(SelectCommandProperty); } set { SetValue(SelectCommandProperty, value); } }
    public ICommand? OpenLinkGetStartedCommand { get { return (ICommand?)GetValue(OpenLinkGetStartedCommandProperty); } set { SetValue(OpenLinkGetStartedCommandProperty, value); } }
    public ICommand? OpenLinkGetSupportCommand { get { return (ICommand?)GetValue(OpenLinkGetSupportCommandProperty); } set { SetValue(OpenLinkGetSupportCommandProperty, value); } }
    public ICommand? OpenLinkBuyNowCommand { get { return (ICommand?)GetValue(OpenLinkBuyNowCommandProperty); } set { SetValue(OpenLinkBuyNowCommandProperty, value); } }

    static DemoShellRibbon() {
        DependencyPropertyRegistrator<DemoShellRibbon>.New()
            .Register<IReadOnlyList<DemoModuleGroup>?>(nameof(Modules), out ModulesProperty, null)
            .Register<bool>(nameof(ShowApplicationButton), out ShowApplicationButtonProperty, false)
            .Register<Style?>(nameof(RibbonStyle), out RibbonStyleProperty, null, x => x.OnRibbonStyleChanged())
            .Register<bool>(nameof(IsFullWindowModeChecked), out IsFullWindowModeCheckedProperty, false)
            .Register<ICommand?>(nameof(PrevCommand), out PrevCommandProperty, null)
            .Register<ICommand?>(nameof(NextCommand), out NextCommandProperty, null)
            .Register<ICommand<DemoModule>?>(nameof(SelectCommand), out SelectCommandProperty, null)
            .Register<ICommand?>(nameof(OpenLinkGetStartedCommand), out OpenLinkGetStartedCommandProperty, null)
            .Register<ICommand?>(nameof(OpenLinkGetSupportCommand), out OpenLinkGetSupportCommandProperty, null)
            .Register<ICommand?>(nameof(OpenLinkBuyNowCommand), out OpenLinkBuyNowCommandProperty, null);
    }
    public DemoShellRibbon() {
        InitializeComponent();
        UpdateRibbonStyle();
        DependencyPropertyDescriptor.FromProperty(RibbonControlHelper.MergingStatusProperty, typeof(RibbonControl))
            .AddValueChanged(ribbon, OnMergingStatusChanged);
    }
    void OnRibbonStyleChanged() {
        UpdateRibbonStyle();
    }
    void OnMergingStatusChanged(object? sender, EventArgs e) {
        if(lockUpdate)
            return;
        lockUpdate = true;
        Dispatcher.InvokeAsync(() => {
            Update();
            lockUpdate = false;
        });
    }

    void Update() {
        if(ribbon.ActualCategories.SelectMany(x => x.ActualPages).Count() > 2) {
            demoMainPage.IsVisible = false;
            demoPageCategory.IsVisible = true;
        }
        else {
            demoMainPage.IsVisible = true;
            demoPageCategory.IsVisible = false;
        }
    }
    void UpdateRibbonStyle() {
        ribbon.Style = null;
        SetDefaultValues();
        ribbon.Style = RibbonStyle;

        void SetDefaultValues() {
            ribbon.SetCurrentValue(RibbonControl.RibbonStyleProperty, DevExpress.Xpf.Ribbon.RibbonStyle.Office2019);
            ribbon.SetCurrentValue(RibbonControl.HideEmptyGroupsProperty, true);
            ribbon.SetCurrentValue(RibbonControl.AllowCustomizationProperty, false);
            ribbon.SetCurrentValue(RibbonControl.ToolbarShowModeProperty, RibbonQuickAccessToolbarShowMode.ShowAbove);
            ribbon.SetCurrentValue(RibbonControl.PageCategoryAlignmentProperty, RibbonPageCategoryCaptionAlignment.Right);
        }
    }

    bool lockUpdate;
}

public class DemoShellRibbonThemeSelectorBehavior : Behavior<BarSubItem> {
    protected override void OnAttached() {
        base.OnAttached();
        var themeSelector = AssociatedObject;
        PopulateThemeSelector(themeSelector);
        ForEachThemeSelectorItem(themeSelector,
            x => x.CheckedChanged += OnThemeSelectorItemCheckedChanged);
        UpdateThemeSelector();
        ApplicationThemeHelper.ApplicationThemeNameChanged += OnApplicationThemeNameChanged;
    }

    async void OnThemeSelectorItemCheckedChanged(object sender, ItemClickEventArgs e) {
        if(lockOnThemeSelectorItemCheckedChanged)
            return;
        var checkItem = (BarCheckItem)e.Item;
        if(checkItem.IsChecked != true)
            return;
        var theme = e.Item.Tag.ToString();
        await Dispatcher.InvokeAsync(() => {
            ApplicationThemeHelper.ApplicationThemeName = theme;
        });
    }
    void OnApplicationThemeNameChanged(object? sender, ApplicationThemeNameChangedEventArgs e) {
        UpdateThemeSelector();
    }
    void UpdateThemeSelector() {
        var themeSelector = AssociatedObject;
        var theme = ApplicationThemeHelper.ApplicationThemeName;
        if(string.IsNullOrEmpty(theme))
            return;
        themeSelector.Tag = theme;
        themeSelector.Content = LightweightThemeManager.GetTheme(theme).DisplayName;
        themeSelector.Glyph = GetThemeGlyph(theme);
        lockOnThemeSelectorItemCheckedChanged = true;
        ForEachThemeSelectorItem(themeSelector, x => {
            x.IsChecked = x.Tag.ToString() == theme;
        });
        lockOnThemeSelectorItemCheckedChanged = false;
    }

    static void ForEachThemeSelectorItem(BarSubItem themeSelector, Action<BarCheckItem> action) {
        foreach(BarItemMenuHeader headerItem in themeSelector.Items) {
            foreach(var item in headerItem.Items) {
                if(item is BarSubItem subItem) {
                    subItem.Items
                        .OfType<BarCheckItem>()
                        .ForEach(action);
                }
                else {
                    action((BarCheckItem)item);
                }
            }
        }
    }
    static void PopulateThemeSelector(BarSubItem themeSelector) {
        var groups = LightweightThemeManager.Themes.GroupBy(x => x.Category);
        foreach(var group in groups) {
            var item = CreateThemeGroupItem(group.Key, group);
            themeSelector.Items.Add(item);
        }

        static BarItemMenuHeader CreateThemeGroupItem(string themeCategory, IEnumerable<LightweightTheme> themes) {
            var res = new BarItemMenuHeader() { Content = themeCategory };
            if(!DemoRestrictions.IsWindows)
                themes = themes.Where(theme => !theme.Name.Contains("system", StringComparison.OrdinalIgnoreCase));
            foreach(var theme in themes) {
                if(theme.IsPaletteTheme)
                    continue;
                res.Items.Add(CreateThemeItem(theme));
            }
            if(themes.Any(x => x.IsPaletteTheme)) {
                res.Items.Add(CreateThemePaletteItem(themeCategory, themes.Where(x => x.IsPaletteTheme)));
            }
            return res;
        }
        static BarSubItem CreateThemePaletteItem(string themeCategory, IEnumerable<LightweightTheme> paletteThemes) {
            var res = new BarSubItem() { Content = "Palettes" };
            foreach(var theme in paletteThemes) {
                res.Items.Add(CreateThemeItem(theme));
            }
            return res;
        }
        static BarCheckItem CreateThemeItem(LightweightTheme theme) {
            return new BarCheckItem() {
                Tag = theme.Name,
                Content = theme.DisplayName,
                Glyph = GetThemeGlyph(theme),
            };
        }
    }
    static ImageSource? GetThemeGlyph(string themeName) {
        var theme = LightweightThemeManager.GetTheme(themeName);
        return theme != null ? GetThemeGlyph(theme) : null;
    }
    static ImageSource GetThemeGlyph(LightweightTheme theme) {
        var image = SvgImageHelper.CreateImage(theme.SvgGlyph);
        return WpfSvgRenderer.CreateImageSource(image, palette: theme.SvgPalette);
    }

    bool lockOnThemeSelectorItemCheckedChanged;
}