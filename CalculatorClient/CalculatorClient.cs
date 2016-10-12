using System.ServiceModel;

namespace Calculator.Client
{
    public class CalculatorClient : ICalculatorClient
    {
        private readonly Service.CalculatorClient calculator;

        public CalculatorClient()
        {
            var binding = new WSHttpBinding(SecurityMode.None);
            var endpointAddress = new EndpointAddress("http://localhost:5000/Calculator");
            calculator = new Service.CalculatorClient(binding, endpointAddress);
        }

        public double Add(double first, double second)
        {
            return calculator.Add(first, second);
        }

        public double Subtract(double first, double second)
        {
            return calculator.Subtract(first, second);
        }

        public double Multiply(double first, double second)
        {
            return calculator.Multiply(first, second);
        }

        public double Divide(double first, double second)
        {
            return calculator.Divide(first, second);
        }
    }
}