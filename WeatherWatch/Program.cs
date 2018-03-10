using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WeatherWatch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter city: ");
            string city = Console.ReadLine();
            string apiUrl = ConfigurationManager.AppSettings["ApiURL"];
            string formatUrl = string.Format(apiUrl, city);

            XmlDocument document = new XmlDocument();
            document.Load(formatUrl);

            List<Forcast> forcasts = ForcastParser.parseForcasts(document, ConfigurationManager.AppSettings["ForcastElementName"]);
            List<string> alerts = new List<string>();
            foreach(Forcast cast in forcasts)
            {
                alerts.AddRange(AlertGenerator.generateAlerts(cast));
            }

            if(alerts.Count == 0)
            {
                Console.WriteLine("No Alerts");
            }

            foreach(string alert in alerts)
            {
                Console.WriteLine(alert);
            }

            //Wait for input to end program
            Console.ReadLine();
        }
    }
}
