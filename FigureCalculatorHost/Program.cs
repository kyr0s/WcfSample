﻿using System;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Description;
using Calculator.Client;
using FigureCalculator.Host.Container;
using FigureCalculator.Service;

namespace FigureCalculator.Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var baseAddress = new Uri("http://localhost:5001/");
            var selfHost = new ServiceHost(typeof(Service.FigureCalculator), baseAddress);

            try
            {
                selfHost.AddServiceEndpoint(typeof(IFigureCalculator), new WSHttpBinding(SecurityMode.None), "FigureCalculator");

                var container = DependencyInjectionContainerFactory.CreateNinjectContainer(new MainModule());
                var diBehavior = new DependencyInjectionBehavior(container);
                selfHost.Description.Behaviors.Add(diBehavior);

                var serviceMetadataBehavior = new ServiceMetadataBehavior { HttpGetEnabled = true };
                selfHost.Description.Behaviors.Add(serviceMetadataBehavior);

                var serviceAuthenticationBehavior = new ServiceAuthenticationBehavior {AuthenticationSchemes = AuthenticationSchemes.None | AuthenticationSchemes.Anonymous};
                selfHost.Description.Behaviors.RemoveAll<ServiceAuthenticationBehavior>();
                selfHost.Description.Behaviors.Add(serviceAuthenticationBehavior);

                selfHost.Open();
                Console.WriteLine("Press any key to stop service.");
                Console.WriteLine();
                Console.ReadKey();

                selfHost.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception handled: {0}", ex.Message);
                selfHost.Abort();
                Console.ReadKey();
            }
        }
    }
}
