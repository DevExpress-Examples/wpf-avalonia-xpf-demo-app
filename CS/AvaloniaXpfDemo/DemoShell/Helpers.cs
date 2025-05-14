using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using DevExpress.Mvvm.UI.Native;

namespace DevExpress.AvaloniaXpfDemo.DemoShell;

static class ExceptionHelper {
    public static string GetMessage(Exception e) {
        string message = string.Empty;
        for(var exception = e; exception != null; exception = exception.InnerException) {
            message += exception.ToString() + "\n";
        }
        return message;
    }
}

static class AsyncHelper {
    public static Task WaitLoaded(FrameworkElement element) {
        if(element.IsLoaded)
            return Task.CompletedTask;
        TaskCompletionSource<bool> taskSource = new TaskCompletionSource<bool>();
        RoutedEventHandler? onLoaded = null;
        onLoaded = (s, e) => {
            element.Loaded -= onLoaded;
            taskSource.SetResult(true);
        };
        element.Loaded += onLoaded;
        return taskSource.Task;
    }
    public static Task Wait(FrameworkElement element, DispatcherPriority priority) {
        TaskCompletionSource<bool> taskSource = new TaskCompletionSource<bool>();
        element.Dispatcher.InvokeAsync(() => {
            taskSource.SetResult(true);
        }, priority);
        return taskSource.Task;
    }

    public static Task Animate(FrameworkElement owner, Action<double> callback, TimeSpan duration, IEasingFunction? easing = null, CancellationToken? ct = null) {
        var a = new Animator(callback, duration, easing, ct ?? CancellationToken.None);
        a.Start(owner);
        return a.Task;
    }
    public static double Interpolate(double from, double to, double transitionCoef /*from 0 to 1*/) {
        return from + (to - from) * transitionCoef;
    }

    class Animator : DependencyObject {
        public static readonly DependencyProperty ValueProperty;
        public double Value { get { return (double)GetValue(ValueProperty); } set { SetValue(ValueProperty, value); } }
        public Task Task { get => task.Task; }
        static Animator() {
            DependencyPropertyRegistrator<Animator>.New()
                .Register(nameof(Value), out ValueProperty, 0d, (x, oldValue, newValue) => x.OnValueChanged(oldValue, newValue));
        }

        TaskCompletionSource<bool> task;
        CancellationToken ct;
        Action<double> callback;
        Storyboard storyboard;
        DoubleAnimation animation;

        public Animator(Action<double> callback, TimeSpan duration, IEasingFunction? easing, CancellationToken ct) {
            this.task = new TaskCompletionSource<bool>();
            this.ct = ct;
            ct.Register(Stop);

            this.callback = callback;
            this.animation = new DoubleAnimation() {
                EasingFunction = easing,
                Duration = new Duration(duration),
                From = 0d,
                To = 1d,
            };

            Storyboard.SetTarget(animation, this);
            Storyboard.SetTargetProperty(animation, new PropertyPath(ValueProperty));
            animation.Freeze();

            storyboard = new Storyboard();
            storyboard.Children.Add(animation);
            storyboard.Completed += OnStoryboardCompleted;
        }
        public void Start(FrameworkElement owner) {
            if(ct.IsCancellationRequested) {
                task.TrySetResult(true);
                return;
            }
            storyboard.Begin(owner, true);
        }
        public void Stop() {
            storyboard?.Stop();
            task.TrySetResult(true);
        }

        void OnValueChanged(double oldValue, double newValue) {
            callback.Invoke(newValue);
        }
        void OnStoryboardCompleted(object? sender, EventArgs e) {
            task.TrySetResult(true);
        }
    }
}

public class ClipGeometryConverter : MarkupExtension, IMultiValueConverter {
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) {
        if(values.Length == 4) {
            var width = ((double)values[0]);
            var height = ((double)values[1]);
            var radius = ((CornerRadius)values[2]).TopLeft;
            if(radius > 0) {
                var geometry = new RectangleGeometry(new Rect(0, 0, width, height), radius, radius);
                geometry.Freeze();
                return geometry;
            }
        }
        return DependencyProperty.UnsetValue;
    }
    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) {
        throw new NotImplementedException();
    }

    public override object ProvideValue(IServiceProvider serviceProvider) {
        return this;
    }
}

static class LinksHelper {
    static string GetGoLinkDataParameter(string platformName, string? moduleTypeFullName) {
        var suffix = "?gldata=" + AssemblyInfo.VersionShort;
        if(!string.IsNullOrEmpty(moduleTypeFullName))
            suffix += "_" + moduleTypeFullName;
        return suffix + $"|{platformName}&platform={platformName}";
    }
    public static string BuyNow(string platformName, string? moduleTypeFullName = null) {
        return SubscriptionsBuyLink + GetGoLinkDataParameter(platformName, moduleTypeFullName);
    }
    public static string GetSupport(string platformName, string? moduleTypeFullName = null) {
        return AssemblyInfo.DXLinkGetSupport + GetGoLinkDataParameter(platformName, moduleTypeFullName);
    }
    public static string GetStarted(string platformName, string? moduleTypeFullName = null) {
        var link = "https://go.devexpress.com/Demo_GetStarted_WPF.aspx";
        return link + GetGoLinkDataParameter(platformName, moduleTypeFullName);
    }
    const string SubscriptionsBuyLink = "Https://go.devexpress.com/Demo_Subscriptions_Buy.aspx";
}