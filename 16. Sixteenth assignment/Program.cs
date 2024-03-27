
using System.Drawing;

var text = new Text("This is the first text");
var text2 = new Text("This is another text");
var text3 = new Text("This is a third type of text");

var fullyDecoratedText = new BoldDecorator(
                            new ItalicDecorator(
                                new UnderlineDecorator(
                                    new ColorDecorator(text, Color.White),
                                    Color.Black
                                )
                            )
                        );

var italicBolded = new BoldDecorator(new ItalicDecorator(text2));
var underlinedColored = new ColorDecorator(new UnderlineDecorator(text3, Color.Blue), Color.Orange);


Console.WriteLine(fullyDecoratedText.Format);
Console.WriteLine(italicBolded.Format);
Console.WriteLine(underlinedColored.Format);

fullyDecoratedText.RemoveFormatting();
Console.WriteLine();
Console.WriteLine("Removing all the formatting from the first text now...");
Console.WriteLine("Result: " + fullyDecoratedText.Format);
