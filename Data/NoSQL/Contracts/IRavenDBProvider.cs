using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using Model;

namespace Contracts
{
    [ServiceContract]
    public interface IRavenDBProvider
    {
        [OperationContract]
        long PostTrialData(RavenConnection ravenConnection, TrialData trialData);

        [OperationContract]
        long BulkInsertTrialData(RavenConnection ravenConnection, IEnumerable<TrialData> trialBatch);

        [OperationContract]
        TrialData ReadTrialData(RavenConnection ravenConnection);
    }
}
