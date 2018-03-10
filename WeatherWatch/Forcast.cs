using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherWatch
{
    public class Forcast
    {
        public DateTime ForcastDate { get; set; }
        public int LowTemp { get; set; }
        public int HighTemp { get; set; }
        public string ForcastDetails { get; set; }

        public Forcast(DateTime ForcastDate, int LowTemp, int HighTemp, string ForcastDetails)
        {
            this.ForcastDate = ForcastDate;
            this.LowTemp = LowTemp;
            this.HighTemp = HighTemp;
            this.ForcastDetails = ForcastDetails;
        }
    }
}
