using DevExpress.AvaloniaXpfDemo.DemoShell;

namespace DevExpress.AvaloniaXpfDemo;

public static class DemoModules {
    public static IReadOnlyList<DemoModuleGroup> Groups { get; }

    static DemoModules() {
        Groups = new List<DemoModuleGroup>() {
            new DemoModuleGroup("Data Grid", DataGridModules),
            new DemoModuleGroup("Multi-Column Tree View", TreeListModules),
            new DemoModuleGroup("Dock and Layout Manager", DockLayoutModules),
            new DemoModuleGroup("Data Editors", DataEditorsModules),
            new DemoModuleGroup("Navigation", NavigationModules),
            new DemoModuleGroup("Chart Control", ChartControlModules),
            new DemoModuleGroup("Pivot Grid", PivotGridModules),
            new DemoModuleGroup("Map Control", MapControlModules),
            new DemoModuleGroup("Diagram Control", DiagramControlModules),
            new DemoModuleGroup("Gantt Control", GanttModules),
            new DemoModuleGroup("Scheduler Control", SchedulerControlModules)
        };
    }
    static readonly List<DemoModule> DataGridModules = [
        new DemoModule(
            "Excel Style Filtering",
            @"<Paragraph>
                This example demonstrates the Excel-inspired filter popup mode for grid columns. The tabbed UI used to enter filters in column filter popups is optimized for different data types. Filter criteria can be created by selecting from among all available values, and using a set of filter operators (Equals, Between, Contains, etc.).
            </Paragraph>",
            () => new DevExpress.AvaloniaXpfDemo.DataGridModules.ExcelStyleFilteringDemo()),
        new DemoModule(
            "Mater-Detail View",
            @"<Paragraph>
                In this demo, you will learn how to display master-detail data using the <Bold>GridControl</Bold>’s build-in functionality. To access detail sections, use the expand-collapse buttons displayed within master rows.
            </Paragraph>",
            () => new DevExpress.AvaloniaXpfDemo.DataGridModules.MasterDetailDemo()),
        new DemoModule(
            "Card View Custom Templates",
            @"<Paragraph>
                This demo illustrates the customization options available to you when using card templates to create unique data presentation styles.
            </Paragraph>
            <Paragraph>
                If card contents are defined using the <Bold>Default</Bold> template, card data members are sorted in the same order as the columns in the expandable columns window. Changing this order causes the card data members to be reordered.
            </Paragraph>",
            () => new DevExpress.AvaloniaXpfDemo.DataGridModules.CardTemplatesDemo()),
        new DemoModule(
            "Conditional Formatting",
            @"<Paragraph>
                The <Bold>GridControl</Bold> allows you to apply conditional formatting and change the appearance of individual cells and row based on specific conditions.
            </Paragraph>
            <Paragraph>
                To apply or remove a conditional format for a column, select the Conditional Formatting item in the column context menu. You can either call a formatting dialog specific to the column for which the menu is called, or click Manage Rules to invoke the Conditional Formatting Rules Manager.
            </Paragraph>",
            () => new DevExpress.AvaloniaXpfDemo.DataGridModules.ConditionalFormattingDemo()),
    ];
    static readonly List<DemoModule> TreeListModules = [
        new DemoModule(
            "Tree Structure Editing",
            @"<Paragraph>
                In this demo, you can change the selected node position using the <Bold>Indent Selected Nodes</Bold> and <Bold>Outdent Selected Node</Bold> buttons. These buttons call the <Bold>IndentSelectedNodes</Bold> and <Bold>OutdentSelectedNodes</Bold> TreeList commands respectively. 
            </Paragraph>
            <Paragraph>
                To change the position of a column that displays tree's indents, you need to set TreeView's <Bold>TreeColumnFieldName</Bold> property to the field name of the required column.
            </Paragraph>",
            () => new DevExpress.AvaloniaXpfDemo.TreeListModules.TreeStructureEditingDemo()),
    ];
    static readonly List<DemoModule> DockLayoutModules = [
        new DemoModule(
            "Dock Layout",
            @"<Paragraph>
            This demo illustrates the docking capabilities of dock panels. You can drag and drop dock panels, docking them to the dock container or other dock panels. Press CTRL+TAB to invoke the Document Selector window, allowing you to easily switch to a specific panel or document.
            </Paragraph>",
            () => new DockingModules.DockLayout())
        ];
    static readonly List<DemoModule> DataEditorsModules = [
        new DemoModule(
            "Contact Details",
            "",
            () => new DevExpress.AvaloniaXpfDemo.DataEditorsModules.ContactDetailsDemo()),
    ];
    static readonly List<DemoModule> NavigationModules = [
        new DemoModule(
            "Accordion Control",
            @"<Paragraph>
                In this demo, the <Bold>Accordion</Bold> control provides employee navigation.
            </Paragraph>
            <Paragraph>
                The integrated search field can be used to quickly locate the required information.
            </Paragraph>",
            () => new DevExpress.AvaloniaXpfDemo.AccordionControlModules.DataBindingDemo()),
        new DemoModule(
            "Ribbon UI",
            @"<Paragraph>
                This example demonstrates use of the <Bold>DevExpress WPF Ribbon Control</Bold> to implement text editing commands. You can select text within the editing region to see the <Bold>Ribbon</Bold>'s contextual tabs in action. In this demo, the <Bold>Ribbon</Bold> functions in <Bold>simplified mode</Bold>.
            </Paragraph>",
            () => new DevExpress.AvaloniaXpfDemo.RibbonControlModules.RibbonSimplePadDemo()),
        new DemoModule(
            "Menu, Toolbar & Status Bar UI",
            @"<Paragraph>
                A demo application that demonstrates the Toolbar and Menu system providing commands for a simple text editor.
            </Paragraph>
            <Paragraph>
                In this demo, the <Span FontWeight=""Bold"">DevExpress Toolbar and Menu library</Span> is used to implement text editing commands in a simple text editor. Practice using bar commands to control the appearance of the editor's text.
            </Paragraph>",
            () => new DevExpress.AvaloniaXpfDemo.ToolbarsModules.SimplePadDemo()),
        new DemoModule(
            "Context Menu",
            @"<Paragraph>
                The DevExpress WPF Context (Popup) Menu offers numerous customization options including the ability to control item orientation and the pointing device button used to display the context menu itself. Use the options pane within this demo to control the appearance/behaviors of the context menu.
            </Paragraph>",
            () => new DevExpress.AvaloniaXpfDemo.ToolbarsModules.ContextMenuDemo()),
    ];
    static readonly List<DemoModule> ChartControlModules = [
        new DemoModule(
            "Bars",
            @"<Paragraph>
                This demo shows all bar series types that the Chart Control ships: Side-by-Side, Stacked, Range, etc. 
                Demo tabs allow you to switch between series types, and the Options panel contains generic series settings.
            </Paragraph>",
            () => new DevExpress.AvaloniaXpfDemo.ChartControlModules.BarsDemo()),
        new DemoModule(
            "Lines",
            @"<Paragraph>
                This demo contains all line series types that the Chart Control includes: Line, Spline, Stacked line, etc. 
                Demo tabs allow you to switch between series types, and the Options panel shows generic series settings.
            </Paragraph>",
            () => new DevExpress.AvaloniaXpfDemo.ChartControlModules.LinesDemo()),
        new DemoModule(
            "Areas",
            @"<Paragraph>
                This demo contains all area series types that the Chart Control ships: Area, Spline area, Stacked area, etc.
                Demo tabs allow you to switch between series types, and the Options panel shows generic series settings.
            </Paragraph>",
            () => new DevExpress.AvaloniaXpfDemo.ChartControlModules.AreasDemo()),
        new DemoModule(
            "Pies, Donuts and Funnels",
            @"<Paragraph>
                This demo illustrates the Chart's series types that display data as Pie, Donut or Funnel charts.
                Demo tabs allow you to switch between series types, and the Options panel provides generic series settings.
            </Paragraph>",
            () => new DevExpress.AvaloniaXpfDemo.ChartControlModules.PiesDonutsAndFunnelsDemo()),
    ];
    static readonly List<DemoModule> PivotGridModules = [
        new DemoModule(
            "Excel Style Filtering",
            @"<Paragraph>
                This example demonstrates the Excel-inspired filter drop-downs.
                Click the field's filter icon to invoke the Excel-style drop-down filter element. When the filter applies, its criteria are displayed in the <Bold>Filter Panel</Bold>. Click Edit Filter in the <Bold>Filter Panel</Bold> to invoke the <Bold>Filter Editor</Bold> that enables you to specify complex filter criteria.
            </Paragraph>",
            () => new DevExpress.AvaloniaXpfDemo.PivotGridModules.ExcelStyleFilteringDemo()),
    ];
    static readonly List<DemoModule> MapControlModules = [
        new DemoModule(
            "Gpx Data Adapter",
            @"<Paragraph> 
                This example loads and visualizes data from a GPX file. GPX files can store information about waypoints and routes. 
                In this demo, a map polyline depicts a runner's track. The monitoring chart at the bottom displays various metrics, such heart rate and speed. 
                When you move the cursor over the chart, the marker on the map displays the runner's position. 
                In this demo, you can also use a ruler on the Measurements toolbar to measure distances on the map.
            </Paragraph>",
            () => new DevExpress.AvaloniaXpfDemo.MapControlModules.GpxDataAdapterDemo()),
    ];
    static readonly List<DemoModule> DiagramControlModules = [
        new DemoModule(
            "Shapes",
            @"<Paragraph>
                This module demonstrates various shapes and shape modification capabilies.
            </Paragraph>",
            () => new DevExpress.AvaloniaXpfDemo.DiagramControlModules.ShapesDemo()),
    ];
    static readonly List<DemoModule> GanttModules = [
        new DemoModule(
            "Startup Plan",
            @"<Paragraph>
                This demo illustrates the Gantt Control. The control supports the base Gantt chart functionality: tasks and task dependencies, baselines, milestones, nonworking time rules, strip lines, and highlighted task groups.
            </Paragraph>
            <Paragraph>
                The Gantt area supports interactive data editing. You can drag and resize tasks to change start dates and durations, modify progress, and attach or detach connectors to define predecessor links.
            </Paragraph>",
            () => new DevExpress.AvaloniaXpfDemo.GanttControlModules.StartupPlanDemo()),
    ];
    static readonly List<DemoModule> SchedulerControlModules = [
        new DemoModule(
            "Employee Work Schedule",
            @"<Paragraph> 
                This demo helps illustrate the UI flexibility at the heart of the DevExpress WPF Scheduler control. 
                Much like Microsoft Outlook, our Scheduler control allows you to display multiple schedules (resources) simultaneously. 
                Editing, drag &amp; drop, and clipboard operations are fully supported. 
            </Paragraph>
            <Paragraph>
                In this sample, the employee resource tree controls the schedules displayed on-screen. 
                The date navigator above the resource tree allows you to specify the desired date range.
            </Paragraph>",
            () => new DevExpress.AvaloniaXpfDemo.SchedulerControlModules.EmployeeWorkScheduleDemo()),
    ];
}