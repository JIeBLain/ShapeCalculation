namespace ShapeCalculation.Exceptions;

public sealed class InvalidCircleException : Exception
{
    public InvalidCircleException(Circle circle)
        : base($"The radius of the circle must be a positive number. Radius {circle.Radius} is not valid!")
    {
    }
}