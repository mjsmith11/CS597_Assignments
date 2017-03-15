using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class ForecastData
    {
        private string zip { get; set; }
        private ForecastDay[] forecast { get; }

        ForecastData(string zip, string xml)
        {
            this.zip = zip;
            parseXml(xml);   
        }
        public void parseXml(string xml)
        {
            throw new NotImplementedException();
        }
    }

    public class ForecastDay
    {
        private int highTemp { get; set; }
        private int lowTemp { get; set; }
        private string graphicUrl { get; set; }
        private string description { get; set; }

        ForecastDay(int highTemp, int lowTemp, string graphicUrl, string description)
        {
            this.highTemp = highTemp;
            this.lowTemp = lowTemp;
            this.graphicUrl = graphicUrl;
            this.description = description;
        }

    }
}