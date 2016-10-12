using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace FigureCalculator.Host.Container
{
    public class DependencyInjectionBehavior : IServiceBehavior
    {
        private readonly IContainer container;

        public DependencyInjectionBehavior(IContainer container)
        {
            this.container = container;
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (var cdb in serviceHostBase.ChannelDispatchers)
            {
                var cd = cdb as ChannelDispatcher;

                if (cd != null)
                {
                    foreach (var ep in cd.Endpoints)
                    {
                        ep.DispatchRuntime.InstanceProvider = new DependencyInjectionInstanceProvider(container, serviceDescription.ServiceType);
                    }
                }
            }

        }

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }
    }
}
