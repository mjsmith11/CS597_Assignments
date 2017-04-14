using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace CS597_Project_5
{
    [DataContract]
    public class Movie
    {

        [DataMember(Name = "Title")]
        public string Title { get; set; }

        [DataMember(Name = "Year")]
        public string Year { get; set; }

        [DataMember(Name = "imdbID")]
        public string ImdbID { get; set; }

        [DataMember(Name = "Type")]
        public string Type { get; set; }

        [DataMember(Name = "Poster")]
        public string Poster { get; set; }
    }

    [DataContract]
    public class SearchResult
    {

        [DataMember(Name = "Search")]
        public IList<Movie> Search { get; set; }

        [DataMember(Name = "totalResults")]
        public string TotalResults { get; set; }

        [DataMember(Name = "Response")]
        public string Response { get; set; }
    }
}