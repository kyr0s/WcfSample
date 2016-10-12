using System;
using Ninject;

namespace FigureCalculator.Host.Container
{
    public class NinjectContainerWrapper : IContainer
    {
        private readonly IKernel container;

        public NinjectContainerWrapper(IKernel container)
        {
            this.container = container;
        }

        public object Get(Type type)
        {
            return container.TryGet(type);
        }
    }
}