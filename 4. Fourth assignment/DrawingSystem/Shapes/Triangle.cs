namespace DrawingSystem;

public class Triangle : Shape
{
    public Triangle(string name, IList<double> sides)
        : base(name, sides) { }

    public override double CalculateArea
    {
        get
        {
            var semiParameter = ((double)this.Sides.Sum()) / 2;

            return Math.Sqrt(
                semiParameter *
                (semiParameter - this.Sides[0]) *
                (semiParameter - this.Sides[1]) *
                (semiParameter - this.Sides[2])
            );
        }
    }

}