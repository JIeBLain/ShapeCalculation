using ShapeCalculation.Contracts;
using ShapeCalculation.Exceptions;

namespace ShapeCalculation;

public class Triangle : IShape
{
    public Triangle(double a, double b, double c)
    {
        A = a;
        B = b;
        C = c;

        if (!IsValid())
            throw new InvalidTriangleException(this);
    }

    public double A { get; }
    public double B { get; }
    public double C { get; }

    public bool IsRight
    {
        get
        {
            var c = Math.Max(A, Math.Max(B, C));
            var a = Math.Min(A, Math.Min(B, C));
            var b = A + B + C - a - c;

            return Math.Abs(c * c - (a * a + b * b)) < 10e-10;
        }
    }

    public string Name => nameof(Triangle);

    public double CalculateArea(int precision = 2)
    {
        var semiPerimeter = (A + B + C) / 2;
        var area = Math.Sqrt(semiPerimeter * (semiPerimeter - A) * (semiPerimeter - B) * (semiPerimeter - C));
        return Math.Round(area, precision);
    }

    private bool IsValid()
    {
        if (A <= 0 || B <= 0 || C <= 0)
            return false;
        return A + B > C && A + C > B && B + C > A;
    }
}