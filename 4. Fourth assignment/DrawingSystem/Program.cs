using DrawingSystem;

IDrawingStyleProvider triangleDrawingProvider = new TriangleDrawingProvider();

List<double> triangleSides = [3, 4, 5];
List<double> rectangleSides = [3, 4, 3, 4];
List<double> squareSides = [3, 3];

Shape triangle = new Triangle("Triangle", triangleSides);
Shape rectangle = new Rectangle("Rectangle", rectangleSides);
Shape square = new Square("Square", squareSides);

Console.WriteLine($"Shape: {triangle.Name} has area: {triangle.CalculateArea}");
Console.WriteLine($"Shape: {rectangle.Name} has area: {rectangle.CalculateArea}");
Console.WriteLine($"Shape: {square.Name} has area: {square.CalculateArea}");

double rectanglePerimeter = Rectangle.CalculateParameter(side2: rectangleSides[1], side1: rectangleSides[0]);
Console.WriteLine($"Rectangle's perimeter is {rectanglePerimeter}");

triangle.Draw();
triangle.Draw(triangleDrawingProvider);
