using ShapeCalculation.Contracts;
using ShapeCalculation.Exceptions;

namespace ShapeCalculation;

public class Circle : IShape
{
    public Circle(double radius)
    {
        Radius = radius;

        if (!IsValid())
            throw new InvalidCircleException(this);
    }

    public double Radius { get; }

    public string Name => nameof(Circle);

    public double CalculateArea(int precision = 2)
    {
        var area = Math.PI * Radius * Radius;
        return Math.Round(area, precision);
    }

    private bool IsValid()
    {
        return Radius > 0;
    }
}