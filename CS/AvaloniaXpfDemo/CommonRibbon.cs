using DevExpress.AvaloniaXpfDemo.ChartControlModules;
using DevExpress.AvaloniaXpfDemo.DataGridModules;
using DevExpress.AvaloniaXpfDemo.DiagramControlModules;
using DevExpress.AvaloniaXpfDemo.GanttControlModules;
using DevExpress.AvaloniaXpfDemo.PivotGridModules;
using DevExpress.AvaloniaXpfDemo.TreeListModules;
using DevExpress.AvaloniaXpfDemo.SchedulerControlModules;
using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Charts;
using DevExpress.Xpf.Diagram;
using DevExpress.Xpf.Gantt;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.PivotGrid;
using DevExpress.Xpf.Scheduling;

namespace DevExpress.AvaloniaXpfDemo;

public class CommonRibbon : Grid {
    public void InitGridRibbon(GridControl grid) {
        Clear(grid: false);
        InitCore(ref gridRibbon);
        gridRibbon!.ExportGrid = grid;
    }
    public void InitTreeListRibbon(TreeListControl treeList) {
        Clear(treeList: false);
        InitCore(ref treeListRibbon);
        treeListRibbon!.ExportTreeList = treeList;
    }
    public void InitDiagramRibbon(DiagramDesignerControl diagram) {
        Clear(diagram: false);
        InitCore(ref diagramRibbon);
        diagramRibbon!.DiagramControl = diagram;
    }
    public void InitGanttRibbon(GanttControl gantt) {
        Clear(gantt: false);
        InitCore(ref ganttRibbon);
        ganttRibbon!.ExportGantt = gantt;
    }
    public void InitChartsRibbon(ChartControlBase chart, bool showPaletteButton = true, bool showRunChartDesignerButton = false) {
        Clear(charts: false);
        InitCore(ref chartsRibbon);
        chartsRibbon!.Init(chart, showPaletteButton, showRunChartDesignerButton);
    }
    public void InitPivotRibbon(PivotGridControl grid) {
        Clear(pivot: false);
        InitCore(ref pivotRibbon);
        pivotRibbon!.ExportPivotGrid = grid;
    }
    public void InitSchedulerRibbon(SchedulerControl scheduler) {
        Clear(scheduler: false);
        InitCore(ref schedulerRibbon);
        schedulerRibbon!.Init(scheduler);
        schedulerRibbon!.ShowPageGroupShare = true;
    }
    public void Clear(bool grid = true, bool treeList = true, bool diagram = true, bool gantt = true, bool charts = true, bool pivot = true, bool scheduler = true) {
        if(grid && gridRibbon != null) {
            ClearCore(gridRibbon);
            gridRibbon.ExportGrid = null;
        }
        if(treeList && treeListRibbon != null) {
            ClearCore(treeListRibbon);
            treeListRibbon.ExportTreeList = null;
        }
        if(diagram && diagramRibbon != null) {
            ClearCore(diagramRibbon);
            diagramRibbon.DiagramControl = null;
        }
        if(gantt && ganttRibbon != null) {
            ClearCore(ganttRibbon);
            ganttRibbon.ExportGantt = null;
        }
        if(charts && chartsRibbon != null) {
            ClearCore(chartsRibbon);
            chartsRibbon.Clear();
        }
        if(pivot && pivotRibbon != null) {
            ClearCore(pivotRibbon);
            pivotRibbon.ExportPivotGrid = null;
        }
        if(scheduler && schedulerRibbon != null) {
            ClearCore(schedulerRibbon);
        }
    }

    void InitCore<T>(ref T? ribbon) where T : FrameworkElement, new () {
        if(ribbon == null) {
            ribbon = new();
            Children.Add(ribbon);
        }
        ribbon.Visibility = Visibility.Visible;
        MergingProperties.SetElementMergingBehavior(ribbon, ElementMergingBehavior.InternalWithExternal);
    }
    void ClearCore(FrameworkElement ribbon) {
        ribbon.Visibility = Visibility.Collapsed;
        MergingProperties.SetElementMergingBehavior(ribbon, ElementMergingBehavior.None);
    }

    GridDemoRibbon? gridRibbon;
    TreeListDemoRibbon? treeListRibbon;
    DiagramDemoRibbon? diagramRibbon;
    GanttDemoRibbon? ganttRibbon;
    ChartsDemoRibbon? chartsRibbon;
    PivotGridDemoRibbon? pivotRibbon;
    SchedulerDemoRibbon? schedulerRibbon;
}
