namespace ShapeCalculation.Exceptions;

public sealed class InvalidTriangleException : Exception
{
    public InvalidTriangleException(Triangle triangle)
        : base($"A triangle with sides: {triangle.A}, {triangle.B}, and {triangle.C} is not valid. A triangle is valid if sum of its two sides is greater than the third side.")
    {
    }
}