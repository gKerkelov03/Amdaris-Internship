
namespace DrawingSystem;

public class Square : Rectangle
{
    public Square(string name, IList<double> sides)
        : base(name, sides) { }

    public override double CalculateArea
        => this.Sides[0] * this.Sides[0];
}