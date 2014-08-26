namespace Async.Service
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Async.Contracts;

    public class AsyncService : IAsyncOperation
    {
        async Task<string> IAsyncOperation.PerformOperation(string operation)
        {
            var task = Task.Factory.StartNew(() =>
            {
                var processTime = 3000;
                Console.WriteLine("Processing request...");
                Console.WriteLine(string.Format("   {0}",operation));
                Thread.Sleep(processTime);
                Console.WriteLine("Processing complete responding...");
                return string.Format("{0} completed in {1}ms.", operation, processTime);
            });
            return await task.ConfigureAwait(false);
        }
    }
}
