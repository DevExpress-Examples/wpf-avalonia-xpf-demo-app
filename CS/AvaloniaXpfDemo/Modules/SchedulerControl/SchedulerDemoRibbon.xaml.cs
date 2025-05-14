using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Scheduling;
using System.Windows.Controls;
using System.Windows.Threading;

namespace DevExpress.AvaloniaXpfDemo.SchedulerControlModules;

public partial class SchedulerDemoRibbon : UserControl {
    public bool ShowPageHome { get; set; }
    public bool ShowPageGroupShare { get; set; }

    bool lockApplyState;
    public SchedulerDemoRibbon() {
        ClearState();
        InitializeComponent();
        this.print.IsEnabled = DemoRestrictions.Scheduler.Print;
    }
    public void Init(SchedulerControl scheduler) {
        lockApplyState = true;
        ClearState();

        if(scheduler == null) {
            MergingProperties.SetElementMergingBehavior(this, ElementMergingBehavior.None);
            Visibility = System.Windows.Visibility.Collapsed;
        } else {
            MergingProperties.SetElementMergingBehavior(this, ElementMergingBehavior.InternalWithExternal);
            Visibility = System.Windows.Visibility.Visible;
        }

        var oldScheduler = SchedulerControl.GetScheduler(this);
        if(oldScheduler == null) {
            SchedulerControl.SetScheduler(this, scheduler);
        }

        Dispatcher.InvokeAsync(() => {
            SchedulerControl.SetScheduler(this, scheduler);
            lockApplyState = false;
            ApplyState();
        }, DispatcherPriority.Loaded);
    }
    public void Update() {
        ApplyState();
    }

    void ClearState() {
        ShowPageHome = true;
        ShowPageGroupShare = false;
    }
    void ApplyState() {
        if(lockApplyState)
            return;
        pageHome.IsVisible = ShowPageHome;
        pageGroupShare.IsVisible = ShowPageGroupShare;
    }
}