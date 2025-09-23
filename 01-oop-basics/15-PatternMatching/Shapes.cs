// Shapes.cs
namespace PatternMatchingDemo
{
    abstract class Shape { }

    class Circle(double radius) : Shape
    {
        public double Radius { get; } = radius;
    }

    class Rectangle(double width, double height) : Shape
    {
        public double Width { get; } = width;
        public double Height { get; } = height;
    }

    class Triangle(double a, double b, double c) : Shape
    {
        public double A { get; } = a; public double B { get; } = b; public double C { get; } = c;
    }
}
