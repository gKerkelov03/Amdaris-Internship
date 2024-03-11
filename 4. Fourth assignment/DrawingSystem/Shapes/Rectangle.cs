
namespace DrawingSystem;

public class Rectangle : Shape
{
    public Rectangle(string name, IList<double> sides)
        : base(name, sides) { }

    public override double CalculateArea => this.Sides[0] * this.Sides[1];

    public static double CalculateParameter(double side1, double side2, double side3 = 0, double side4 = 0)
        => side1 * 2 + side2 * 2;
}