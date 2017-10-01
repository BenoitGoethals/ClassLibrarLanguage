using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;

namespace ClassLibrarLanguage
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(ClassLibrarLanguage.QuestionsService)))
            {
                string address = "http://localhost:3888/IQuestionsService";
                Binding binding = new BasicHttpBinding();
                Type contract = typeof(IQuestionsService);

                host.AddServiceEndpoint(contract, binding, address);

                ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
                host.Description.Behaviors.Add(behavior);


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
            }
        }
    }
}