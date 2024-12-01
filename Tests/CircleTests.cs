using CalculationArea.Core;
using CalculationArea.Figures;

namespace Tests;

public class CircleTests
{
    [TestCase(0)]
    [TestCase(-1)]
    [TestCase(-10)]
    public void Test_CreateCircle_Successfully(double radius)
    {
        Assert.Throws<ArgumentException>(() => new Circle(radius));
    }
    
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(10)]
    public void Test_CalculateCicleArea_Successfully(double radius)
    {
        var circle = new Circle(radius);
        var circleArea = circle.CalculateArea();
        Assert.AreEqual(Math.PI *Math.Pow(radius, 2), circleArea, Constants.CalculatePrecision );
    }
}