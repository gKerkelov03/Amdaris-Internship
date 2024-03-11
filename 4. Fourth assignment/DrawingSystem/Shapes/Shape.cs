namespace DrawingSystem;

public abstract class Shape
{
    public string Name { get; set; }

    public IList<double> Sides { get; set; }

    public Shape(string name, IList<double> sides)
    {
        this.Name = name;
        this.Sides = sides;
    }

    public void Draw()
        => Console.WriteLine($"Shape {this.Name} was drawn");

    public void Draw(IDrawingStyleProvider drawingProvider)
        => drawingProvider.Draw(this);

    public abstract double CalculateArea { get; }

}
