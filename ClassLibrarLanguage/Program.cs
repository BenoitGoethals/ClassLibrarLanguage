using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using Autofac;
using Autofac.Integration.Wcf;
using ClassLibrarLanguage.helpers;

namespace ClassLibrarLanguage
{
    public class Program
    {
        static void Main(string[] args)
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<IQuestionsService>();
            builder.RegisterType<LoaderCsv>().As<ILoader>();
            builder.RegisterType<QuestFactory>().As<IQuestFactory>();

            using (var container = builder.Build())
            {
                ServiceHost host = new ServiceHost(typeof(ClassLibrarLanguage.QuestionsService));
                string address = "http://localhost:3888/IQuestionsService";
                Binding binding = new BasicHttpBinding();
                Type contract = typeof(IQuestionsService);

                host.AddServiceEndpoint(contract, binding, address);
     
                ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
                host.Description.Behaviors.Add(behavior);
                host.AddDependencyInjectionBehavior<IQuestionsService>(container);

                host.AddServiceEndpoint(
                    typeof(IMetadataExchange),
                    MetadataExchangeBindings.CreateMexHttpBinding(),
                    "http://localhost:3888/IQuestionsService/mex/"
                );

                host.Open();

                Console.WriteLine("Service up and running at:");
                foreach (var ea in host.Description.Endpoints)
                {
                    Console.WriteLine(ea.Address);
                }

                Console.ReadLine();
                host.Close();
                Environment.Exit(0);
            }
        }
    }
}