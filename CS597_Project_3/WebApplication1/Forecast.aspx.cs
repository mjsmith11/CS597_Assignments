using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace WebApplication1
{
    public partial class Forecast : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            lblErr.Text = "";
            if (!validateZips(tbxZip.Text))
            {
                lblErr.Text = "Please enter one or more zipcodes separated by spaces";
                return;
            }
            divForecast.InnerHtml = "<h3>"+getLatLong(tbxZip.Text) + "</h3>";
        }

        private bool validateZips(string zips)
        {
            
            String[] zipList = zips.Split(' ');
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

        private string getLatLong(string zips)
        {
            //NWS.ndfdXMLPortTypeClient weather = new NWS.ndfdXMLPortTypeClient();
            //return weather.LatLonListZipCode(zips);
            // return weather.NDFDgenByDay(Convert.ToDecimal(40.4755), Convert.ToDecimal(-86.1331), DateTime.Today, "5", NWS.unitType.e, NWS.formatType.Item12hourly);
            //NWS.ndfdXML weather = new NWS.ndfdXML();
            // return weather.NDFDgenByDay(86, 45, DateTime.Today, "5", NWS.unitType.e, NWS.formatType.Item24hourly);
            noaa.ndfdXML weather = new noaa.ndfdXML();
            return weather.LatLonListZipCode(zips);
        }
    }
}