using System;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Discovery;
using CalculatorClient.Calculator;

namespace Client
{
    class Program
    {
        static void InvokeCalculatorService(EndpointAddress endpointAddress)
        {
            CalculatorClient.Calculator.CalculatorClient client = new CalculatorClient.Calculator.CalculatorClient(new NetTcpBinding(), endpointAddress);
            Console.WriteLine("Invoking CalculatorService at {0}", endpointAddress.Uri);
            Console.WriteLine();

            double value1 = 100.00D;
            double value2 = 15.99D;

            double result = client.Add(value1, value2);
            Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result);

            result = client.Subtract(value1, value2);
            Console.WriteLine("Subtract({0},{1}) = {2}", value1, value2, result);

            result = client.Multiply(value1, value2);
            Console.WriteLine("Multiply({0},{1}) = {2}", value1, value2, result);

            result = client.Divide(value1, value2);
            Console.WriteLine("Divide({0},{1}) = {2}", value1, value2, result);
            Console.WriteLine();

            client.Close();
        }

        public static void Main()
        {
            Uri probeEndpointAddress = new Uri("net.tcp://localhost:8001/Probe");
            DiscoveryEndpoint discoveryEndpoint = new DiscoveryEndpoint(new NetTcpBinding(), new EndpointAddress(probeEndpointAddress));

            DiscoveryClient discoveryClient = new DiscoveryClient(discoveryEndpoint);            

            Console.WriteLine("Finding ICalculatorService endpoints using the proxy at {0}", probeEndpointAddress);
            Console.WriteLine();

            try
            {
                FindResponse findResponse = discoveryClient.Find(new FindCriteria(typeof(ICalculator)));

                Console.WriteLine("Found {0} ICalculatorService endpoint(s).", findResponse.Endpoints.Count);
                Console.WriteLine();

                if (findResponse.Endpoints.Count > 0)
                {
                    InvokeCalculatorService(findResponse.Endpoints[0].Address);
                }
            }
            catch (TargetInvocationException)
            {
                Console.WriteLine("This client was unable to connect to and query the proxy. Ensure that the proxy is up and running.");
            }
        }
    }
}
