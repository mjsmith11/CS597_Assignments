using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCart
{
    public class CartItem
    {
        public int Id { get; set; }
        public int Book_Id { get; set; }
        public int User_Id { get;set;}
        public int Quantity { get; set; }

        public CartItem()
        {

        }
    }
}