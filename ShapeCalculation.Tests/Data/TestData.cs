namespace ShapeCalculation.Tests.Data;

public static class TestData
{
    public static readonly Triangle AcuteTriangle = new(30, 30, 34.414586181);
    public static readonly Triangle RightTriangle = new(3, 4, 5);
    public static readonly Triangle ObtuseTriangle = new(30, 30, 51.158409861);
    public static readonly Triangle EquilateralTriangle = new(9, 9, 9);
    public static readonly Triangle IsoscelesTriangle = new(8, 8, 9);
    public static readonly Triangle ScaleneTriangle = new(8, 7, 9);
    public static readonly Triangle AnotherRightTriangle = new(5, 12, 13);

    public static readonly Circle Circle1 = new(10);
    public static readonly Circle Circle2 = new(5);
    public static readonly Circle Circle3 = new(14);

    public static IEnumerable<Triangle> GetTriangles()
    {
        return new List<Triangle>
        {
            AcuteTriangle,
            RightTriangle,
            AnotherRightTriangle,
            ObtuseTriangle,
            EquilateralTriangle,
            IsoscelesTriangle,
            ScaleneTriangle
        };
    }
}