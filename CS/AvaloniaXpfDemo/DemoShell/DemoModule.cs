using System.ComponentModel;

namespace DevExpress.AvaloniaXpfDemo.DemoShell;

public class DemoModuleGroup : INotifyPropertyChanged {
    public string Name { get; }
    public bool IsGroup { get => true; }
    public IReadOnlyList<DemoModule> Modules { get; }
    
    public DemoModuleGroup(string name, IReadOnlyList<DemoModule> modules) {
        Name = name;
        Modules = modules;
    }
    event PropertyChangedEventHandler? INotifyPropertyChanged.PropertyChanged { add { } remove { } }
}

public class DemoModule : INotifyPropertyChanged {
    public string Name { get; }
    public string Description { get; }
    public bool IsGroup { get => false; }
    public Func<DemoModuleView> CreateModuleView { get; }

    public DemoModule(string name, string description, Func<DemoModuleView> createModuleView) {
        Name = name;
        Description = description;
        CreateModuleView = createModuleView;
    }

    event PropertyChangedEventHandler? INotifyPropertyChanged.PropertyChanged { add { } remove { } }
}