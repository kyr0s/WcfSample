using System.ServiceModel;

namespace FigureCalculator.Service
{
    [ServiceContract]
    public interface IFigureCalculator
    {
        [OperationContract]
        double GetCircleLength(double radius);

        [OperationContract]
        double GetCircleArea(double radius);
    }
}
