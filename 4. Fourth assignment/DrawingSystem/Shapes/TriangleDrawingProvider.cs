namespace DrawingSystem;

public class TriangleDrawingProvider : IDrawingStyleProvider
{
    public void Draw(Shape shape)
    {
        var triangle = shape as Triangle;

        if (shape is not Triangle)
        {
            throw new ArgumentException("The triangle drawing provider can draw only triangles");
        }

        Console.WriteLine("The triangle was drawn in a specific way by the triangle drawing provider");
    }
}