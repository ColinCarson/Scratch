using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

using RestCommon;

using System.Data;
using System.Data.Linq;

namespace RestSvc
{
    public class RestService : IRestService
    {
        public string DisplayGreeting()
        {
            return "Hello!";
        }

        public string NewPerson(string person)
        {
            return person;
        }

        public Person GetPerson(string ID)
        {
            var restDBDataContext = new RestDBDataContext(GetConnectionString());
            var personResults = restDBDataContext.ReadPersonByID(Convert.ToInt32(ID));
            return personResults.First();            
        }

        public IEnumerable<Person> ReadAllPersons()
        {
            var restDBDataContext = new RestDBDataContext(GetConnectionString());
            var personResults = restDBDataContext.ReadAllPersons();
            return personResults;
        }

        static private string GetConnectionString()
        {
           return @"Data Source=(local)\SQLExpress;Initial Catalog=RestDB;Integrated Security=SSPI;";
        }
    }
}

