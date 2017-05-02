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

            if (!IsPostBack)
            {
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

                var ddlData = from b in books select new { Display = b.BookName + " by " + b.Author + " - " + b.price.ToString("C", CultureInfo.CurrentCulture), Value = b.BookId };
                ddlBooks.DataSource = ddlData;
                ddlBooks.DataTextField = "Display";
                ddlBooks.DataValueField = "Value";
                ddlBooks.DataBind();

                updateQtyChoices();
            }
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            string target = "ChooseQuantity.aspx?bid=" + ddlBooks.SelectedValue;
            Response.Redirect(target);
        }

        protected void updateQtyChoices()
        {
            ddlQty.Items.Clear();
            int bookId = Int32.Parse(ddlBooks.SelectedValue);
            int qtyAvailable = 0;

            try
            {
                SQLServerHandler db = new SQLServerHandler("FinalCS");
                db.CreateCommand("SELECT * FROM Book WHERE BookId = @b");
                db.AddParameter("@b", bookId);
                List<Book> book = db.ExecuteBookListQuery();
                //there should be only one result since PK is used in WHERE

                qtyAvailable = book[0].numInStock;
            }
            catch
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");
                return;
            }

            

            for(int i = 1; i<=qtyAvailable; i++)
            {
                ddlQty.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }

        protected void ddlBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateQtyChoices();
        }
    }
}