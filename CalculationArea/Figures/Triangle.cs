using CalculationArea.Abstract;
using CalculationArea.Core;

namespace CalculationArea.Figures;

public class Triangle : GeometricFigure
{
    private readonly double _a;
    private readonly double _b;
    private readonly double _c;
    private readonly double[] _sides;

    public Triangle(double a, double b, double c)
    {
        _sides = [a, b, c];
        _a = a;
        _c = c;
        _b = b;
        CheckInputValues();
    }
  
    public override double CalculateArea()
    {
        double halfPerimeter = (_a + _b + _c) / 2;
        return Math.Sqrt(halfPerimeter * (halfPerimeter - _a) * (halfPerimeter - _b) * (halfPerimeter - _c));
    }

    public bool IsRight()
    {
        var sordeSides = _sides.OrderDescending().ToArray();
        var sqrMax = Math.Pow(sordeSides[0], 2);
        var sqrOther1 = Math.Pow(sordeSides[1], 2);
        var sqrOther2 = Math.Pow(sordeSides[2], 2);
        return Math.Abs(sqrMax - (sqrOther1 + sqrOther2)) < Constants.CalculatePrecision;
    }

    private void CheckInputValues()
    {
        if (_sides.Min() <= 0 )
        {
            throw new ArgumentException(Constants.ExceptionMessageSidesMestBeGreaterThenZero);
        }
        if (_a + _b <= _c || _a + _c <= _b || _b + _c <= _a)
        {
            throw new ArgumentException(Constants.ExceptionMessageTriangleDoesntExisting);
        }
    }
    
}