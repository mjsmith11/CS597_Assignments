﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
namespace WebApplication1
{
    public partial class Forecast : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Validates the zip codes typed in, retrieves lat/lon for the zip codes, retrieves and displays a forecast for each lat/lon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            lblErr.Text = "";
            divForecast.InnerHtml = "";
            string zipCodes = tbxZip.Text;
            string[] zipList = zipCodes.Split(' ');
            if (!validateZips(zipList))
            {
                lblErr.Text = "Please enter one or more zipcodes separated by spaces";
                return;
            }
           
           string[] locationArray = getLatLon(zipCodes);

            //at this point elements of zipList and locationArray with the same index represent the same location
            noaa.ndfdXML weather = new noaa.ndfdXML();
            for (int i=0; i<locationArray.Length; i++)
            {
                string location = locationArray[i];
                string[] latLon = location.Split(',');
                string lat = latLon[0];
                string lon = latLon[1];

                string result = weather.NDFDgenByDay(decimal.Parse(lat), decimal.Parse(lon),DateTime.Today, "5", noaa.unitType.e, noaa.formatType.Item24hourly);
                ForecastData5Day forecast = new ForecastData5Day(zipList[i], result);
                divForecast.InnerHtml += forecast.toHtml();
            }

        }

        /// <summary>
        /// checks that each zip code is exactly 5 numeric digits
        /// </summary>
        /// <param name="zipList">array of zip codes to be checked</param>
        /// <returns>true if all zips are valid and false if at least one zip is invalid</returns>
        private bool validateZips(string[] zipList)
        {
            foreach(string z in zipList)
            {
                if(z.Length != 5)
                {
                    return false;
                }
                int n;
                if(!Int32.TryParse(z,out n))
                {
                    //it is not numeric
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// uses the noaa web service to convert zip codes to lat/lon
        /// </summary>
        /// <param name="zips">zip codes separated by spaces</param>
        /// <returns>array of lat/lon pairs separated by commas</returns>
        private string[] getLatLon(string zips)
        {
            noaa.ndfdXML weather = new noaa.ndfdXML();
            string xml = weather.LatLonListZipCode(zips);
            XmlDocument weatherXml = new XmlDocument();
            weatherXml.LoadXml(xml);
            XmlNodeList latLon = weatherXml.GetElementsByTagName("latLonList");
            string latLonList = latLon.Item(0).InnerText;
            return latLonList.Split(' ');
        }
    }
}