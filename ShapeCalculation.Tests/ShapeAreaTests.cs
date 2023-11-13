using ShapeCalculation.Contracts;
using ShapeCalculation.Exceptions;
using ShapeCalculation.Tests.Data;
using FluentAssertions;

namespace ShapeCalculation.Tests;

public class ShapeAreaTests
{
    [Theory, MemberData(nameof(GetCirclesData), 4)]
    public void CalculateArea_Should_Return_Correct_Circle_Area(Circle circle, int precision, double expected)
    {
        var circleArea = circle.CalculateArea(precision);

        circleArea.Should().Be(expected);
    }

    [Theory, MemberData(nameof(GetTrianglesData), 4)]
    public void CalculateArea_Should_Return_Correct_Triangle_Area(Triangle triangle, int precision, double expected)
    {
        var triangleArea = triangle.CalculateArea(precision);

        triangleArea.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(GetCirclesData), 4)]
    [MemberData(nameof(GetTrianglesData), 4)]
    public void CalculateArea_Should_Return_Correct_Area_Of_Different_Shapes(IShape shape, int precision,
        double expected)
    {
        var shapeArea = shape.CalculateArea(precision);

        shapeArea.Should().Be(expected);
    }

    [Fact]
    public void Count_Should_Return_2_Right_Triangles()
    {
        const int expected = 2;

        var rightTriangles = TestData.GetTriangles()
            .Where(triangle => triangle.IsRight);

        rightTriangles.Should().HaveCount(expected);
    }

    [Theory]
    [InlineData(4, 5, 20)]
    [InlineData(12, 3, 8)]
    [InlineData(6, 4, 11)]
    [InlineData(0, 4, 11)]
    [InlineData(6, -2, 11)]
    [InlineData(6, 4, -10)]
    public void Constructor_Should_Throw_InvalidTriangleException_When_Invalid_Arguments_Are_Passed(
        double a, double b, double c)
    {
        Action act = () => { _ = new Triangle(a, b, c); };

        act.Should().Throw<InvalidTriangleException>();
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-5)]
    [InlineData(-23)]
    public void Constructor_Should_Throw_InvalidCircleException_When_Circle_Radius_Is_Zero_Or_Negative(double radius)
    {
        Action act = () => { _ = new Circle(radius); };

        act.Should().Throw<InvalidCircleException>();
    }

    public static IEnumerable<object[]> GetCirclesData(int precision)
    {
        return new List<object[]>
        {
            new object[] { TestData.Circle1, precision, Math.Round(314.15926535897933, precision) },
            new object[] { TestData.Circle2, precision, Math.Round(78.539816339744831, precision) },
            new object[] { TestData.Circle3, precision, Math.Round(615.75216010359941, precision) },
        };
    }

    public static IEnumerable<object[]> GetTrianglesData(int precision)
    {
        return new List<object[]>
        {
            new object[] { TestData.AcuteTriangle, precision, Math.Round(422.8616793532658, precision) },
            new object[] { TestData.RightTriangle, precision, Math.Round(6d, precision) },
            new object[] { TestData.ObtuseTriangle, precision, Math.Round(400.9529358879654, precision) },
            new object[] { TestData.EquilateralTriangle, precision, Math.Round(35.074028853269766, precision) },
            new object[] { TestData.IsoscelesTriangle, precision, Math.Round(29.764702249476645, precision) },
            new object[] { TestData.ScaleneTriangle, precision, Math.Round(26.832815729997478, precision) },
            new object[] { TestData.AnotherRightTriangle, precision, Math.Round(30d, precision) }
        };
    }
}