using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCart
{
    public class PurchaseData
    {
        public string Title { get; set; }
        public int Quantity { get; set; }
        public string Price { get; set; }
        public string Total { get; set; }
        public string Note  { get; set; }

        public PurchaseData()
        { }
        

    }
}