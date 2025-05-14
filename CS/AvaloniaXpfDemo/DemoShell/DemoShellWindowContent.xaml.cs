using System.Windows.Media;
using System.Windows.Threading;
using DevExpress.Mvvm.UI.Native;
using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Ribbon;
using static DevExpress.AvaloniaXpfDemo.DemoShell.DemoModuleView;

namespace DevExpress.AvaloniaXpfDemo.DemoShell;

public partial class DemoShellWindowContent : Grid {
    public static readonly DependencyProperty SelectedModuleProperty;
    public static readonly DependencyProperty ShowDescriptionProperty;
    public static readonly DependencyProperty ModuleViewProperty;
    static readonly DependencyPropertyKey ModuleViewPropertyKey;
    public DemoModule? SelectedModule { get { return (DemoModule?)GetValue(SelectedModuleProperty); } set { SetValue(SelectedModuleProperty, value); } }
    public bool ShowDescription { get { return (bool)GetValue(ShowDescriptionProperty); } set { SetValue(ShowDescriptionProperty, value); } }
    public DemoModuleView? ModuleView { get { return (DemoModuleView?)GetValue(ModuleViewProperty); } private set { SetValue(ModuleViewPropertyKey, value); } }

    public event EventHandler? StartModuleSwitching;
    public event EventHandler? EndModuleSwitching;
    public event EventHandler<ValueEventArgs<DemoModuleView?>>? ModuleUnloading;
    public event EventHandler<ValueEventArgs<DemoModuleView?>>? ModuleUnloaded;
    public event EventHandler<ValueEventArgs<DemoModuleView?>>? ModuleLoading;
    public event EventHandler<ValueEventArgs<DemoModuleView?>>? ModuleLoaded;
    public event EventHandler<ValueEventArgs<DemoModuleView?>>? ModuleCompletelyLoaded;

    DemoShellModulePresenter CurrentPresenter { get; set; }
    DemoShellModulePresenter NextPresenter { get; set; }

    static DemoShellWindowContent() {
        DependencyPropertyRegistrator<DemoShellWindowContent>.New()
            .Register<DemoModule?>(nameof(SelectedModule), out SelectedModuleProperty, null, (x, o, n) => x.OnSelectedModuleChanged())
            .Register<bool>(nameof(ShowDescription), out ShowDescriptionProperty, true)
            .RegisterReadOnly<DemoModuleView?>(nameof(ModuleView), out ModuleViewPropertyKey, out ModuleViewProperty, null);
    }
    public DemoShellWindowContent() {
        InitializeComponent();
        CurrentPresenter = PART_CurentModulePresenter;
        NextPresenter = PART_NextModulePresenter;
        CurrentPresenter.RenderTransform = new ScaleTransform();
        NextPresenter.RenderTransform = new ScaleTransform();
        CurrentPresenter.RenderTransformOrigin = new Point(0.5, 0.5);
        NextPresenter.RenderTransformOrigin = new Point(0.5, 0.5);
        Unloaded += OnUnloaded;
    }
    void OnUnloaded(object sender, RoutedEventArgs e) {
        CancelAnimation();
    }
    void OnSelectedModuleChanged() {
        UpdateSelectedModule();
    }

    async void UpdateSelectedModule() {
        if(switchingModuleInProgress)
            return;
        try {
            switchingModuleInProgress = true;
            OnStartModuleSwitching();
            await UpdateSelectedModuleCore();
        }
        finally {
            switchingModuleInProgress = false;
            OnEndModuleSwitching();
        }

        async Task UpdateSelectedModuleCore() {
            while(selectedModuleCore != SelectedModule) {
                selectedModuleCore = SelectedModule;
                await SwitchModuleAsync(SelectedModule, IsLoaded);
            }
        }
    }
    async Task SwitchModuleAsync(DemoModule? module, bool allowAnimation) {
        if(CurrentPresenter.ModuleView == null && string.IsNullOrEmpty(CurrentPresenter.Error))
            allowAnimation = false;
        if(!allowAnimation) {
            var oldModuleView = CurrentPresenter.ModuleView;
            OnModuleUnloading(oldModuleView);

            SetContent(CurrentPresenter, module);
            var newModuleView = CurrentPresenter.ModuleView;
            if(newModuleView != null) {
                await AsyncHelper.Wait(newModuleView, DispatcherPriority.Loaded);
                await AsyncHelper.Wait(newModuleView, DispatcherPriority.ContextIdle);
            }
            OnModuleLoaded(newModuleView);

            OnModuleUnloaded(oldModuleView);
            OnModuleCompletelyLoaded(newModuleView);
        }
        else {
            var oldModuleView = CurrentPresenter.ModuleView;
            if(oldModuleView != null)
                OnModuleUnloading(oldModuleView);

            SetContent(NextPresenter, module);
            SetProperties(NextPresenter, Visibility.Visible, 0, 1);
            var newModuleView = NextPresenter.ModuleView;
            if(newModuleView != null) {
                await AsyncHelper.Wait(newModuleView, DispatcherPriority.Loaded);
                await AsyncHelper.Wait(newModuleView, DispatcherPriority.ContextIdle);
            }
            OnModuleLoaded(newModuleView);
            await AnimateAsync(newModuleView);

            OnModuleUnloaded(oldModuleView);
            OnModuleCompletelyLoaded(newModuleView);
        }
    }
    async Task AnimateAsync(DemoModuleView? nextModule) {
        animationCTS = new CancellationTokenSource();
        var ct = animationCTS.Token;

        CurrentPresenter.CacheMode = new BitmapCache();
        NextPresenter.CacheMode = new BitmapCache();

        var maxSize = Math.Max(ActualWidth, ActualHeight);
        var targetSize = Math.Max(1, maxSize - 60);
        double animationScale = targetSize / maxSize;
        animationScale = Math.Min(1, Math.Max(0.92, animationScale));
        double animationOpacity = 0.2;
        TimeSpan duration = TimeSpan.FromMilliseconds(250);

        await AsyncHelper.Animate(
            this,
            x => {
                var opacity = AsyncHelper.Interpolate(from: 1, to: animationOpacity, x);
                var scale = AsyncHelper.Interpolate(from: 1, to: animationScale, x);
                SetProperties(CurrentPresenter, Visibility.Visible, opacity, scale);
            },
            duration,
            null,
            ct);
        SetProperties(CurrentPresenter, Visibility.Collapsed, 0, 1);

        await AsyncHelper.Animate(
            this,
            x => {
                var opacity = AsyncHelper.Interpolate(from: animationOpacity, to: 1, x);
                var scale = AsyncHelper.Interpolate(from: animationScale, to: 1, x);
                SetProperties(NextPresenter, Visibility.Visible, opacity, scale);
            },
            duration,
            null,
            ct);
        SetProperties(NextPresenter, Visibility.Visible, 1, 1);

        CurrentPresenter.CacheMode = null;
        NextPresenter.CacheMode = null;

        SetContent(CurrentPresenter, null);
        var buf = CurrentPresenter;
        CurrentPresenter = NextPresenter;
        NextPresenter = buf;
        Canvas.SetZIndex(NextPresenter, 1);
        Canvas.SetZIndex(CurrentPresenter, 0);
    }
    void CancelAnimation() {
        animationCTS?.Cancel();
    }

    void SetContent(DemoShellModulePresenter presenter, DemoModule? module) {
        presenter.SetModule(module, () => OnModuleLoading(presenter.ModuleView));
    }
    void SetProperties(DemoShellModulePresenter presenter, Visibility visibility, double opacity, double scale) {
        presenter.Visibility = visibility;
        presenter.Opacity = opacity;
        var t = (ScaleTransform)presenter.RenderTransform;
        t.ScaleX = scale;
        t.ScaleY = scale;
    }

    void OnStartModuleSwitching() => StartModuleSwitching?.Invoke(this, EventArgs.Empty);
    void OnEndModuleSwitching() => EndModuleSwitching?.Invoke(this, EventArgs.Empty);

    void OnModuleUnloading(DemoModuleView? moduleView) {
        try {
            if(moduleView == null)
                return;
            MergingProperties.SetElementMergingBehavior(moduleView, ElementMergingBehavior.Undefined);
            RibbonMergingHelper.SetMergeWith(moduleView, new RibbonControl());
            ((IDemoModuleView)moduleView).OnModuleUnloading();
            ModuleView = null;
        }
        finally {
            ModuleUnloading?.Invoke(this, new ValueEventArgs<DemoModuleView?>(moduleView));
        }
    }
    void OnModuleUnloaded(DemoModuleView? moduleView) {
        try {
            if(moduleView == null)
                return;
            ((IDemoModuleView)moduleView).OnModuleUnloaded();
        }
        finally {
            ModuleUnloaded?.Invoke(this, new ValueEventArgs<DemoModuleView?>(moduleView));
        }
    }
    void OnModuleLoading(DemoModuleView? moduleView) {
        try {
            if(moduleView == null)
                return;
            MergingProperties.SetElementMergingBehavior(moduleView, ElementMergingBehavior.InternalWithExternal);
        }
        finally {
            ModuleLoading?.Invoke(this, new ValueEventArgs<DemoModuleView?>(moduleView));
        }
    }
    void OnModuleLoaded(DemoModuleView? moduleView) {
        try {
            if(moduleView == null)
                return;
            ((IDemoModuleView)moduleView).OnModuleLoaded();
            ModuleView = moduleView;
        }
        finally {
            ModuleLoaded?.Invoke(this, new ValueEventArgs<DemoModuleView?>(moduleView));
        }
    }
    void OnModuleCompletelyLoaded(DemoModuleView? moduleView) {
        try {
            if(moduleView == null)
                return;
            ((IDemoModuleView)moduleView).OnModuleCompletelyLoaded();
        }
        finally {
            ModuleCompletelyLoaded?.Invoke(this, new ValueEventArgs<DemoModuleView?>(moduleView));
        }
    }

    DemoModule? selectedModuleCore;
    bool switchingModuleInProgress;
    CancellationTokenSource? animationCTS;
}
