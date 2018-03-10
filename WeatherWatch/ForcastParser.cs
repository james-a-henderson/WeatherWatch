using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WeatherWatch
{
    public class ForcastParser
    {
        public static List<Forcast> parseForcasts (XmlDocument document, string elementName)
        {

            XmlNodeList elemList = document.GetElementsByTagName(elementName);
            List<Forcast> forcastList = new List<Forcast>();
            foreach(XmlNode elem in elemList)
            {
                Forcast forcast = new Forcast();
                forcast.ForcastDate = DateTime.ParseExact(elem.Attributes["date"].Value,
                                                          "d MMM yyyy", System.Globalization.CultureInfo.InvariantCulture);
                forcast.LowTemp = int.Parse(elem.Attributes["low"].Value);
                forcast.HighTemp = int.Parse(elem.Attributes["high"].Value);
                forcast.ForcastDetails = elem.Attributes["text"].Value;

                forcastList.Add(forcast);
            }

            return forcastList;
        }
    }
}
