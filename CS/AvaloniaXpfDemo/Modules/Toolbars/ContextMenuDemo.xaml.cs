using System.Windows.Documents;
using DevExpress.AvaloniaXpfDemo.DemoShell;
using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Utils;

namespace DevExpress.AvaloniaXpfDemo.ToolbarsModules;

public partial class ContextMenuDemo : DemoModuleView {
    public static readonly DependencyProperty MenuButtonProperty =
        DependencyPropertyManager.Register("MenuButton", typeof(ButtonSwitcher), typeof(ContextMenuDemo), new FrameworkPropertyMetadata());
    public ButtonSwitcher MenuButton { get { return (ButtonSwitcher)GetValue(MenuButtonProperty); } set { SetValue(MenuButtonProperty, value); } }

    public ContextMenuDemo() {
        InitializeComponent();
        App.CommonRibbon.Clear();
        CheckMouseSwitcher();
        edit.ContextMenu = null;
    }
    protected override void OnModuleCompletelyLoaded() {
        base.OnModuleCompletelyLoaded();
        edit.SetFocus();
    }

    void OnRadioButtonClick(object sender, RoutedEventArgs e) {
        CheckMouseSwitcher();
    }
    void CheckMouseSwitcher() {
        if(Left.IsChecked == true)
            MenuButton = ButtonSwitcher.LeftButton;
        if(LeftRight.IsChecked == true)
            MenuButton = ButtonSwitcher.LeftRightButton;
        if(Right.IsChecked == true)
            MenuButton = ButtonSwitcher.RightButton;
        UpdateText(MenuButton);
    }
    void UpdateText(ButtonSwitcher MenuButton) {
        string text = string.Empty;
        switch(MenuButton) {
            case ButtonSwitcher.LeftButton:
                text = "Left click here to show a context menu";
                break;
            case ButtonSwitcher.LeftRightButton:
                text = "Left or right click here to show a context menu";
                break;
            case ButtonSwitcher.RightButton:
                text = "Right click here to show a context menu";
                break;
        }
        edit.Clear();
        edit.Document.Blocks.Add(new Paragraph(new Run(text)));
    }
}