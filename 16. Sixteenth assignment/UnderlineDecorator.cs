using System.Drawing;

public class UnderlineDecorator : ITextComponent
{
    private ITextComponent _textComponent;
    public string Format { get; private set; }

    public UnderlineDecorator(ITextComponent textComponent, Color underlineColor)
    {
        var underlineColorName = underlineColor.Name.ToLower();
        _textComponent = textComponent;

        Format = _textComponent.Format + $", underlined with {underlineColorName} line";
    }

    public string RemoveFormatting() => _textComponent.RemoveFormatting();
}
