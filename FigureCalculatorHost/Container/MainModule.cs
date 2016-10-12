using Calculator.Client;
using FigureCalculator.Service;
using Ninject.Extensions.Conventions;
using Ninject.Modules;

namespace FigureCalculator.Host.Container
{
    public class MainModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind(x => x
                            .FromThisAssembly()
                            .SelectAllClasses()
                            .Join
                            .FromAssemblyContaining<IFigureCalculator>()
                            .SelectAllClasses()
                            .Join
                            .FromAssemblyContaining<ICalculatorClient>()
                            .SelectAllClasses()
                            .BindAllInterfaces()
                            .Configure(c => c.InSingletonScope())
                            );
        }
    }
}
