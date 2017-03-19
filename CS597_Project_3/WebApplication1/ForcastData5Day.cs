using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace WebApplication1
{
    /// <summary>
    /// This class contains data for high temperatures, low temperatures, descriptions, and graphics from the graphical.weather.gov/xml/ api.
    /// It is coded for a 5 day forecast, but is designed to be adaptable to any length of forecast with minimal changes. It has a dependency
    /// of the ForcastDay class also in this file and https://unpkg.com/purecss@0.6.2/build/pure-min.css
    /// </summary>
    public class ForecastData5Day
    {
        const int NUM_DAYS = 5;

        private string zip { get; set; }
        private ForecastDay[] forecast { get; set; }

        //I have seen examples of xml with 4 and 5 values for some elements
        //I am assuming that when there are 4 values, the value for the first day
        //is excluded because the request was made late in the day
        private bool firstDayHigh { get; set; }
        private bool firstDayLow { get; set; }
        private bool firstDayDesc { get; set; }
        private bool firstDayGraphic { get; set; }


        /// <summary>
        /// 2 argument constructor
        /// </summary>
        /// <param name="zip">zip code for the forecast</param>
        /// <param name="xml">xml result of the NDFDgenByDay call</param>
        public ForecastData5Day(string zip, string xml)
        {
            this.zip = zip;

            firstDayHigh = true;
            firstDayLow = true;
            firstDayDesc = true;
            firstDayGraphic = true;

            forecast = new ForecastDay[NUM_DAYS];
            parseXmlToArray(xml);   
        }

        /// <summary>
        /// parses the provided xml and stores the data in the data members of this object
        /// </summary>
        /// <param name="xml">xml response from NDFDgenByDay</param>
        public void parseXmlToArray(string xml)
        {
            List<int> highs = new List<int>();
            List<int> lows = new List<int>();
            List<string> descriptions = new List<string>();
            List<string> graphics = new List<string>();

            XmlDocument forecast = new XmlDocument();
            forecast.LoadXml(xml);
            XmlNodeList temperature = forecast.GetElementsByTagName("temperature");
            foreach(XmlNode t in temperature)
            {
                if(t.Attributes["type"].Value.Equals("maximum"))
                {
                    foreach(XmlNode i in t.ChildNodes)
                    {
                        if(i.Name.Equals("value"))
                        {
                            //short circuit evaluation will not allow the second condition to be evaluated if
                            //the first is false
                            if((i.Attributes["xsi:nil"] != null) && (i.Attributes["xsi:nil"].Value.Equals("true")))
                            {
                                firstDayHigh = false;
                            }
                            else
                            {
                                highs.Add(Int32.Parse(i.InnerText));
                            }
                        }
                    }
                }
                else if(t.Attributes["type"].Value.Equals("minimum"))
                {
                    foreach (XmlNode i in t.ChildNodes)
                    {
                        if (i.Name.Equals("value"))
                        {
                            //short circuit evaluation will not allow the second condition to be evaluated if
                            //the first is false
                            if ((i.Attributes["xsi:nil"] != null) && (i.Attributes["xsi:nil"].Value.Equals("true")))
                            {
                                firstDayLow = false;
                            }
                            else
                            {
                                lows.Add(Int32.Parse(i.InnerText));
                            }
                        }
                    }
                }
            }

            XmlNodeList conditions = forecast.GetElementsByTagName("weather");
            //Expecting just one item in the list
            XmlNode conditionNode = conditions.Item(0);

            foreach(XmlNode i in conditionNode.ChildNodes)
            {
                if (i.Name.Equals("weather-conditions"))
                {
                    //short circuit evaluation will not allow the second condition to be evaluated if
                    //the first is false
                    if ((i.Attributes["xsi:nil"] != null) && (i.Attributes["xsi:nil"].Value.Equals("true")))
                    {
                        firstDayDesc = false;
                    }
                    else
                    {
                        //this assumes that if it is not nil, the weather summary attribute will exist
                        descriptions.Add(i.Attributes["weather-summary"].Value);
                    }
                }
            }


            XmlNodeList icons = forecast.GetElementsByTagName("conditions-icon");
            //Expecting just one item in the list
            XmlNode iconNode = icons.Item(0);

            foreach (XmlNode i in iconNode.ChildNodes)
            {
                if (i.Name.Equals("icon-link"))
                {
                    //short circuit evaluation will not allow the second condition to be evaluated if
                    //the first is false
                    if ((i.Attributes["xsi:nil"] != null) && (i.Attributes["xsi:nil"].Value.Equals("true")))
                    {
                        firstDayGraphic = false;
                    }
                    else
                    {
                        //this assumes that if it is not nil, the InnerText will exist
                        graphics.Add(i.InnerText);
                    }
                }
            }
            createForecastDayArray(highs, lows, descriptions, graphics);

        }

        /// <summary>
        /// combines data into the forecast member of this class
        /// </summary>
        /// <param name="highs">List of high temperatures in chronological order</param>
        /// <param name="lows">List of low temperatures in chronological order</param>
        /// <param name="descriptions">List of weather descriptions in chronological order</param>
        /// <param name="iconUrls">List of urls to weather graphics in chronological order</param>
        public void createForecastDayArray(List<int> highs, List<int> lows, List<string> descriptions, List<string> iconUrls)
        {
            //do first element separate
            int high = 0;
            int low = 0;
            string desc = "";
            string iconurl = "";

            if(firstDayHigh)
            {
                high = highs[0];
            }
            if(firstDayLow)
            {
                low = lows[0];
            }
            if(firstDayDesc)
            {
                desc = descriptions[0];
            }
            if(firstDayGraphic)
            {
                iconurl = iconUrls[0];
            }
            forecast[0] = new ForecastDay(high, low, desc, iconurl);

            for(int i=1; i<NUM_DAYS; i++)
            {
                if (firstDayHigh)
                    high = highs[i];
                else
                    high = highs[i - 1];

                if (firstDayLow)
                    low = lows[i];
                else
                    low = lows[i - 1];

                if (firstDayDesc)
                    desc = descriptions[i];
                else
                    desc = descriptions[i - 1];

                if (firstDayGraphic)
                    iconurl = iconUrls[i];
                else
                    iconurl = iconUrls[i - 1];

                forecast[i] = new ForecastDay(high, low, desc, iconurl);
            }


        }

        /// <summary>
        /// prepares the objects data for display in a browser formatted with https://unpkg.com/purecss@0.6.2/build/pure-min.css
        /// </summary>
        /// <returns>html representation of the weather forecast</returns>
        public string toHtml()
        {
            string html = "";
            int start;
            DateTime today = DateTime.Today;

            html += ("<h3>" + this.zip + "</h3>");
            html += "<table class=\"pure-table\" width=\"60%\">";

            //headings
            html += "<thead>";
            html += "<tr>";
            for (int i = 0; i < NUM_DAYS; i++)
            {
                html += ("<th width=\"20%\">" + today.DayOfWeek + "</th>");
                today = today.AddDays(1);
            }
            html += "</tr>";
            html += "</thead>";



            html += "<tbody>";
            //max temperatures
            start = 0;
            html += "<tr>";
            if (!firstDayHigh)
            {
                html += "<td width=\"20%\">-</td>";
                start = 1;
            }

            for(int i=start; i<forecast.Length; i++)
            {
                html += ("<td width=\"20%\">" + forecast[i].highTemp + "°</td>");
            }
            html += "</tr>";

            //graphics
            start = 0;
            html += "<tr>";
            if (!firstDayGraphic)
            {
                html += "<td width=\"20%\"></td>";
                start = 1;
            }

            for (int i = start; i < forecast.Length; i++)
            {
                html += ("<td width=\"20%\"><img src=\""+forecast[i].graphicUrl+"\"></td>");
            }
            html += "</tr>";

            //low temps
            start = 0;
            html += "<tr>";
            if (!firstDayLow)
            {
                html += "<td width=\"20%\">-</td>";
                start = 1;
            }

            for (int i = start; i < forecast.Length; i++)
            {
                html += ("<td width=\"20%\">" + forecast[i].lowTemp + "°</td>");
            }
            html += "</tr>";

            //descriptions
            start = 0;
            html += "<tr>";
            if (!firstDayDesc)
            {
                html += "<td width=\"20%\">-</td>";
                start = 1;
            }

            for (int i = start; i < forecast.Length; i++)
            {
                html += ("<td width=\"20%\">" + forecast[i].description + "</td>");
            }
            html += "</tr>";

            html += "</tbody>";
            html += "</table>";
            html += "<br/>";
            return html;
        }
    }

    public class ForecastDay
    {
        public int highTemp { get; set; }
        public int lowTemp { get; set; }
        public string graphicUrl { get; set; }
        public string description { get; set; }

        public ForecastDay(int highTemp, int lowTemp, string description, string graphicUrl)
        {
            this.highTemp = highTemp;
            this.lowTemp = lowTemp;
            this.graphicUrl = graphicUrl;
            this.description = description;
        }

    }
}