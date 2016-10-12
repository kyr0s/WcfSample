using Ninject;
using Ninject.Modules;

namespace FigureCalculator.Host.Container
{
    public class DependencyInjectionContainerFactory
    {
        public static IContainer CreateNinjectContainer(params INinjectModule[] modules)
        {
            var container = new StandardKernel(modules);
            var wrapper = new NinjectContainerWrapper(container);
            return wrapper;
        }
    }
}
