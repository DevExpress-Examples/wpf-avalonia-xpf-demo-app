#nullable disable
using DevExpress.Mvvm.POCO;
using System.ComponentModel.DataAnnotations;
using System.Windows.Media;
using DevExpress.Mvvm.DataAnnotations;

namespace DevExpress.AvaloniaXpfDemo.RibbonControlModules;

public enum InlineImageBorderType {
    [Display(Name = "None")]
    None,
    [Display(Name = "Rectangle border")]
    Rectangle,
    [Display(Name = "Circle border")]
    Circle,
    [Display(Name = "Triangle border")]
    Triangle,
    [Display(Name = "Star border")]
    Star,
    [Display(Name = "Left arrow border")]
    LeftArrow,
    [Display(Name = "Right arrow border")]
    RightArrow,
    [Display(Name = "Up arrow border")]
    UpArrow,
    [Display(Name = "Down arrow border")]
    DownArrow
}
[POCOViewModel]
public class InlineImageViewModel {
    public virtual string ImageSource { get; set; }
    public virtual Color Color { get; set; }
    public virtual double Scale { get; set; }
    public virtual InlineImageBorderType ShapeType { get; set; }
    public virtual double BorderWeight { get; set; }
    public virtual bool HasBorder { get; set; }
    protected void OnShapeTypeChanged() {
        HasBorder = ShapeType != InlineImageBorderType.None;
    }
    protected InlineImageViewModel() { }
    public static InlineImageViewModel Create(string imageSource) {
        InlineImageViewModel viewModel = ViewModelSource.Create(() => new InlineImageViewModel());
        viewModel.Scale = 1;
        viewModel.ShapeType = InlineImageBorderType.None;
        viewModel.BorderWeight = 1;
        viewModel.Color = Colors.Black;
        viewModel.ImageSource = imageSource;
        return viewModel;
    }
}