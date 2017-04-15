using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;

namespace CS597_Project_5
{
    public partial class MovieDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["id"] == null)
            {
                Response.Redirect("Search.aspx");
            }
            else
            {
                string movieId = Request.QueryString["id"];
                string requestUrl = buildRequestUrl(movieId);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUrl);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());

                string contents = reader.ReadToEnd();

                DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(SearchResult));
                MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(contents));
                SearchResult results = (SearchResult)js.ReadObject(stream);

                //populateResults(results);
            }

        }

        private string buildRequestUrl(string IMDbID)
        {
            string stub = "http://www.omdbapi.com/";
            string parms = "?i=" + Uri.EscapeDataString(IMDbID);
            return stub + parms;
        }
    }
}