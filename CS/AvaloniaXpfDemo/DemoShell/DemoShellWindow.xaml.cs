using System.Diagnostics;
using System.Runtime.InteropServices;
using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;
using DevExpress.Mvvm;
using DevExpress.Mvvm.UI;
using DevExpress.Mvvm.UI.Native;
using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Core.DragDrop.Native;
using DevExpress.Xpf.Core.Native;

namespace DevExpress.AvaloniaXpfDemo.DemoShell;

public partial class DemoShellWindow : SidebarWindow {
    public static readonly DependencyProperty ModulesProperty;
    public static readonly DependencyProperty SelectedModuleProperty;
    public static readonly DependencyProperty FullWindowModeProperty;
    public static readonly DependencyProperty CommonAreaProperty;

    public IReadOnlyList<DemoModuleGroup>? Modules { get { return (IReadOnlyList<DemoModuleGroup>?)GetValue(ModulesProperty); } set { SetValue(ModulesProperty, value); } }
    public DemoModule? SelectedModule { get { return (DemoModule?)GetValue(SelectedModuleProperty); } set { SetValue(SelectedModuleProperty, value); } }
    public bool FullWindowMode { get { return (bool)GetValue(FullWindowModeProperty); } set { SetValue(FullWindowModeProperty, value); } }
    public FrameworkElement? CommonArea { get { return (FrameworkElement?)GetValue(CommonAreaProperty); } set { SetValue(CommonAreaProperty, value); } }

    public event EventHandler? StartModuleSwitching;
    public event EventHandler? EndModuleSwitching;
    public event EventHandler<ValueEventArgs<DemoModuleView?>>? ModuleUnloading;
    public event EventHandler<ValueEventArgs<DemoModuleView?>>? ModuleUnloaded;
    public event EventHandler<ValueEventArgs<DemoModuleView?>>? ModuleLoading;
    public event EventHandler<ValueEventArgs<DemoModuleView?>>? ModuleLoaded;
    public event EventHandler<ValueEventArgs<DemoModuleView?>>? ModuleCompletelyLoaded;

    public DemoShellWindowCommands Commands { get; }
    bool IsCompletelyLoaded { get; set; }
    DemoShellRibbon? ribbon;
    Decorator? commonAreaPresenter;
    SplashScreenManager splashScreen;
    int splashScreenCounter;

    static DemoShellWindow() {
        DependencyPropertyRegistrator<DemoShellWindow>.New()
            .Register<IReadOnlyList<DemoModuleGroup>?>(nameof(Modules), out ModulesProperty, null, (x, o, n) => x.OnModulesChanged())
            .Register<DemoModule?>(nameof(SelectedModule), out SelectedModuleProperty, null)
            .Register<bool>(nameof(FullWindowMode), out FullWindowModeProperty, false)
            .Register<FrameworkElement?>(nameof(CommonArea), out CommonAreaProperty, null, x => x.OnCommonAreaChanged());
    }
    public DemoShellWindow() {
        Commands = new();
        splashScreen = SplashScreenManager.CreateWaitIndicator();
        InitializeComponent();
        Loaded += OnLoaded;
    }

    public void ShowDemoSplashScreen() {
        splashScreenCounter++;
        if(splashScreenCounter != 1)
            return;
        Mouse.OverrideCursor = Cursors.Wait;
        if(DemoRestrictions.SplashScreen)
            splashScreen.Show(
                owner: contentContainer,
                startupLocation: WindowStartupLocation.CenterOwner,
                trackOwnerPosition: true,
                inputBlock: InputBlockMode.None);
    }
    public void HideDemoSplashScreen() {
        splashScreenCounter--;
        if(splashScreenCounter > 0)
            return;
        splashScreenCounter = 0;
        Mouse.OverrideCursor = Cursors.Arrow;
        if(DemoRestrictions.SplashScreen)
            splashScreen.Close();
    }

    async void OnLoaded(object sender, RoutedEventArgs e) {
        if(IsCompletelyLoaded)
            return;
        IsCompletelyLoaded = true;
        ShowDemoSplashScreen();
        try {
            await Dispatcher.InvokeAsync(() => { }, DispatcherPriority.ContextIdle);
            await Dispatcher.InvokeAsync(() => { }, DispatcherPriority.ContextIdle);
            await Dispatcher.InvokeAsync(() => { }, DispatcherPriority.ContextIdle);
            await Dispatcher.InvokeAsync(CreateRibbon, DispatcherPriority.ContextIdle);
            await Dispatcher.InvokeAsync(CreateCommonAreaPresenter, DispatcherPriority.ContextIdle);
            await Dispatcher.InvokeAsync(() => { }, DispatcherPriority.ContextIdle);
            await Dispatcher.InvokeAsync(() => { }, DispatcherPriority.ContextIdle);
            await Dispatcher.InvokeAsync(CreateContent, DispatcherPriority.ContextIdle);
            await Dispatcher.InvokeAsync(() => { }, DispatcherPriority.ContextIdle);
        }
        finally {
            HideDemoSplashScreen();
        }
    }
    void OnModulesChanged() {
        SelectedModule = Modules?.FirstOrDefault()?.Modules.FirstOrDefault();
    }
    void OnCommonAreaChanged() {
        if(commonAreaPresenter == null)
            return;
        commonAreaPresenter.Child = CommonArea;
    }

    void CreateRibbon() {
        ribbon = new DemoShellRibbon();
        ribbon.SetBinding(DemoShellRibbon.ModulesProperty, new Binding() {
            Path = new PropertyPath(ModulesProperty),
            Source = this
        });
        ribbon.SetBinding(DemoShellRibbon.IsFullWindowModeCheckedProperty, new Binding() {
            Path = new PropertyPath(FullWindowModeProperty),
            Source = this,
            Mode = BindingMode.TwoWay
        });
        ribbon.SetBinding(DemoShellRibbon.PrevCommandProperty, new Binding() {
            Path = new PropertyPath($"{nameof(DemoShellSidebar.Commands)}.{nameof(DemoShellSidebar.Commands.SelectPrev)}"),
            Source = demoSidebar,
        });
        ribbon.SetBinding(DemoShellRibbon.NextCommandProperty, new Binding() {
            Path = new PropertyPath($"{nameof(DemoShellSidebar.Commands)}.{nameof(DemoShellSidebar.Commands.SelectNext)}"),
            Source = demoSidebar,
        });
        ribbon.SetBinding(DemoShellRibbon.SelectCommandProperty, new Binding() {
            Path = new PropertyPath($"{nameof(DemoShellSidebar.Commands)}.{nameof(DemoShellSidebar.Commands.Select)}"),
            Source = demoSidebar,
        });
        ribbon.SetBinding(DemoShellRibbon.OpenLinkGetStartedCommandProperty, new Binding() {
            Path = new PropertyPath($"{nameof(Commands)}.{nameof(Commands.OpenLinkGetStarted)}"),
            Source = this,
        });
        ribbon.SetBinding(DemoShellRibbon.OpenLinkGetSupportCommandProperty, new Binding() {
            Path = new PropertyPath($"{nameof(Commands)}.{nameof(Commands.OpenLinkGetSupport)}"),
            Source = this,
        });
        ribbon.SetBinding(DemoShellRibbon.OpenLinkBuyNowCommandProperty, new Binding() {
            Path = new PropertyPath($"{nameof(Commands)}.{nameof(Commands.OpenLinkBuyNow)}"),
            Source = this,
        });
        ribbonContainer.Children.Add(ribbon);
    }
    void CreateCommonAreaPresenter() {
        commonAreaPresenter = new Decorator();
        MergingProperties.SetElementMergingBehavior(commonAreaPresenter, ElementMergingBehavior.InternalWithExternal);
        commonAreaPresenter.Child = CommonArea;
        commonAreaContainer.Children.Add(commonAreaPresenter);
    }
    void CreateContent() {
        var content = new DemoShellWindowContent();
        content.BeginInit();
        content.SetBinding(DemoShellWindowContent.ShowDescriptionProperty, new Binding() {
            Path = new PropertyPath(FullWindowModeProperty),
            Source = this,
            Converter = new BooleanNegationConverter()
        });
        content.SetBinding(DemoShellWindowContent.SelectedModuleProperty, new Binding() {
            Path = new PropertyPath(SelectedModuleProperty),
            Source = this
        });

        content.StartModuleSwitching += OnStartModuleSwitching;
        content.EndModuleSwitching += OnEndModuleSwitching;
        content.ModuleUnloading += OnModuleUnloading;
        content.ModuleUnloaded += OnModuleUnloaded;
        content.ModuleLoading += OnModuleLoading;
        content.ModuleLoaded += OnModuleLoaded;
        content.ModuleCompletelyLoaded += OnModuleCompletelyLoaded;

        content.EndInit();
        contentContainer.Children.Add(content);

        ribbon?.SetBinding(DemoShellRibbon.ShowApplicationButtonProperty, new Binding() {
            Path = new PropertyPath($"{nameof(DemoShellWindowContent.ModuleView)}.{nameof(DemoModuleView.ShowRibbonApplicationButton)}"),
            Source = content,
        });
        ribbon?.SetBinding(DemoShellRibbon.RibbonStyleProperty, new Binding() {
            Path = new PropertyPath($"{nameof(DemoShellWindowContent.ModuleView)}.{nameof(DemoModuleView.RibbonStyle)}"),
            Source = content,
        });
    }

    void OnStartModuleSwitching(object? sender, EventArgs e) {
        ShowDemoSplashScreen();
        StartModuleSwitching?.Invoke(this, e);
    }
    void OnEndModuleSwitching(object? sender, EventArgs e) {
        HideDemoSplashScreen();
        EndModuleSwitching?.Invoke(this, e);
    }

    void OnModuleUnloading(object? sender, ValueEventArgs<DemoModuleView?> e) {
        ModuleUnloading?.Invoke(this, e);
    }
    void OnModuleUnloaded(object? sender, ValueEventArgs<DemoModuleView?> e) {
        ModuleUnloaded?.Invoke(this, e);
    }
    void OnModuleLoading(object? sender, ValueEventArgs<DemoModuleView?> e) {
        ModuleLoading?.Invoke(this, e);
    }
    void OnModuleLoaded(object? sender, ValueEventArgs<DemoModuleView?> e) {
        ModuleLoaded?.Invoke(this, e);
    }
    void OnModuleCompletelyLoaded(object? sender, ValueEventArgs<DemoModuleView?> e) {
        ModuleCompletelyLoaded?.Invoke(this, e);
    }

    public class DemoShellWindowCommands {
        public ICommand OpenLinkGetStarted { get; }
        public ICommand OpenLinkGetSupport { get; }
        public ICommand OpenLinkBuyNow { get; }

        public DemoShellWindowCommands() {
            OpenLinkGetStarted = new DelegateCommand(DoOpenLinkGetStarted, false);
            OpenLinkGetSupport = new DelegateCommand(DoOpenLinkGetSupport, false);
            OpenLinkBuyNow = new DelegateCommand(DoOpenLinkBuyNow, false);
        }
        private void OpenBrowser(string url) {
            if(RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                DocumentPresenter.OpenLink(url);
            else if(RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                Process.Start("xdg-open", url);
            else if(RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                Process.Start("open", url);
        }
        void DoOpenLinkGetStarted() {
            var url = LinksHelper.GetStarted("Wpf", null);
            OpenBrowser(url);
        }
        void DoOpenLinkGetSupport() {
            var url = LinksHelper.GetSupport("Wpf", null);
            OpenBrowser(url);
        }
        void DoOpenLinkBuyNow() {
            var url = LinksHelper.BuyNow("Wpf", null);
            OpenBrowser(url);
        }
    }
}

public class SidebarWindow : ThemedWindow {
    public static readonly DependencyProperty SidebarProperty;
    public UIElement? Sidebar { get => (UIElement?)GetValue(SidebarProperty); set => SetValue(SidebarProperty, value); }

    static SidebarWindow() {
        DependencyPropertyRegistrator<SidebarWindow>.New()
            .OverrideMetadata(ShowIconProperty, false)
            .Register<UIElement?>(nameof(Sidebar), out SidebarProperty, null, (x, o, n) => x.OnSidebarChanged(o, n))
        ;
    }
    public SidebarWindow() {
        Padding = new Thickness(0);
    }

    public override void OnApplyTemplate() {
        if(root != null && Sidebar != null)
            root.Children.Remove(Sidebar);
        base.OnApplyTemplate();
        root = (DockPanel)GetTemplateChild("PART_WindowHeaderContentAndStatusPanel");
        if(root != null && Sidebar != null)
            OnSidebarChanged(null, Sidebar);
    }

    void OnSidebarChanged(UIElement? o, UIElement? n) {
        if(root == null) return;
        if(o != null)
            root.Children.Remove(o);
        if(n != null) {
            DockPanel.SetDock(n, Dock.Left);
            WindowChrome.SetIsHitTestVisibleInChrome(n, true);
            root.Children.Insert(0, n);
        }
    }

    DockPanel? root;
}