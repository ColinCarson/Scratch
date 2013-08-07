using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EFTriggers.EFClasses;

namespace EFTriggers
{
    class Program
    {
        static void Main(string[] args)
        {
            var configurationId = Guid.NewGuid();

            var timeStamp = DateTime.Now;

            var configuration = new Configuration
            {
                ConfigurationId = Guid.NewGuid(),
                Name = string.Format("Test Configuration {0}", timeStamp),
                CreatedBy = "Test",
                CreatedOn = timeStamp,
                UpdatedBy = "Test",
                UpdatedOn = timeStamp,
            };

            using (var context = new EfTestDataContext())
            {
                context.Configurations.Add(configuration);
                context.SaveChanges();

                configuration.Name = string.Format("New Name {0}", timeStamp);
                context.SaveChanges();

                context.Configurations.Remove(configuration);
                context.SaveChanges();
            }

            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();
        }
    }
}
