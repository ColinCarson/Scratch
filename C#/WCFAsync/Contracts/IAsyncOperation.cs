namespace Async.Contracts
{
    using System.ServiceModel;
    using System.Threading.Tasks;

    [ServiceContract]
    public interface IAsyncOperation
    {
        [OperationContract]
        Task<string> PerformOperation(string operation);
    }
}