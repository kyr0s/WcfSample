namespace Calculator.Client
{
    public interface ICalculatorClient
    {
        double Add(double first, double second);
        double Subtract(double first, double second);
        double Multiply(double first, double second);
        double Divide(double first, double second);
    }
}
