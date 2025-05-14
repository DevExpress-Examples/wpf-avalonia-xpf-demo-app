using System.ComponentModel;
using System.Windows.Input;
using DevExpress.Mvvm;
using DevExpress.Mvvm.UI.Native;
using DevExpress.Xpf.Accordion;

namespace DevExpress.AvaloniaXpfDemo.DemoShell;

public partial class DemoShellSidebar : Grid {
    public static readonly DependencyProperty ModulesProperty;
    public static readonly DependencyProperty SelectedModuleProperty;
    public IReadOnlyList<DemoModuleGroup>? Modules { get { return (IReadOnlyList<DemoModuleGroup>?)GetValue(ModulesProperty); } set { SetValue(ModulesProperty, value); } }
    public DemoModule? SelectedModule { get { return (DemoModule?)GetValue(SelectedModuleProperty); } set { SetValue(SelectedModuleProperty, value); } }

    public DemoShellSidebarCommands Commands { get; }

    static DemoShellSidebar() {
        DependencyPropertyRegistrator<DemoShellSidebar>.New()
            .OverrideMetadata(WidthProperty, 219d)
            .Register<IReadOnlyList<DemoModuleGroup>?>(nameof(Modules), out ModulesProperty, null, (x, o, n) => x.OnModulesChanged())
            .Register<DemoModule?>(nameof(SelectedModule), out SelectedModuleProperty, null, (x, o, n) => x.OnSelectedModuleChanged());
    }
    public DemoShellSidebar() {
        Commands = new(this);
        InitializeComponent();
        accordion.SelectedItemChanged += OnAccordionSelectedItemChanged;
        accordion.CustomItemFilter += OnAccordionCustomItemFilter;
        DependencyPropertyDescriptor.FromProperty(AccordionControl.SearchTextProperty, typeof(AccordionControl))
            .AddValueChanged(accordion, OnAccordionSearchTextChanged);
    }

    void OnModulesChanged() {
        accordion.ItemsSource = Modules;
    }
    void OnSelectedModuleChanged() {
        accordion.SelectedItem = SelectedModule;
    }
    void OnAccordionSelectedItemChanged(object? sender, AccordionSelectedItemChangedEventArgs e) {
        var selection = e.NewItem as DemoModule;
        if(selection != null)
            SelectedModule = selection;
    }
    void OnAccordionCustomItemFilter(object? sender, AccordionCustomItemFilterEventArgs e) {
        var searchStrings = GetSearchStrings(e.SearchText);
        e.Accepted = IsDemoModuleVisible(e.Item, searchStrings);
        e.Handled = true;
    }
    void OnAccordionSearchTextChanged(object? sender, EventArgs e) {
        UpdateSelectionAsync();
    }

    async void UpdateSelectionAsync() {
        if(lockUpdateSelectionAsync) return;
        lockUpdateSelectionAsync = true;

        await Dispatcher.InvokeAsync(() => {
            if(SelectedModule == null || accordion.SelectedItem != null)
                return;
            var searchStrings = GetSearchStrings(accordion.SearchText);
            if(IsDemoModuleVisible(SelectedModule, searchStrings))
                accordion.SelectedItem = SelectedModule;
            lockUpdateSelectionAsync = false;
        });
    }
    bool lockUpdateSelectionAsync;

    string[]? GetSearchStrings(string? searchText) {
        searchText = searchText?.Trim();
        if(string.IsNullOrEmpty(searchText))
            return null;
        return searchText
              .Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
              .Select(x => x.ToLowerInvariant())
              .ToArray();
    }
    bool IsDemoModuleVisible(object demoModuleOrGroup, string[]? searchStrings) {
        if(searchStrings == null || searchStrings.Length == 0)
            return true;
        if(demoModuleOrGroup is DemoModuleGroup group) {
            var name = group.Name.ToLowerInvariant();
            return searchStrings.Any(x => name.Contains(x));
        }
        if(demoModuleOrGroup is DemoModule module) {
            var name = module.Name.ToLowerInvariant();
            return searchStrings.Any(x => name.Contains(x));
        }
        return false;
    }

    public class DemoShellSidebarCommands {
        public ICommand SelectPrev { get; }
        public ICommand SelectNext { get; }
        public ICommand<DemoModule> Select { get; }

        DemoShellSidebar owner;
        public DemoShellSidebarCommands(DemoShellSidebar owner) {
            this.owner = owner;
            SelectPrev = new DelegateCommand(() => ShowPrevNext(false), false);
            SelectNext = new DelegateCommand(() => ShowPrevNext(true), false);
            Select = new DelegateCommand<DemoModule>(x => owner.SetCurrentValue(DemoShellSidebar.SelectedModuleProperty, x), false);
        }

        void ShowPrevNext(bool next) {
            var selectedModule = owner.SelectedModule;
            if(selectedModule == null || owner.Modules == null)
                return;
            var searchText = owner.accordion.SearchText;
            var searchStrings = owner.GetSearchStrings(searchText);
            var modules = next
                ? owner.Modules
                    .SelectMany(x => x.Modules)
                : owner.Modules
                    .SelectMany(x => x.Modules)
                    .Reverse();
            var nextModule = modules
                .SkipWhile(x => x != selectedModule)
                .Skip(1)
                .FirstOrDefault(x => owner.IsDemoModuleVisible(x, searchStrings));
            if(nextModule != null)
                owner.SetCurrentValue(DemoShellSidebar.SelectedModuleProperty, nextModule);
        }
    }
}
