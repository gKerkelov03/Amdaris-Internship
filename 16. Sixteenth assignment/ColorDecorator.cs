using System.Drawing;

public class ColorDecorator : ITextComponent
{
    private ITextComponent _textComponent;

    public string Format { get; private set; }

    public ColorDecorator(ITextComponent textComponent, Color color)
    {
        var colorName = color.Name.ToLower();
        _textComponent = textComponent;

        Format = _textComponent.Format + $", colored in {colorName}";
    }

    public string RemoveFormatting() => Format = _textComponent.RemoveFormatting();
}
