using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using RestCommon;

namespace RestSvc
{
    [ServiceContract]
    public interface IRestService
    {
        [OperationContract(Name="DisplayGreeting")]
        [WebInvoke(UriTemplate = "/Hello", Method = "GET")]
        string DisplayGreeting();

        [OperationContract(Name = "GetPerson")]
        [WebGet(UriTemplate = "/Person/{ID}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Person GetPerson(string ID);

        [OperationContract(Name = "ReadPersons")]
        [WebInvoke(UriTemplate = "/Person", Method="GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        IEnumerable<Person> ReadAllPersons();

        [OperationContract(Name = "NewPerson")]
        [WebInvoke(UriTemplate = "/Person", Method = "PUT")]//, RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Json)]
        string NewPerson(string person);
    }
}
