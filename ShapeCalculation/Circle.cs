using ShapeCalculation.Contracts;

namespace ShapeCalculation;

public class Circle : IShape
{
    public Circle(double radius)
    {
        Radius = radius;
    }

    public double Radius { get; }

    public string Name => nameof(Circle);

    public double CalculateArea(int precision = 2)
    {
        var area = Math.PI * Radius * Radius;
        return Math.Round(area, precision);
    }
}