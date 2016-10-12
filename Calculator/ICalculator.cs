using System.ServiceModel;

namespace Calculator.Service
{
    [ServiceContract]
    public interface ICalculator
    {
        [OperationContract]
        double Add(double first, double second);

        [OperationContract]
        double Subtract(double first, double second);

        [OperationContract]
        double Multiply(double first, double second);

        [OperationContract]
        double Divide(double first, double second);
    }
}
