using System;

namespace FigureCalculator.Host.Container
{
    public interface IContainer
    {
        object Get(Type type);
    }
}
