public class ItalicDecorator : ITextComponent
{
    private ITextComponent _textComponent;

    public string Format { get; private set; }

    public ItalicDecorator(ITextComponent textComponent)
    {
        _textComponent = textComponent;
        Format = _textComponent.Format + ", italic";
    }

    public string RemoveFormatting() => Format = _textComponent.RemoveFormatting();
}
