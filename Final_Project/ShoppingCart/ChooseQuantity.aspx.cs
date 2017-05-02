using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoppingCart
{
    public partial class ChooseQuantity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");
                return;
            }
            if(Request.QueryString["bid"]==null)
            {
                Response.Redirect("Store.aspx");
            }

            divSuccess.Visible = false;
        }
    }
}