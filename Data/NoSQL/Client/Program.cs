using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Client.RavenDBProvider;
using RavenDBProvider;
using Model;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //InsertSingleItem();
            InsertBatch();

            Console.WriteLine();
            Console.WriteLine("Press ENTER to exit.");
            Console.ReadLine();
        }


        static void InsertSingleItem()
        {
            Console.WriteLine("Inserting single trial data object...");

            var parameters = new List<Client.RavenDBProvider.Parameter> {new Client.RavenDBProvider.Parameter { Name = "GBP.TotalReturnIndex", TrialNumber = 1, Value = 0.5 }, 
                                                                         new Client.RavenDBProvider.Parameter { Name = "GBP.TotalReturnIndex", TrialNumber = 2, Value = 0.6 },
                                                                         new Client.RavenDBProvider.Parameter { Name = "GBP.TotalReturnIndex", TrialNumber = 3, Value = 0.5 }};
            var trialData = new Client.RavenDBProvider.TrialData { StressNumber = 1, Parameters = parameters.ToArray() };

            var ravenConnection = new Client.RavenDBProvider.RavenConnection { ServerUrl = "http://localhost:8081/", DatabaseName = "TrialData" };
            using (var ravenDB = new RavenDBProviderClient())
            {
                var elapsed = ravenDB.PostTrialData(ravenConnection, trialData);
                Console.WriteLine("Operation complete in {0}ms", elapsed);
            }
        }


        static void InsertBatch()
        {
            Console.WriteLine("Inserting a bunch of trial data objects...");
            
            var trialBatch = new List<Model.TrialData>();
            var random = new Random();

            for(int i=1; i<=1000000; i++)
            {
                var parameters = new List<Model.Parameter> {new Model.Parameter { Name = "GBP.TotalReturnIndex", TrialNumber = 1, Value = random.NextDouble() }, 
                                                      new Model.Parameter { Name = "GBP.TotalReturnIndex", TrialNumber = 2, Value = random.NextDouble() },
                                                      new Model.Parameter { Name = "GBP.TotalReturnIndex", TrialNumber = 3, Value = random.NextDouble() }};
                var trialData = new Model.TrialData { StressNumber = i, Parameters = parameters.ToArray() };

                trialBatch.Add(trialData);
            }

            var ravenConnection = new Model.RavenConnection { ServerUrl = "http://localhost:8081/", DatabaseName = "TrialData" };
            var ravenDB = new RavenDB();
            //var elapsed = ravenDB.BulkInsertTrialData(ravenConnection, trialBatch);
            var elapsed = ravenDB.BulkInsertTrialDataEmbedded(ravenConnection, trialBatch);
            Console.WriteLine("Operation complete in {0}ms", elapsed);
        }
    }
}
