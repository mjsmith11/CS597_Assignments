using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Runtime.Serialization;
using System.IO;

namespace CS597_Project_5
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            divResults.InnerHtml = "";

            string requestUrl = buildRequestUrl();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUrl);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
        }

        private string buildRequestUrl()
        {
            string stub = "http://www.omdbapi.com/";
            string parms = "?s=" + Uri.EscapeDataString(tbxTerm.Text) + "&type=movie";
            return stub + parms;
        }
    }
}