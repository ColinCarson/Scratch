using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using Contracts;
using Model;
using RavenDBProvider;

namespace DataServices
{
    public class RavenDBService : IRavenDBProvider
    {
        public long PostTrialData(RavenConnection ravenConnection, TrialData trialData)
        {
            var ravenDB = new RavenDB();
            return ravenDB.PostTrialData(ravenConnection, trialData);
        }

        public long BulkInsertTrialData(RavenConnection ravenConnection, IEnumerable<TrialData> trialBatch)
        {
            var ravenDB = new RavenDB();
            return ravenDB.BulkInsertTrialData(ravenConnection, trialBatch);
        }

        public TrialData ReadTrialData(RavenConnection ravenConnection)
        {
            throw new NotImplementedException();
        }
    }
}
