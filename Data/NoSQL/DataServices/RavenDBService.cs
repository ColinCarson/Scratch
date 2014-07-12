using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using Contracts;
using RavenDBProvider;

namespace DataServices
{
    public class RavenDBService : IRavenDBProvider
    {
        public void OpenSession(string databasename)
        {
            var ravenDB = new RavenDB();
            ravenDB.OpenSession(databasename);
        }
    }
}
