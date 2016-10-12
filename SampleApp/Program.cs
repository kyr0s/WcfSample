using System;
using System.Collections.Generic;
using System.Globalization;
using FigureCalculator.Client;

namespace SampleApp
{
    class Program
    {
        private static readonly Dictionary<CalculateMode, Func<FigureCalculatorClient, double, double>> calculateMethods = new Dictionary<CalculateMode, Func<FigureCalculatorClient, double, double>>
        {
            {CalculateMode.Length, (c, r) => c.GetCircleLength(r)},
            {CalculateMode.Area, (c, r) => c.GetCircleArea(r)},
        };

        static void Main(string[] args)
        {
            var calculator = new FigureCalculatorClient();

            while (true)
            {
                Console.WriteLine("What do you want to calculate? (1 - for circle length, 2 - for circle area, Ctrl + C - for exit)");

                var modeStr = Console.ReadLine();
                CalculateMode mode; Func<FigureCalculatorClient, double, double> calculateFunc;
                if (!Enum.TryParse(modeStr, out mode) || !calculateMethods.TryGetValue(mode, out calculateFunc))
                {
                    Console.WriteLine("Incorrect calculate mode. Try again.");
                    continue;
                }

                Console.WriteLine("Input circle radius");
                var radiusStr = (Console.ReadLine()?? string.Empty).Replace(',', '.');
                double radius;
                if (!double.TryParse(radiusStr, NumberStyles.Any, new CultureInfo("en-US"), out radius))
                {
                    Console.WriteLine("Incorrect radius value. Try again.");
                    continue;
                }

                var result = calculateFunc(calculator, radius);
                Console.WriteLine($"Result is {result}");
                Console.WriteLine();
            }
        }
    }
}
