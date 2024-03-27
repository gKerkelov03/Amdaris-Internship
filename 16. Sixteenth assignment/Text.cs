public class Text : ITextComponent
{
    private readonly string _text;

    public Text(string text) => _text = text;

    public string Format => _text;

    public string RemoveFormatting() => _text;
}
