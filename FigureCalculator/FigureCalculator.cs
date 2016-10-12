using System;
using Calculator.Client;

namespace FigureCalculator.Service
{
    public class FigureCalculator : IFigureCalculator
    {
        private readonly ICalculatorClient calculatorClient;

        public FigureCalculator(ICalculatorClient calculatorClient)
        {
            this.calculatorClient = calculatorClient;
        }

        public double GetCircleLength(double radius)
        {
            var twoPi = calculatorClient.Multiply(2, Math.PI);
            var length = calculatorClient.Multiply(twoPi, radius);

            return length;
        }

        public double GetCircleArea(double radius)
        {
            var radiusPow2 = calculatorClient.Multiply(radius, radius);
            var area = calculatorClient.Multiply(Math.PI, radiusPow2);

            return area;
        }
    }
}
