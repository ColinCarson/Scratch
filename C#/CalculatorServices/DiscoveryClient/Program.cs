using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Discovery;
using System.Text;
using CalculatorClient.Calculator;

namespace DiscoveryApp
{
    class Program
    {
        static EndpointAddress FindCalculatorServiceAddress()
        {
            DiscoveryClient discoveryClient = new DiscoveryClient(new UdpDiscoveryEndpoint());
            FindResponse findResponse = discoveryClient.Find(new FindCriteria(typeof(ICalculator)));

            if (findResponse.Endpoints.Count > 0)
            {
                return findResponse.Endpoints[0].Address;
            }
            else
            {
                return null;
            }
        }

        static void InvokeCalculatorService(EndpointAddress endpointAddress)
        {
            CalculatorClient.Calculator.CalculatorClient client = new CalculatorClient.Calculator.CalculatorClient();
            client.Endpoint.Address = endpointAddress;

            Console.WriteLine("Invoking CalculatorService at {0}", endpointAddress);

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
        static void Main(string[] args)
        {
            EndpointAddress endpointAddress = FindCalculatorServiceAddress();

            if (endpointAddress != null)
            {
                InvokeCalculatorService(endpointAddress);
            }

            Console.WriteLine("Press <ENTER> to exit.");
            Console.ReadLine();

        }
    }
}
