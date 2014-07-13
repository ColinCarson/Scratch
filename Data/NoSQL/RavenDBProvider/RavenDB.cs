using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Contracts;
using Model;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Embedded;

namespace RavenDBProvider
{
    public interface IRavenDB
    {
        void InitializeDocumentStore(string serverUrl);
        IDocumentSession OpenSession(string databaseName);
    }

    public class RavenDB : IRavenDB, IRavenDBProvider
    {
        private DocumentStore documentStore;


        public void InitializeDocumentStore(string serverUrl)
        {
            documentStore = new DocumentStore { Url = serverUrl };
            documentStore.Initialize();
        }

        public IDocumentSession OpenSession(string databaseName)
        {
            return documentStore.OpenSession(new OpenSessionOptions { Database = databaseName });
        }

        public long PostTrialData(RavenConnection ravenConnection, TrialData trialData)
        {
            var watch = new Stopwatch();
            watch.Start();

            InitializeDocumentStore(ravenConnection.ServerUrl);
            var session = documentStore.OpenSession(ravenConnection.DatabaseName);

            session.Store(trialData);
            session.SaveChanges();

            watch.Stop();
            return watch.ElapsedMilliseconds;
        }

        public long BulkInsertTrialData(RavenConnection ravenConnection, IEnumerable<TrialData> trialBatch)
        {
            var watch = new Stopwatch();
            watch.Start();
            
            InitializeDocumentStore(ravenConnection.ServerUrl);
            using(var bulkInsert = documentStore.BulkInsert(ravenConnection.DatabaseName))
            {
                foreach (var item in trialBatch)
                    bulkInsert.Store(item);
            }

            watch.Stop();
            return watch.ElapsedMilliseconds;
        }

        public long BulkInsertTrialDataEmbedded(RavenConnection ravenConnection, IEnumerable<TrialData> trialBatch)
        {
            var watch = new Stopwatch();
            watch.Start();

            var eds = new EmbeddableDocumentStore { DataDirectory = @"C:\Projects\EDSTest\EDSData" };
            eds.Initialize();
            using (var bulkInsert = eds.BulkInsert())
            {
                foreach (var item in trialBatch)
                    bulkInsert.Store(item);
            }

            watch.Stop();
            return watch.ElapsedMilliseconds;
        }

        public TrialData ReadTrialData(RavenConnection ravenConnection)
        {
            throw new NotImplementedException();
        }
    }
}
