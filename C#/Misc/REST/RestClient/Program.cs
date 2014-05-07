using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.ServiceModel.Web;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;
using RestCommon;

namespace RestClient
{
    class Program
    {
        static string uri;

        static void Main(string[] args)
        {
            uri = "http://localhost:2902/RestService.svc/Person";

            Console.WriteLine("Calling /Person - read all");
            Console.WriteLine(CallReadPersons());
            Console.ReadLine();

            Console.WriteLine("Calling /Person/1 - read by id");
            Console.WriteLine(CallReadPersonsWithParameters("1"));
            Console.ReadLine();

            Console.WriteLine("Calling /Person - create new");
            Console.WriteLine(CallNewPerson());
            Console.ReadLine();
        }

        private static string CallReadPersons()
        {
            var myReq = (HttpWebRequest)WebRequest.Create(uri);            
            myReq.Method = "GET";
            var WebResp = (HttpWebResponse)myReq.GetResponse();
            return ParseResponseStream(WebResp.GetResponseStream());     
        }

        private static string CallReadPersonsWithParameters(string ID)
        {
            var myReq = (HttpWebRequest)WebRequest.Create(string.Format("{0}/{1}", uri, ID));
            myReq.Method = "GET";
            var WebResp = (HttpWebResponse)myReq.GetResponse();
            return ParseResponseStream(WebResp.GetResponseStream());     
        }

        private static string CallNewPerson()
        {
            var myReq = (HttpWebRequest)WebRequest.Create(uri);
            myReq.Method = "PUT";
            StreamWriter stm = new StreamWriter(myReq.GetRequestStream(), Encoding.UTF8);
            stm.Write("Test");
            stm.Flush();
            stm.Close();

            var WebResp = (HttpWebResponse)myReq.GetResponse();
            return ParseResponseStream(WebResp.GetResponseStream());  
        }

        private static string GetSerializedPerson()
        {
            var xml = string.Empty;

            Person person = new Person() { Name = "testPerson", Age = 24, ID = 12345, Active = true };

            XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(person.GetType());
            using (MemoryStream memStream = new MemoryStream())
            {
                XmlTextWriter xmlWriter = new XmlTextWriter(memStream, Encoding.UTF8);
                xmlWriter.Formatting = Formatting.Indented;
                xmlWriter.Indentation = 1;
                xmlWriter.IndentChar = Convert.ToChar(9);
                ser.Serialize(xmlWriter, person);
                xmlWriter.Close();
                memStream.Close();
                xml = Encoding.UTF8.GetString(memStream.GetBuffer());
                xml = xml.Substring(xml.IndexOf(Convert.ToChar(60)));
                xml = xml.Substring(0, (xml.LastIndexOf(Convert.ToChar(62)) + 1));
            }
            return xml;
        }


        private static string ParseResponseStream(Stream stream)
        {
            var encode = System.Text.Encoding.GetEncoding("utf-8");
            var readStream = new StreamReader(stream, encode);
            return readStream.ReadToEnd();            
        }
    }
}
