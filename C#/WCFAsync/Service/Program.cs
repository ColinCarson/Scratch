namespace Async.Service
{
    using System;
    using System.ServiceModel;
    using System.Threading;
    using System.Threading.Tasks;
    using Async.Contracts;

    class Program
    {
        static void Main(string[] args)
        {
            var svcHost = new ServiceHost(typeof (AsyncService));
            svcHost.Open();
            Console.WriteLine("Async Service running...");
            Console.ReadLine();
        }
    }
}