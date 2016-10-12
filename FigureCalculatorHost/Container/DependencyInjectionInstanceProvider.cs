using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace FigureCalculator.Host.Container
{
    public class DependencyInjectionInstanceProvider : IInstanceProvider
    {
        private readonly IContainer container;
        private readonly Type serviceType;

        public DependencyInjectionInstanceProvider(IContainer container, Type serviceType)
        {
            this.container = container;
            this.serviceType = serviceType;
        }

        public object GetInstance(InstanceContext instanceContext)
        {
            return GetInstance(instanceContext, null);
        }

        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            return container.Get(serviceType);
        }

        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
        }
    }
}