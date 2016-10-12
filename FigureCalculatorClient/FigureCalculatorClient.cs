using System.ServiceModel;

namespace FigureCalculator.Client
{
    public class FigureCalculatorClient : IFigureCalculatorClient
    {
        private readonly Service.FigureCalculatorClient calculator;

        public FigureCalculatorClient()
        {
            var binding = new WSHttpBinding(SecurityMode.None);
            var endpointAddress = new EndpointAddress("http://localhost:5001/FigureCalculator");
            calculator = new Service.FigureCalculatorClient(binding, endpointAddress);
        }

        public double GetCircleLength(double radius)
        {
            return calculator.GetCircleLength(radius);
        }

        public double GetCircleArea(double radius)
        {
            return calculator.GetCircleArea(radius);
        }
    }
}
