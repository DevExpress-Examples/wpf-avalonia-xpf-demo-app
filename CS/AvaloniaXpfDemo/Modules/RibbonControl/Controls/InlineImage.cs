#nullable disable
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace DevExpress.AvaloniaXpfDemo.RibbonControlModules;

public class InlineImage : Panel {
    protected Size DefaultSize { get { return new Size(100, 100); } }
    Dictionary<InlineImageBorderType, string> Shapes { get; set; }
    public string PathData { get; set; }

    InlineImageViewModel inlineImageViewModelCore;
    public InlineImageViewModel InlineImageViewModel {
        get { return inlineImageViewModelCore; }
        protected set {
            inlineImageViewModelCore = value;
            ((INotifyPropertyChanged)inlineImageViewModelCore).PropertyChanged += OnInlineImageViewModelPropertyChanged;
            UpdateImage();
        }
    }

    void OnInlineImageViewModelPropertyChanged(object sender, PropertyChangedEventArgs e) {
        UpdateImage();
    }
    public InlineImage(InlineImageViewModel viewModel) {
        Shapes = new Dictionary<InlineImageBorderType, string>();
        Shapes.Add(InlineImageBorderType.None, "M 0,0 L100,0 L100,100  L0,100 Z");
        Shapes.Add(InlineImageBorderType.Rectangle, "M 0,0 L100,0 L100,100  L0,100 Z");
        Shapes.Add(InlineImageBorderType.Circle, "M0,0 A50,50 0 0 0 0,100 A50,50 0 0 0 0,0");
        Shapes.Add(InlineImageBorderType.Triangle, "M0,2L1,0L2,2Z");
        Shapes.Add(InlineImageBorderType.Star, "M0,-10L2.9,-4.04L9.5,-3L4.25,1.5L5.8,8L0,5L-5.8,8L-4.25,1.5L-9.5,-3L-2.9,-4.04Z");
        Shapes.Add(InlineImageBorderType.LeftArrow, "M0,0L10,5L10,3L30,3L30,-3L10,-3L10,-5Z");
        Shapes.Add(InlineImageBorderType.RightArrow, "M0,0L-10,5L-10,3L-30,3L-30,-3L-10,-3L-10,-5Z");
        Shapes.Add(InlineImageBorderType.UpArrow, "M0,0L5,10L3,10L3,30L-3,30L-3,10L-5,10Z");
        Shapes.Add(InlineImageBorderType.DownArrow, "M0,0L5,-10L3,-10L3,-30L-3,-30L-3,-10L-5,-10Z");
        InlineImageViewModel = viewModel;
    }
    System.Windows.Shapes.Path GetPath(Size size) {
        BitmapImage image = new BitmapImage(new Uri(InlineImageViewModel.ImageSource, UriKind.RelativeOrAbsolute));
        image.BaseUri = BaseUriHelper.GetBaseUri(this);
        ImageBrush brush = new ImageBrush() { ImageSource = image };
        System.Windows.Shapes.Path path = new System.Windows.Shapes.Path();
        path.Fill = brush;
        path.Stroke = new SolidColorBrush(InlineImageViewModel.Color);
        path.StrokeThickness = InlineImageViewModel.HasBorder ? InlineImageViewModel.BorderWeight : 0;
        path.Stretch = Stretch.Uniform;
        path.Width = size.Width;
        path.Height = size.Height;
        PathData = Shapes[InlineImageViewModel.ShapeType];
        path.SetBinding(System.Windows.Shapes.Path.DataProperty, new Binding("PathData") { Source = this, Mode = BindingMode.OneWay });
        return path;
    }
    protected override void OnRender(DrawingContext dc) {
        base.OnRender(dc);
        DrawingVisual dv = new DrawingVisual();
        VisualBrush vb = new VisualBrush(GetPath(RenderSize));
        dc.DrawRectangle(vb, null, new Rect(new Point(), RenderSize));
    }
    void UpdateImage() {
        Size size = new Size(DefaultSize.Width * InlineImageViewModel.Scale, DefaultSize.Height * InlineImageViewModel.Scale);
        Width = size.Width;
        Height = size.Height;
        InvalidateVisual();
    }
}
