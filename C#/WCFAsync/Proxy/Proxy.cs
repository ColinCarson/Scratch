namespace Async.Client
{
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.Threading.Tasks;
    using Async.Service;
    using Async.Contracts;

    public class Proxy : ClientBase<IAsyncOperation>, IAsyncOperation
    {
        public Proxy()
        {
        }

        public Proxy(string endpointConfigurationName) :
            base(endpointConfigurationName)
        {
        }

        public Task<string> PerformOperation(string operation)
        {
            return Channel.PerformOperation(operation);
        }
    }
}