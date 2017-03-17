using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace WebApplication1
{
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
    }

    public class ForecastDay
    {
        private int highTemp { get; set; }
        private int lowTemp { get; set; }
        private string graphicUrl { get; set; }
        private string description { get; set; }

        public ForecastDay(int highTemp, int lowTemp, string description, string graphicUrl)
        {
            this.highTemp = highTemp;
            this.lowTemp = lowTemp;
            this.graphicUrl = graphicUrl;
            this.description = description;
        }

    }
}