using CalculationArea.Core;
using CalculationArea.Figures;

namespace Tests;

public class TriangleTests
{
    [TestCase(0,1,3)]
    [TestCase(10,-10, 2)]
    [TestCase(2, 5, -1)]
    [TestCase(-3, -5, -1)]
    public void Test_CreateTriangle_WithNegativeSides_Unsuccessfully(double a, double b, double c)
    {
        Assert.Throws<ArgumentException>(() => new Triangle(a,b,c));
    }
    
    [TestCase(10,1,3)]
    [TestCase(2, 20, 10)]
    [TestCase(3, 8, 11)]
    public void Test_CreateTriangle_WithIncorrectSides_Unsuccessfully(double a, double b, double c)
    {
        Assert.Throws<ArgumentException>(() => new Triangle(a,b,c));
    }
    
    [TestCase(7,6,8)]
    [TestCase(3, 4, 5)]
    [TestCase(5, 12, 13)]
    public void Test_CalculateTriangleArea_Successfully(double a, double b, double c)
    {
        var triangle = new Triangle(a,b,c);
        var triangleArea = CalculateArea(a,b,c);
        Assert.That(triangleArea, Is.EqualTo(triangle.CalculateArea()).Within(Constants.CalculatePrecision));
    }
    
    [TestCase(3, 4, 5)]
    [TestCase(5, 12, 13)]
    public void Test_CheckIsRightTriangle_Successfully(double a, double b, double c)
    {
        var triangle = new Triangle(a,b,c);
        Assert.That(triangle.IsRight(), Is.EqualTo(true));
    }
    
    [TestCase(2, 4, 3)]
    [TestCase(10, 12, 13)]
    public void Test_CheckIsRightTriangle_Unsuccessfully(double a, double b, double c)
    {
        var triangle = new Triangle(a,b,c);
        Assert.That(triangle.IsRight(), Is.EqualTo(false));
    }
    
    private double CalculateArea(double a,double b, double c)
    {
        double halfPerimeter = (a + b + c) / 2;
        return Math.Sqrt(halfPerimeter * (halfPerimeter - a) * (halfPerimeter - b) * (halfPerimeter - c));
    }
}