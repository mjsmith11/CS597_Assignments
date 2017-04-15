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
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["showLast"] != null && !IsPostBack)
            {
                runSearch(Session["lastSearch"].ToString());
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            runSearch(tbxTerm.Text);
        }

        private string buildRequestUrl(string term)
        {
            string stub = "http://www.omdbapi.com/";
            string parms = "?s=" + Uri.EscapeDataString(term) + "&type=movie";
            return stub + parms;
        }

        private void populateResults(SearchResult results)
        {
            foreach (Movie m in results.Search)
            {
                ListItem li = new ListItem();
                li.Text = m.Title;
                li.Value = "MovieDetails.aspx?id=" + m.ImdbID;
                blstResults.Items.Add(li);
            }
        }

        private void runSearch(string term)
        {
            blstResults.Items.Clear();

            string requestUrl = buildRequestUrl(term);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUrl);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());

            string contents = reader.ReadToEnd();

            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(SearchResult));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(contents));
            SearchResult results = (SearchResult)js.ReadObject(stream);

            populateResults(results);

            Session["lastSearch"] = term;
        }

    }
}