using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCart
{
    public class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public double price { get; set; }
        public int numInStock { get; set; }

        public Book()
        { }
    }
}