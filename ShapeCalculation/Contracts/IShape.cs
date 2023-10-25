namespace ShapeCalculation.Contracts;

public interface IShape
{
    string Name { get; }
    double CalculateArea(int precision = 2);
}