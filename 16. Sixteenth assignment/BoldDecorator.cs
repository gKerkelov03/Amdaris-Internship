public class BoldDecorator : ITextComponent
{
    private ITextComponent _textComponent;

    public string Format { get; private set; }

    public BoldDecorator(ITextComponent textComponent)
    {
        _textComponent = textComponent;
        Format = _textComponent.Format + $", bolded";
    }

    public string RemoveFormatting() => Format = _textComponent.RemoveFormatting();
}
