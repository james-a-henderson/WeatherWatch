using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherWatch
{

    public static class AlertGenerator
    {

        public const int FREEZING_TEMP_THRESHOLD = 32;
        public const string FREEZING_TEMP_ALERT = "Freezing Temperature Alert for {0}";

        public const int HIGH_HEAT_THRESHOLD = 85;
        public const string HIGH_HEAT_ALERT = "High Heat Alert for {0}";

        public const string RAIN_STRING = "rain";
        public const string RAIN_ALERT = "Rain Alert for {0}";

        public const string THUNDERSTORM_STRING = "thunderstorm";
        public const string THUNDERSTORM_ALERT = "Thunderstorm Alert for {0}";

        public const string SNOW_STRING = "snow";
        public const string SNOW_ALERT = "Snow Alert for {0}";

        public const string ICE_STRING = "ice";
        public const string ICE_ALERT = "Ice Alert for {0}";

        public static List<string> generateAlerts(Forcast forcast)
        {
            if (forcast.LowTemp > forcast.HighTemp)
            {
                throw new ArgumentException("The Low Temperature cannot be higher than the high temperature");
            }

            List<string> output = new List<string>();
            string formatDate = forcast.ForcastDate.ToString("dddd, MMMM d");

            if(forcast.LowTemp <= FREEZING_TEMP_THRESHOLD)
            {
                output.Add(string.Format(FREEZING_TEMP_ALERT, formatDate));
            }

            if(forcast.HighTemp >= HIGH_HEAT_THRESHOLD)
            {
                output.Add(string.Format(HIGH_HEAT_ALERT, formatDate));
            }

            if(forcast.ForcastDetails.ToLower().Contains(RAIN_STRING))
            {
                output.Add(string.Format(RAIN_ALERT, formatDate));
            }

            if (forcast.ForcastDetails.ToLower().Contains(THUNDERSTORM_STRING))
            {
                output.Add(string.Format(THUNDERSTORM_ALERT, formatDate));
            }

            if (forcast.ForcastDetails.ToLower().Contains(SNOW_STRING))
            {
                output.Add(string.Format(SNOW_ALERT, formatDate));
            }

            if (forcast.ForcastDetails.ToLower().Contains(ICE_STRING))
            {
                output.Add(string.Format(ICE_ALERT, formatDate));
            }

            return output;
        }
    }
}
