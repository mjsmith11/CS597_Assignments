using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;

namespace ShoppingCart
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            if (Session["UserID"] == null)
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");
                return;
            }

            DataTable dt;
            try
            {
                SQLServerHandler db = new SQLServerHandler("FinalCS");
                db.CreateCommand("SELECT b.BookName, b.Price, c.Quantity FROM Book AS b JOIN CartItem AS c ON b.BookId=c.Book_Id WHERE c.User_Id=@u; ");
                db.AddParameter("@u", Session["UserID"]);
                dt = db.ExecuteDataAdapterQuery();
            }
            catch
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");
                return;
            }

            if (dt.Rows.Count == 0)
            {
                lblMsg.Text = "Your Cart is Empty";
                lnkCheckout.Visible = false;
            }
            else
            {
                var data = from r in dt.AsEnumerable() select new { Title = r["BookName"].ToString(), Qty = r["Quantity"].ToString(), Price = Double.Parse(r["Price"].ToString()).ToString("C", CultureInfo.CurrentCulture), Total = (Int32.Parse(r["Quantity"].ToString()) * Double.Parse(r["Price"].ToString())).ToString("C",CultureInfo.CurrentCulture) };
                gvCartContents.DataSource = data;
                gvCartContents.DataBind();
                lnkCheckout.Visible = true;
            }
            
        }
    }
}