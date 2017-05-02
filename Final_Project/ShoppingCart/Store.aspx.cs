using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoppingCart
{
    public partial class Store : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["UserID"] == null)
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");
                return;
            }

            List<Book> books;

            //this doesn't check IsPostBack because we want to update on any postback in case someone else caused a change in number of copies available
            try
            {
                SQLServerHandler db = new SQLServerHandler("FinalCS");

                //query for the books with more than zero copies available and are not in the user's cart
                db.CreateCommand("SELECT * FROM Book WHERE NumInStock>0 AND BookId NOT IN (SELECT Book_Id FROM CartItem WHERE User_Id = @u)");
                db.AddParameter("@u", Session["UserID"]);
                books = db.ExecuteBookListQuery();
            }
            catch
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");
                return;
            }

            var ddlData = from b in books select new { Display = b.BookName + " by " + b.Author + " - " + b.price.ToString("C",CultureInfo.CurrentCulture), Value = b.BookId };
            ddlBooks.DataSource = ddlData;
            ddlBooks.DataTextField = "Display";
            ddlBooks.DataValueField = "Value";
            ddlBooks.DataBind();
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            string target = "ChooseQuantity.aspx?bid=" + ddlBooks.SelectedValue;
            Response.Redirect(target);
        }
    }
}