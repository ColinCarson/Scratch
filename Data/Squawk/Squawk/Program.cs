using System;
using System.Collections.Generic;
using System.Diagnostics;
using Raven.Abstractions.Data;
using Raven.Client;
using Raven.Client.Connection;
using Raven.Client.Document;
using Raven.Client.Extensions;

namespace Squawk
{
    using System.Reflection;
    using log4net;

    class Program
    {
        private const string serverUrl = "http://localhost:8081";
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();            
            LogMessage("Start squawking");

            var numberOfTrials = int.Parse(args[0]);
            var dropDatabase = bool.Parse(args[1]);

            var databaseName = string.Format("TrialData-{0}", Guid.NewGuid());
            CreateRavenStore(databaseName);
            StoreTrialData(databaseName, numberOfTrials);
                        
            if(dropDatabase)
                DropRavenStore(databaseName);

            LogMessage("Stop squawking");
        }

        private static void CreateRavenStore(string databaseName)
        {
            var watch = new Stopwatch();
            watch.Start();
            LogMessage("----------------------------------------------------------------------------------------------------------");
            LogMessage(string.Format("CreateRavenStore({0})", databaseName));
            
            LogMessage(string.Format("Connecting to RavenDB instance: {0}", serverUrl));            
            IDocumentStore documentStore = new DocumentStore { Url = serverUrl };
            
            LogMessage("Initializing document store");
            documentStore.Initialize();
            
            LogMessage(string.Format("Creating database {0}", databaseName));
            documentStore.DatabaseCommands.EnsureDatabaseExists(databaseName);

            watch.Stop();
            LogMessage(string.Format("{0} Created in {1}:{2}:{3}.{4}", databaseName, watch.Elapsed.Hours, watch.Elapsed.Minutes, watch.Elapsed.Seconds, watch.Elapsed.Milliseconds));
            LogMessage("----------------------------------------------------------------------------------------------------------");
        }


        private static void StoreTrialData(string databaseName, int numberOfTrials)
        {
            var watch = new Stopwatch();
            
            LogMessage("----------------------------------------------------------------------------------------------------------");
            LogMessage(string.Format("StoreTrialData({0}, {1})", databaseName, numberOfTrials));


            LogMessage(string.Format("Generating {0} records for insertion", numberOfTrials));
            watch.Start();
            var trialBatch = new List<TrialData>();
            var random = new Random();
            for (var i = 1; i <= numberOfTrials; i++)
            {
                var parameters = new List<Parameter> {new Parameter { Name = "GBP.TotalReturnIndex", TrialNumber = 1, Value = random.NextDouble() }, 
                                                      new Parameter { Name = "GBP.TotalReturnIndex", TrialNumber = 2, Value = random.NextDouble() },
                                                      new Parameter { Name = "GBP.TotalReturnIndex", TrialNumber = 3, Value = random.NextDouble() }};
                var trialData = new TrialData { StressNumber = i, Parameters = parameters.ToArray() };

                trialBatch.Add(trialData);
            }
            watch.Stop();
            LogMessage(string.Format("Data generated in {1}:{2}:{3}.{4}", numberOfTrials, watch.Elapsed.Hours, watch.Elapsed.Minutes, watch.Elapsed.Seconds, watch.Elapsed.Milliseconds));
            
            LogMessage(string.Format("Connecting to RavenDB instance: {0}", serverUrl));
            IDocumentStore documentStore = new DocumentStore { Url = serverUrl };

            LogMessage("Initializing document store");
            documentStore.Initialize();

            watch.Reset();
            watch.Start();
            LogMessage("Starting bulk insert");
            var builkInsertOptions = new BulkInsertOptions
            {
                BatchSize = 10000,
                CheckForUpdates = false,
                CheckReferencesInIndexes = false
            };
            using (var bulkInsert = documentStore.BulkInsert(databaseName, builkInsertOptions))
            {
                foreach (var item in trialBatch)
                    bulkInsert.Store(item);
            }

            watch.Stop();
            LogMessage(string.Format("Inserted {0} records in {1}:{2}:{3}.{4}", numberOfTrials, watch.Elapsed.Hours, watch.Elapsed.Minutes, watch.Elapsed.Seconds, watch.Elapsed.Milliseconds));
            LogMessage("----------------------------------------------------------------------------------------------------------");
        }

        private static void DropRavenStore(string databaseName)
        {
            var watch = new Stopwatch();
            watch.Start();
            LogMessage("----------------------------------------------------------------------------------------------------------");
            LogMessage(string.Format("DropRavenStore({0})", databaseName));
            
            LogMessage(string.Format("Connecting to RavenDB instance: {0}", serverUrl));
            IDocumentStore documentStore = new DocumentStore { Url = serverUrl };
           
            LogMessage("Initializing document store");
            documentStore.Initialize();
            
            LogMessage(string.Format("Deleting database {0}", databaseName));            
            var databaseCommands = documentStore.DatabaseCommands;
            var relativeUrl = "/admin/databases/" + databaseName;
            relativeUrl += "?hard-delete=true";
            var serverClient = databaseCommands.ForSystemDatabase() as ServerClient;            
            var httpJsonRequest = serverClient.CreateRequest("DELETE", relativeUrl);
            httpJsonRequest.ExecuteRequest();

            watch.Stop();
            LogMessage(string.Format("{0} Deleted in {1}:{2}:{3}.{4}", databaseName, watch.Elapsed.Hours, watch.Elapsed.Minutes, watch.Elapsed.Seconds, watch.Elapsed.Milliseconds));
            LogMessage("----------------------------------------------------------------------------------------------------------");
        }

        private static void LogMessage(string message)
        {
            Console.WriteLine(message);
            Logger.Info(message);
        }
    }
}
