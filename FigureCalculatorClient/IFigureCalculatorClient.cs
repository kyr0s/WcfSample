namespace FigureCalculator.Client
{
    public interface IFigureCalculatorClient
    {
        double GetCircleLength(double radius);
        double GetCircleArea(double radius);
    }
}