using CalculationArea.Abstract;

namespace CalculationArea.Figures;

public class Circle : GeometricFigure
{
    private readonly double _radius;
    public Circle(double radius)
    {
        if (radius <= 0)
        {
            throw new ArgumentException("Радиус должен быть больше 0");
        }

        _radius = radius;
    }

    public override double CalculateArea()
    {
        return Math.PI * Math.Pow(_radius, 2);
    }
}