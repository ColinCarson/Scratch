namespace Async.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main(string[] args)
        {
            GetResult();
            Console.ReadLine();
        }

        private async static void GetResult()
        {
            var client = new Proxy("AsyncService");
            Console.WriteLine("Calling AsyncService DoThings(withStuff)");
            var task = Task.Factory.StartNew(() => client.PerformOperation("DoThings(withStuff)"));

            var str = await task;
            str.ContinueWith(e =>
            {
                if (e.IsCompleted)
                {
                    Console.WriteLine(str.Result);
                }
            });
            
            Console.WriteLine("Waiting for the result");
        }
    }
}
