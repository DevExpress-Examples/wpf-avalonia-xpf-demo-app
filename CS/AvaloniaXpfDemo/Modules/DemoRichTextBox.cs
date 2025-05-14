#nullable disable
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using DevExpress.Mvvm;
using DevExpress.Xpf.Bars;

namespace DevExpress.AvaloniaXpfDemo;

public class DemoRichControl : System.Windows.Controls.RichTextBox {
    #region dependency properties
    public static readonly DependencyProperty IsBoldProperty = DependencyProperty.Register("IsBold", typeof(bool?), typeof(DemoRichControl), new PropertyMetadata(null, new PropertyChangedCallback(OnIsBoldPropertyChanged)));
    public static readonly DependencyProperty IsItalicProperty = DependencyProperty.Register("IsItalic", typeof(bool?), typeof(DemoRichControl), new PropertyMetadata(null, new PropertyChangedCallback(OnIsItalicPropertyChanged)));
    public static readonly DependencyProperty IsUnderlineProperty = DependencyProperty.Register("IsUnderline", typeof(bool?), typeof(DemoRichControl), new PropertyMetadata(null, new PropertyChangedCallback(OnIsUnderlinePropertyChanged)));
    public static readonly DependencyProperty SelectionTextProperty = DependencyProperty.Register("SelectionText", typeof(string), typeof(DemoRichControl), new PropertyMetadata(null));
    public static readonly DependencyProperty SelectionFontFamilyProperty = DependencyProperty.Register("SelectionFontFamily", typeof(string), typeof(DemoRichControl), new PropertyMetadata(null, new PropertyChangedCallback(OnSelectionFontFamilyPropertyChanged)));
    public static readonly DependencyProperty SelectionFontSizeProperty = DependencyProperty.Register("SelectionFontSize", typeof(double?), typeof(DemoRichControl), new PropertyMetadata(null, new PropertyChangedCallback(OnSelectionFontSizePropertyChanged)));
    public static readonly DependencyProperty SelectionTextColorProperty = DependencyProperty.Register("SelectionTextColor", typeof(Color), typeof(DemoRichControl), new PropertyMetadata(Colors.Black, new PropertyChangedCallback(OnSelectionTextColorPropertyChanged)));
    public static readonly DependencyProperty SelectionTextBackgroundColorProperty = DependencyProperty.Register("SelectionTextBackgroundColor", typeof(Color), typeof(DemoRichControl), new PropertyMetadata(Colors.Black, new PropertyChangedCallback(OnSelectionTextBackgroundColorPropertyChanged)));
    public static readonly DependencyProperty IsRightAlignmentProperty = DependencyProperty.Register("IsRightAlignment", typeof(bool), typeof(DemoRichControl), new PropertyMetadata(false, new PropertyChangedCallback(OnIsRightAlignmentPropertyChanged)));
    public static readonly DependencyProperty IsCenterAlignmentProperty = DependencyProperty.Register("IsCenterAlignment", typeof(bool), typeof(DemoRichControl), new PropertyMetadata(false, new PropertyChangedCallback(OnIsCenterAlignmentPropertyChanged)));
    public static readonly DependencyProperty IsLeftAlignmentProperty = DependencyProperty.Register("IsLeftAlignment", typeof(bool), typeof(DemoRichControl), new PropertyMetadata(false, new PropertyChangedCallback(OnIsLeftAlignmentPropertyChanged)));
    public static readonly DependencyProperty IsEmptyProperty = DependencyProperty.Register("IsEmpty", typeof(bool), typeof(DemoRichControl), new PropertyMetadata(true, new PropertyChangedCallback(OnIsEmptyPropertyChanged)));
    public static readonly DependencyProperty IsSelectionEmptyProperty = DependencyProperty.Register("IsSelectionEmpty", typeof(bool), typeof(DemoRichControl), new PropertyMetadata(true));
    public static readonly DependencyProperty ListMarkerStyleProperty = DependencyProperty.Register("ListMarkerStyle", typeof(TextMarkerStyle), typeof(DemoRichControl), new PropertyMetadata(TextMarkerStyle.None, new PropertyChangedCallback(OnListMarkerStylePropertyChanged)));
    public static readonly DependencyProperty ContainerProperty = DependencyProperty.Register("Container", typeof(InlineUIContainer), typeof(DemoRichControl), new PropertyMetadata(null, new PropertyChangedCallback(OnContainerPropertyChanged)));
    public static readonly DependencyProperty IsListProperty = DependencyProperty.Register("IsList", typeof(bool?), typeof(DemoRichControl), new PropertyMetadata(false, new PropertyChangedCallback(OnIsListPropertyChanged)));
    public static readonly DependencyProperty RowProperty = DependencyProperty.Register("Row", typeof(int), typeof(DemoRichControl), new PropertyMetadata(1));
    public static readonly DependencyProperty ColumnProperty = DependencyProperty.Register("Column", typeof(int), typeof(DemoRichControl), new PropertyMetadata(1));

    protected static void OnIsBoldPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
        ((DemoRichControl)d).OnIsBoldChanged();
    }
    protected static void OnIsItalicPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
        ((DemoRichControl)d).OnIsItalicChanged();
    }
    protected static void OnIsUnderlinePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
        ((DemoRichControl)d).OnIsUnderlineChanged();
    }
    protected static void OnSelectionFontFamilyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
        ((DemoRichControl)d).OnSelectionFontFamilyChanged();
    }
    protected static void OnSelectionFontSizePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
        ((DemoRichControl)d).OnSelectionFontSizeChanged();
    }
    protected static void OnSelectionTextColorPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
        ((DemoRichControl)d).OnSelectionTextColorChanged();
    }
    protected static void OnSelectionTextBackgroundColorPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
        ((DemoRichControl)d).OnSelectionTextBackgroundColorChanged();
    }
    protected static void OnIsRightAlignmentPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
        ((DemoRichControl)d).OnIsRightAlignmentChanged();
    }
    protected static void OnIsLeftAlignmentPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
        ((DemoRichControl)d).OnIsLeftAlignmentChanged();
    }
    protected static void OnIsCenterAlignmentPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
        ((DemoRichControl)d).OnIsCenterAlignmentChanged();
    }
    protected static void OnListMarkerStylePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
        ((DemoRichControl)d).OnListMarkerStyleChanged();
    }
    protected static void OnContainerPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
        ((DemoRichControl)d).OnContainerChanged();
    }
    protected static void OnIsEmptyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
        ((DemoRichControl)d).OnIsEmptyChanged();
    }
    protected static void OnIsListPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
        ((DemoRichControl)d).OnIsListChanged();
    }
    public bool? IsBold {
        get { return (bool?)GetValue(IsBoldProperty); }
        set { SetValue(IsBoldProperty, value); }
    }
    public bool? IsItalic {
        get { return (bool?)GetValue(IsItalicProperty); }
        set { SetValue(IsItalicProperty, value); }
    }
    public bool? IsUnderline {
        get { return (bool?)GetValue(IsUnderlineProperty); }
        set { SetValue(IsUnderlineProperty, value); }
    }
    public string SelectionText {
        get { return (string)GetValue(SelectionTextProperty); }
        set { SetValue(SelectionTextProperty, value); }
    }
    public string SelectionFontFamily {
        get { return (string)GetValue(SelectionFontFamilyProperty); }
        set { SetValue(SelectionFontFamilyProperty, value); }
    }
    public double? SelectionFontSize {
        get { return (double?)GetValue(SelectionFontSizeProperty); }
        set { SetValue(SelectionFontSizeProperty, value); }
    }
    public Color SelectionTextColor {
        get { return (Color)GetValue(SelectionTextColorProperty); }
        set { SetValue(SelectionTextColorProperty, value); }
    }
    public Color SelectionTextBackgroundColor {
        get { return (Color)GetValue(SelectionTextBackgroundColorProperty); }
        set { SetValue(SelectionTextBackgroundColorProperty, value); }
    }
    public bool IsRightAlignment {
        get { return (bool)GetValue(IsRightAlignmentProperty); }
        set { SetValue(IsRightAlignmentProperty, value); }
    }
    public bool IsCenterAlignment {
        get { return (bool)GetValue(IsCenterAlignmentProperty); }
        set { SetValue(IsCenterAlignmentProperty, value); }
    }
    public bool IsLeftAlignment {
        get { return (bool)GetValue(IsLeftAlignmentProperty); }
        set { SetValue(IsLeftAlignmentProperty, value); }
    }
    public bool IsEmpty {
        get { return (bool)GetValue(IsEmptyProperty); }
        set { SetValue(IsEmptyProperty, value); }
    }
    public bool IsSelectionEmpty {
        get { return (bool)GetValue(IsSelectionEmptyProperty); }
        set { SetValue(IsSelectionEmptyProperty, value); }
    }
    public TextMarkerStyle ListMarkerStyle {
        get { return (TextMarkerStyle)GetValue(ListMarkerStyleProperty); }
        set { SetValue(ListMarkerStyleProperty, value); }
    }
    public InlineUIContainer Container {
        get { return (InlineUIContainer)GetValue(ContainerProperty); }
        set { SetValue(ContainerProperty, value); }
    }
    public bool? IsList {
        get { return (bool?)GetValue(IsListProperty); }
        set { SetValue(IsListProperty, value); }
    }
    public int Row {
        get { return (int)GetValue(RowProperty); }
        set { SetValue(RowProperty, value); }
    }
    public int Column {
        get { return (int)GetValue(ColumnProperty); }
        set { SetValue(ColumnProperty, value); }
    }
    #endregion
    #region commands
    public ICommand SelectAllCommand { get; set; }
    public ICommand ClearCommand { get; set; }
    public ICommand PrintCommand { get; set; }
    public ICommand CopyCommand { get; set; }
    public ICommand PasteCommand { get; set; }
    public ICommand CutCommand { get; set; }
    public ICommand ClearSelectionCommand { get; set; }
    #endregion

    public DemoRichControl() {
        ClearSelectionCommand = new DelegateCommand(ClearSelectionCommandExecute, CanClearSelectionCommandExecute);
        ClearCommand = new DelegateCommand(ClearCommandExecute, CanClearCommandExecute);
        PrintCommand = new DelegateCommand(PrintCommandExecute);
        CopyCommand = ApplicationCommands.Copy;
        PasteCommand = ApplicationCommands.Paste;
        CutCommand = ApplicationCommands.Cut;
        SelectAllCommand = ApplicationCommands.SelectAll;
        UndoLimit = 0;
    }

    public void SetFocus() {
        this.Focus();
        UpdateSelectionProperties();
    }
    public event EventHandler ContainerChanged;

    bool IsUpdating { get; set; }
    protected void OnIsBoldChanged() { if(!IsUpdating) IsBoldCore = IsBold; }
    protected void OnIsItalicChanged() { if(!IsUpdating) IsItalicCore = IsItalic; }
    protected void OnIsUnderlineChanged() { if(!IsUpdating) IsUnderlineCore = IsUnderline; }
    protected void OnSelectionFontFamilyChanged() { if(!IsUpdating) SelectionFontFamilyCore = SelectionFontFamily; }
    protected void OnSelectionFontSizeChanged() { if(!IsUpdating) SelectionFontSizeCore = SelectionFontSize; }
    protected void OnSelectionTextBackgroundColorChanged() { if(!IsUpdating) SelectionTextBackgroundColorCore = SelectionTextBackgroundColor; }
    protected void OnSelectionTextColorChanged() { if(!IsUpdating) SelectionTextColorCore = SelectionTextColor; }
    protected void OnIsRightAlignmentChanged() {
        if(IsUpdating) return;
        if(IsRightAlignment) {
            IsLeftAlignment = false;
            IsCenterAlignment = false;
            TextAlignmentCore = TextAlignment.Right;
        }
    }
    protected void OnContainerChanged() {
        if(ContainerChanged != null)
            ContainerChanged(this, new EventArgs());
    }
    protected void OnListMarkerStyleChanged() {
        if(!IsUpdating) {
            ListMarkerStyleCore = ListMarkerStyle;
            IsUpdating = true;
            IsList = ListMarkerStyle != TextMarkerStyle.None;
            IsUpdating = false;
        }
        else {
            IsList = ListMarkerStyle != TextMarkerStyle.None;
        }
    }
    protected void OnIsListChanged() {
        if(IsUpdating) return;
        ListMarkerStyle = IsList.Value ? TextMarkerStyle.Disc : TextMarkerStyle.None;
    }
    protected void OnIsEmptyChanged() {
        ((DelegateCommand)ClearCommand).RaiseCanExecuteChanged();
    }
    protected void OnIsLeftAlignmentChanged() {
        if(IsUpdating) return;
        if(IsLeftAlignment) {
            IsRightAlignment = false;
            IsCenterAlignment = false;
            TextAlignmentCore = TextAlignment.Left;
        }
    }
    protected void OnIsCenterAlignmentChanged() {
        if(IsUpdating) return;
        if(IsCenterAlignment) {
            IsLeftAlignment = false;
            IsRightAlignment = false;
            TextAlignmentCore = TextAlignment.Center;
        }
    }
    protected override void OnKeyUp(System.Windows.Input.KeyEventArgs e) {
        base.OnKeyUp(e);
        UpdateSelectionProperties();
    }
    protected override void OnSelectionChanged(RoutedEventArgs e) {
        base.OnSelectionChanged(e);
        UpdateSelectionProperties();
        UpdateCaretPosInfo();
    }
    protected void UpdateCaretPosInfo() {
        int actualLineCount = 0;
        CaretPosition.GetLineStartPosition(int.MinValue, out actualLineCount);
        Row = 1 - actualLineCount;
        Column = Math.Max(1, CaretPosition.GetLineStartPosition(0).GetOffsetToPosition(CaretPosition));
    }
    protected void UpdateSelectionProperties() {
        IsUpdating = true;
        IsSelectionEmpty = IsSelectionEmptyCore;
        IsRightAlignment = object.Equals(TextAlignmentCore, TextAlignment.Right);
        IsLeftAlignment = object.Equals(TextAlignmentCore, TextAlignment.Left);
        IsCenterAlignment = object.Equals(TextAlignmentCore, TextAlignment.Center);
        IsBold = IsBoldCore;
        IsItalic = IsItalicCore;
        IsUnderline = IsUnderlineCore;
        SelectionFontSize = SelectionFontSizeCore;
        SelectionFontFamily = SelectionFontFamilyCore;
        SelectionTextColor = SelectionTextColorCore;
        SelectionTextBackgroundColor = SelectionTextBackgroundColorCore;
        Container = GetUIElementUnderSelection();
        ListMarkerStyle = ListMarkerStyleCore;
        IsEmpty = IsEmptyCore;
        IsSelectionEmpty = IsSelectionEmptyCore;
        IsUpdating = false;
    }
    public void Clear() {
        ClearCommandExecute();
    }
    #region commands implementation
    protected bool CanClearSelectionCommandExecute() { return !Selection.IsEmpty; }
    protected void ClearSelectionCommandExecute() {
        Selection.Select(Selection.Start, Selection.Start);
    }
    protected bool CanClearCommandExecute() { return !IsEmpty; }
    protected void ClearCommandExecute() {
        (Document as FlowDocument).Blocks.Clear();
    }
    protected void PrintCommandExecute() {
        System.Windows.Controls.PrintDialog dialog = new System.Windows.Controls.PrintDialog();
        if(dialog.ShowDialog() != true) return;
        dialog.PrintVisual(this, string.Empty);
    }
    #endregion
    #region core properties
    public string SelectionFontFamilyCore {
        get {
            object value = Selection.GetPropertyValue(Run.FontFamilyProperty);
            return (value == DependencyProperty.UnsetValue) ? string.Empty : value.ToString();
        }
        set {
            if(value == null || value == SelectionFontFamilyCore) return;
            try {
                if(value is string)
                    Selection.ApplyPropertyValue(Run.FontFamilyProperty, new FontFamily(value));
                else
                    Selection.ApplyPropertyValue(Run.FontFamilyProperty, value);
                Focus();
            }
            catch { }
        }
    }
    public double? SelectionFontSizeCore {
        get {
            object value = Selection.GetPropertyValue(Run.FontSizeProperty);
            if(value == DependencyProperty.UnsetValue)
                return null;
            return (double?)value;
        }
        set {
            if(value == null || value.Equals(SelectionFontSizeCore))
                return;

            Selection.ApplyPropertyValue(Run.FontSizeProperty, Convert.ToDouble(value));
            Focus();
        }
    }
    public Color SelectionTextColorCore {
        set {
            if(object.Equals(value, SelectionTextColorCore))
                return;
            Selection.ApplyPropertyValue(Run.ForegroundProperty, new SolidColorBrush(value));
        }
        get {
            SolidColorBrush brush = Selection.GetPropertyValue(Run.ForegroundProperty) as SolidColorBrush;
            if(brush == null)
                return Colors.Black;
            return brush.Color;
        }
    }
    public Color SelectionTextBackgroundColorCore {
        set {

            if(value == SelectionTextBackgroundColorCore)
                return;
            SetTextBackgroundColor(value);
        }
        get {
            SolidColorBrush brush = Selection.GetPropertyValue(Run.BackgroundProperty) as SolidColorBrush;
            if(brush == null)
                return Colors.Black;
            return brush.Color;
        }
    }
    public void SetTextBackgroundColor(Color value) {
        Selection.ApplyPropertyValue(Run.BackgroundProperty, new SolidColorBrush(value));
    }
    protected TextAlignment TextAlignmentCore {
        get {
            object value = Selection.GetPropertyValue(System.Windows.Documents.Paragraph.TextAlignmentProperty);
            return value == DependencyProperty.UnsetValue ? TextAlignment.Left : (TextAlignment)value;
        }
        set {
            Selection.ApplyPropertyValue(System.Windows.Documents.Paragraph.TextAlignmentProperty, value);
        }
    }
    protected bool IsEmptyCore {
        get {
            foreach(Block b in Document.Blocks) {
                if(!(b is Paragraph))
                    return false;

                foreach(object o in ((Paragraph)b).Inlines) {
                    if(!(o is Run))
                        return false;
                    Run r = o as Run;
                    if(!string.IsNullOrEmpty(r.Text))
                        return false;
                }
            }
            return true;
        }
    }
    protected bool IsSelectionEmptyCore {
        get {
            return Selection.IsEmpty;
        }
    }
    protected bool? IsBoldCore {
        get {
            object value = Selection.GetPropertyValue(TextElement.FontWeightProperty);
            return (value == DependencyProperty.UnsetValue) ? false : object.Equals(value, FontWeights.Bold);
        }
        set {
            Selection.ApplyPropertyValue(Run.FontWeightProperty, value.Value ? FontWeights.Bold : FontWeights.Normal);
        }
    }
    protected bool? IsItalicCore {
        get {
            object value = Selection.GetPropertyValue(Run.FontStyleProperty);
            return (value == DependencyProperty.UnsetValue) ? false : object.Equals(value, FontStyles.Italic);
        }
        set {
            Selection.ApplyPropertyValue(Run.FontStyleProperty, value.Value ? FontStyles.Italic : FontStyles.Normal);
        }
    }
    protected bool? IsUnderlineCore {
        get {
            object value = Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            return (value == DependencyProperty.UnsetValue) ? false : value != null && System.Windows.TextDecorations.Underline.Equals(value);
        }
        set {
            Selection.ApplyPropertyValue(Run.TextDecorationsProperty, value.Value ? System.Windows.TextDecorations.Underline : null);
        }

    }
    protected TextMarkerStyle ListMarkerStyleCore {
        get {
            Paragraph startParagraph = Selection.Start.Paragraph;
            Paragraph endParagraph = Selection.End.Paragraph;
            if(startParagraph != null && endParagraph != null && (startParagraph.Parent is ListItem) && (endParagraph.Parent is ListItem) && object.ReferenceEquals(((ListItem)startParagraph.Parent).List, ((ListItem)endParagraph.Parent).List)) {
                return ((ListItem)startParagraph.Parent).List.MarkerStyle;
            }
            return TextMarkerStyle.None;
        }
        set {
            Paragraph p = Selection.Start.Paragraph;
            if(p == null)
                return;
            if(value == TextMarkerStyle.None) {
                if(p.Parent is ListItem) {
                    EditingCommands.ToggleBullets.Execute(null, this);
                    p = Selection.Start.Paragraph;
                    if(p.Parent is ListItem) {
                        EditingCommands.ToggleBullets.Execute(null, this);
                    }
                }
                return;
            }
            if(!(p.Parent is ListItem)) {
                EditingCommands.ToggleBullets.Execute(null, this);
                p = this.Selection.Start.Paragraph;
            }

            if(p == null || !(p.Parent is ListItem))
                return;
            ((ListItem)p.Parent).List.MarkerStyle = value;
        }
    }
    #endregion

    public InlineUIContainer GetUIElementUnderSelection(BlockCollection blocks) {
        foreach(Block block in blocks) {
            Paragraph ph = block as Paragraph;
            if(ph != null) {
                foreach(object obj in ph.Inlines) {
                    if(obj is Run)
                        continue;
                    InlineUIContainer cont = obj as InlineUIContainer;
                    if(cont != null && cont.ContentStart.CompareTo(Selection.Start) > 0 && cont.ContentStart.CompareTo(Selection.End) < 0) {
                        return cont;
                    }
                }
            }
            else {
                List lst = block as List;
                if(lst != null) {
                    foreach(ListItem lstItem in lst.ListItems) {
                        InlineUIContainer retVal = GetUIElementUnderSelection(lstItem.Blocks);
                        if(retVal != null)
                            return retVal;
                    }
                }
            }
        }
        return null;

    }
    public InlineUIContainer GetUIElementUnderSelection() {
        BlockCollection col = Document.Blocks;
        if(Selection.Start.GetNextInsertionPosition(LogicalDirection.Forward) == null ||
            Selection.Start.GetNextInsertionPosition(LogicalDirection.Forward).CompareTo(Selection.End) != 0)
            return null;
        return GetUIElementUnderSelection(col);
    }
    public void InsertContainer(InlineUIContainer container) {
        Selection.Text = "";
        if(Selection.End.Paragraph == null) {
            Selection.End.InsertTextInRun("");
        }
        if(Selection.End.Paragraph != null) {
            if(Selection.End.Parent is Run) {
                string text = Selection.End.GetTextInRun(LogicalDirection.Forward);
                Run newRun = new Run(text);
                Selection.End.DeleteTextInRun(text.Length);
                Selection.End.Paragraph.Inlines.InsertAfter((Run)Selection.End.Parent, newRun);
                Selection.End.Paragraph.Inlines.InsertBefore(newRun, container);
            }
            else if(Selection.End.Parent is Paragraph) {
                Selection.End.Paragraph.Inlines.Add(container);
            }
            Selection.Select(container.ElementStart, container.ElementEnd);
        }
    }
    protected override void OnLostKeyboardFocus(KeyboardFocusChangedEventArgs e) {
        IPopupControl popupMenu = BarManager.GetDXContextMenu(this);
        if(popupMenu != null && popupMenu.IsPopupOpen) {
            e.Handled = true;
            return;
        }
        base.OnLostKeyboardFocus(e);
    }
}
