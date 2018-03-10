using System;
using System.Collections.Generic;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherWatch;

namespace WeatherWatchTest
{
    [TestClass]
    public class ForcastParserTest
    {

        //Ensure parser can handle the full expected input
        [TestMethod]
        public void FullXml_ParsesCorrectly()
        {
            List<Forcast> expected = new List<Forcast>
            {
                new Forcast(new DateTime(2018, 3, 10), 26, 34, "Snow"),
                new Forcast(new DateTime(2018, 3, 11), 19, 30, "Partly Cloudy"),
                new Forcast(new DateTime(2018, 3, 12), 9, 29, "Mostly Sunny"),
                new Forcast(new DateTime(2018, 3, 13), 5, 27, "Partly Cloudy"),
                new Forcast(new DateTime(2018, 3, 14), 12, 34, "Partly Cloudy"),
                new Forcast(new DateTime(2018, 3, 15), 20, 41, "Partly Cloudy"),
                new Forcast(new DateTime(2018, 3, 16), 31, 43, "Partly Cloudy"),
                new Forcast(new DateTime(2018, 3, 17), 31, 38, "Scattered Thunderstorms"),
                new Forcast(new DateTime(2018, 3, 18), 23, 35, "Mostly Cloudy"),
                new Forcast(new DateTime(2018, 3, 19), 21, 34, "Partly Cloudy")
            };
            

            string inputXml = @"<query xmlns:yahoo = ""http://www.yahooapis.com/v1/base.rng"" yahoo:count = ""1"" yahoo:created = ""2018-03-10T19:27:11Z"" yahoo:lang = ""en-US"">
           <results>
           <channel>
           <yweather:units xmlns:yweather = ""http://xml.weather.yahoo.com/ns/rss/1.0"" distance = ""mi"" pressure = ""in"" speed = ""mph"" temperature = ""F""/>
                    <title> Yahoo!Weather - Fargo, ND, US </title>
                      <link>
                      http://us.rd.yahoo.com/dailynews/rss/weather/Country__Country/*https://weather.yahoo.com/country/state/city-2402292/
</link>
<description> Yahoo!Weather for Fargo, ND, US </description>
  <language> en - us </language>
  <lastBuildDate> Sat, 10 Mar 2018 01:27 PM CST </lastBuildDate>
  <ttl> 60 </ttl>
  <yweather:location xmlns:yweather = ""http://xml.weather.yahoo.com/ns/rss/1.0"" city = ""Fargo"" country = ""United States"" region = "" ND""/>
  <yweather:wind xmlns:yweather = ""http://xml.weather.yahoo.com/ns/rss/1.0"" chill = ""27"" direction = ""170"" speed = ""11""/>
  <yweather:atmosphere xmlns:yweather = ""http://xml.weather.yahoo.com/ns/rss/1.0"" humidity = ""72"" pressure = ""982.0"" rising = ""0"" visibility = ""16.1""/>
  <yweather:astronomy xmlns:yweather = ""http://xml.weather.yahoo.com/ns/rss/1.0"" sunrise = ""6:50 am"" sunset = ""6:26 pm""/>
  <image>
  <title> Yahoo!Weather </title>
  <width> 142 </width>
  <height> 18 </height>
  <link> http://weather.yahoo.com</link>
<url>
  http://l.yimg.com/a/i/brand/purplelogo//uh/us/news-wea.gif
</url>
  </image>
  <item>
  <title> Conditions for Fargo, ND, US at 12:00 PM CST </title>
     <geo:lat xmlns:geo = ""http://www.w3.org/2003/01/geo/wgs84_pos#""> 46.865089 </geo:lat>
     <geo:long xmlns:geo = ""http://www.w3.org/2003/01/geo/wgs84_pos#""> -96.829224 </geo:long>
     <link>
     http://us.rd.yahoo.com/dailynews/rss/weather/Country__Country/*https://weather.yahoo.com/country/state/city-2402292/
</link>
     <pubDate> Sat, 10 Mar 2018 12:00 PM CST </pubDate>
     <yweather:condition xmlns:yweather = ""http://xml.weather.yahoo.com/ns/rss/1.0"" code = ""30"" date = ""Sat, 10 Mar 2018 12:00 PM CST"" temp = ""33"" text = ""Partly Cloudy""/>
     <yweather:forecast xmlns:yweather = ""http://xml.weather.yahoo.com/ns/rss/1.0"" code = ""16"" date = ""10 Mar 2018"" day = ""Sat"" high = ""34"" low = ""26"" text = ""Snow""/>
     <yweather:forecast xmlns:yweather = ""http://xml.weather.yahoo.com/ns/rss/1.0"" code = ""30"" date = ""11 Mar 2018"" day = ""Sun"" high = ""30"" low = ""19"" text = ""Partly Cloudy""/>
     <yweather:forecast xmlns:yweather = ""http://xml.weather.yahoo.com/ns/rss/1.0"" code = ""34"" date = ""12 Mar 2018"" day = ""Mon"" high = ""29"" low = ""9"" text = ""Mostly Sunny""/>
     <yweather:forecast xmlns:yweather = ""http://xml.weather.yahoo.com/ns/rss/1.0"" code = ""30"" date = ""13 Mar 2018"" day = ""Tue"" high = ""27"" low = ""5"" text = ""Partly Cloudy""/>
     <yweather:forecast xmlns:yweather = ""http://xml.weather.yahoo.com/ns/rss/1.0"" code = ""30"" date = ""14 Mar 2018"" day = ""Wed"" high = ""34"" low = ""12"" text = ""Partly Cloudy""/>
     <yweather:forecast xmlns:yweather = ""http://xml.weather.yahoo.com/ns/rss/1.0"" code = ""30"" date = ""15 Mar 2018"" day = ""Thu"" high = ""41"" low = ""20"" text = ""Partly Cloudy""/>
     <yweather:forecast xmlns:yweather = ""http://xml.weather.yahoo.com/ns/rss/1.0"" code = ""30"" date = ""16 Mar 2018"" day = ""Fri"" high = ""43"" low = ""31"" text = ""Partly Cloudy""/>
     <yweather:forecast xmlns:yweather = ""http://xml.weather.yahoo.com/ns/rss/1.0"" code = ""47"" date = ""17 Mar 2018"" day = ""Sat"" high = ""38"" low = ""31"" text = ""Scattered Thunderstorms""/>
     <yweather:forecast xmlns:yweather = ""http://xml.weather.yahoo.com/ns/rss/1.0"" code = ""28"" date = ""18 Mar 2018"" day = ""Sun"" high = ""35"" low = ""23"" text = ""Mostly Cloudy""/>
     <yweather:forecast xmlns:yweather = ""http://xml.weather.yahoo.com/ns/rss/1.0"" code = ""30"" date = ""19 Mar 2018"" day = ""Mon"" high = ""34"" low = ""21"" text = ""Partly Cloudy""/>
     <description>
     <![CDATA[<img src = ""http://l.yimg.com/a/i/us/we/52/30.gif""/> <BR/> <b> Current Conditions:</b> <BR/> Partly Cloudy <BR/> <BR/> <b> Forecast:</b> <BR/> Sat - Snow.High: 34Low: 26 <BR/> Sun - Partly Cloudy.High: 30Low: 19 <BR/> Mon - Mostly Sunny.High: 29Low: 9 <BR/> Tue - Partly Cloudy.High: 27Low: 5 <BR/> Wed - Partly Cloudy.High: 34Low: 12 <BR/> <BR/> <a href = ""http://us.rd.yahoo.com/dailynews/rss/weather/Country__Country/*https://weather.yahoo.com/country/state/city-2402292/""> Full Forecast at Yahoo!Weather </a> <BR/> <BR/> <BR/> ]]>
     </description>
     <guid isPermaLink = ""false""/>
     </item>
     </channel>
     </results>
     </query>";

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(inputXml);

            var result = ForcastParser.parseForcasts(xmlDoc, "yweather:forecast");
            CollectionAssert.AreEqual(expected, result);
        }
    }
}
