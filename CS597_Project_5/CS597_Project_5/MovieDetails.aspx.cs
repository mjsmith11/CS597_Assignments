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
            if (Request.QueryString["id"] == null)
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

                DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(MovieInfo));
                MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(contents));
                MovieInfo info = (MovieInfo)js.ReadObject(stream);

                displayData(info);
            }

        }

        private string buildRequestUrl(string IMDbID)
        {
            string stub = "http://www.omdbapi.com/";
            string parms = "?i=" + Uri.EscapeDataString(IMDbID);
            return stub + parms;
            //http://localhost:11227/MovieDetails?id=tt0372784
            //{"Title":"Batman Begins","Year":"2005","Rated":"PG-13","Released":"15 Jun 2005","Runtime":"140 min","Genre":"Action, Adventure","Director":"Christopher Nolan","Writer":"Bob Kane (characters), David S. Goyer (story), Christopher Nolan (screenplay), David S. Goyer (screenplay)","Actors":"Christian Bale, Michael Caine, Liam Neeson, Katie Holmes","Plot":"After training with his mentor, Batman begins his fight to free crime-ridden Gotham City from the corruption that Scarecrow and the League of Shadows have cast upon it.","Language":"English, Urdu, Mandarin","Country":"USA, UK","Awards":"Nominated for 1 Oscar. Another 14 wins & 68 nominations.","Poster":"https://images-na.ssl-images-amazon.com/images/M/MV5BNTM3OTc0MzM2OV5BMl5BanBnXkFtZTYwNzUwMTI3._V1_SX300.jpg","Ratings":[{"Source":"Internet Movie Database","Value":"8.3/10"},{"Source":"Rotten Tomatoes","Value":"84%"},{"Source":"Metacritic","Value":"70/100"}],"Metascore":"70","imdbRating":"8.3","imdbVotes":"1,040,919","imdbID":"tt0372784","Type":"movie","DVD":"18 Oct 2005","BoxOffice":"$204,100,000.00","Production":"Warner Bros. Pictures","Website":"http://www.batmanbegins.com/","Response":"True"}
        }

        private void displayData(MovieInfo info)
        {
            string rottenTomatoes = "";
            string metacritic = "";

            foreach (Rating r in info.Ratings)
            {
                if (r.Source.Equals("Rotten Tomatoes"))
                    rottenTomatoes = r.Value;
                else if (r.Source.Equals("Metacritic"))
                    metacritic = r.Value;
            }

            string html = "";
            html += "<h1>" + info.Title + "</h1>";
            html += "<table>";

            html += "<tr>";
            html += "<td>Release Date</td>";
            html += "<td>" + info.Released + "</td>";
            html += "</tr>";

            html += "<tr>";
            html += "<td>Runtime</td>";
            html += "<td>" + info.Runtime + "</td>";
            html += "</tr>";

            html += "<tr>";
            html += "<td>Genre</td>";
            html += "<td>" + info.Genre + "</td>";
            html += "</tr>";

            html += "<tr>";
            html += "<td>Rating</td>";
            html += "<td>" + info.Rated + "</td>";
            html += "</tr>";

            html += "<tr>";
            html += "<td>Plot</td>";
            html += "<td>" + info.Plot + "</td>";
            html += "</tr>";

            html += "<tr>";
            html += "<td>Poster</td>";
            html += "<td><img style='width: 150px' src='" + info.Poster + "'/></td>";
            html += "</tr>";

            html += "<tr>";
            html += "<td>Metacritic Rating</td>";
            html += "<td>" + metacritic + "</td>";
            html += "</tr>";

            html += "<tr>";
            html += "<td>Rotten Tomatoes Rating</td>";
            html += "<td>" + rottenTomatoes + "</td>";
            html += "</tr>";

            html += "</table>";

            divMovieInfo.InnerHtml = html;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Search.aspx?showLast=1");
        }
    }
}