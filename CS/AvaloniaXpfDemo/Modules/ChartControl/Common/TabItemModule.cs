#nullable disable
using DevExpress.Mvvm.UI;
using DevExpress.Xpf.Charts;
using DevExpress.Xpf.Core;
using System.ComponentModel;

namespace DevExpress.AvaloniaXpfDemo.ChartControlModules;

public class TabItemModule : UserControl {
    public static readonly DependencyProperty OptionsProperty =
        DependencyProperty.Register("Options", typeof(StackPanel), typeof(TabItemModule), new PropertyMetadata(null));
    public static readonly DependencyProperty ActiveChartProperty =
        DependencyProperty.Register("ActiveChart", typeof(ChartControlBase), typeof(TabItemModule), new PropertyMetadata(null));
    public static readonly DependencyProperty IsModuleLoadedProperty =
        DependencyProperty.Register("IsModuleLoaded", typeof(bool), typeof(TabItemModule), new PropertyMetadata(false));

    public virtual bool IsAnimationCompleted {
        get {
            return true;
        }
    }
    public StackPanel Options {
        get { return (StackPanel)GetValue(OptionsProperty); }
        set { SetValue(OptionsProperty, value); }
    }
    public ChartControlBase ActiveChart {
        get { return (ChartControlBase)GetValue(ActiveChartProperty); }
        set { SetValue(ActiveChartProperty, value); }
    }
    public bool IsModuleLoaded {
        get { return (bool)GetValue(IsModuleLoadedProperty); }
        set { SetValue(IsModuleLoadedProperty, value); }
    }

    public TabItemModule() {
        Loaded += OnLoaded;
    }
    public override void OnApplyTemplate() {
        base.OnApplyTemplate();
        IEnumerable<DependencyObject> charts = LayoutTreeHelper.GetLogicalChildren(this).Where((c) => c is ChartControlBase);
        if(charts.Count() == 1)
            ActiveChart = (ChartControlBase)charts.First();
        else
            throw new NotSupportedException("TabbedItemModule must contain single ChartControl");
        if(DesignerProperties.GetIsInDesignMode(this)) {
            ScrollViewer scrollViewer = new ScrollViewer();
            scrollViewer.Content = Options;
            DockPanel moduleRoot = (DockPanel)LayoutTreeHelper.GetLogicalChildren(this).Where((c) => c is DockPanel).FirstOrDefault();
            if(moduleRoot != null) {
                moduleRoot.Children.Insert(0, scrollViewer);
                DockPanel.SetDock(scrollViewer, Dock.Right);
            }
            else {
                throw new NotSupportedException("TabbedItemModule must contain a DockPanel as its content root");
            }
        }
    }
    protected virtual void OnSelected() { }

    void OnLoaded(object sender, RoutedEventArgs e) {
        var tab = Parent as DXTabItem;
        if(tab == null)
            throw new InvalidOperationException("Cannot find owner DXTabItem");
        var tabControl = tab.Owner;
        tabControl.SelectionChanged += OnTabControlSelectionChanged;
        OnTabControlSelectionChanged(tabControl, null);
    }
    void OnTabControlSelectionChanged(object sender, TabControlSelectionChangedEventArgs e) {
        var tabControl = (DXTabControl)sender;
        var selectedTab = tabControl.SelectedContainer;
        if(selectedTab == Parent)
            OnSelected();
    }
}