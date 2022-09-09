using Font = Microsoft.Maui.Font;

namespace Perigee.Controls.Maui;

public partial class AutoCompleteEntry : IEntry
{
    private string _text;
    private string _text1;

    public Color TextColor { get; }
    public Font Font { get; }
    public double CharacterSpacing { get; }

    string IText.Text => _text;

    public bool IsTextPredictionEnabled { get; }
    public bool IsReadOnly { get; }
    public Keyboard Keyboard { get; }
    public int MaxLength { get; }
    public int CursorPosition { get; set; }
    public int SelectionLength { get; set; }
    public string Placeholder { get; }
    public Color PlaceholderColor { get; set; }

    string ITextInput.Text
    {
        get => _text1;
        set => _text1 = value;
    }

    public TextAlignment HorizontalTextAlignment { get; }
    public TextAlignment VerticalTextAlignment { get; }
    public void Completed()
    {
        throw new NotImplementedException();
    }

    public bool IsPassword { get; }
    public ReturnType ReturnType { get; }
    public ClearButtonVisibility ClearButtonVisibility { get; }
}
