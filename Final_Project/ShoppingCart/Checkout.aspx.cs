using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoppingCart
{
    public partial class Checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");
                return;
            }
            List<PurchaseData> displayData = new List<PurchaseData>();
            double displayTotal = 0;
            List<CartItem> cartContents = GetCartContents();
            foreach(CartItem item in cartContents)
            {
                PurchaseData pd = new PurchaseData();
                Book book = getBook(item.Book_Id);
                pd.Title = book.BookName;
                if (item.Quantity <= book.numInStock)
                {
                    pd.Quantity = item.Quantity;
                    pd.Note = "";
                }
                else
                {
                    pd.Quantity = book.numInStock;
                    pd.Note = "Quantity adjusted due to stock";
                }
                pd.Price = book.price.ToString("C");
                double total = book.price * pd.Quantity;
                pd.Total = total.ToString("C");
                displayData.Add(pd);
                displayTotal += total;
                updateInventory(book.BookId, book.numInStock - pd.Quantity);
            }
            gvSummary.DataSource = displayData;
            gvSummary.DataBind();
            lblTotal.Text = "Total: " + displayTotal.ToString("C");

            ClearCart();

        }

        private List<CartItem> GetCartContents()
        {
            try
            {
                SQLServerHandler db = new SQLServerHandler("FinalCS");
                db.CreateCommand("SELECT * FROM CartItem WHERE User_Id = @u");
                db.AddParameter("@u", Session["UserID"]);
                return db.ExecuteCartItemListQuery();
            }
            catch(Exception ex)
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");
                return null;
            }
        }

        private Book getBook(int id)
        {
            try
            {
                SQLServerHandler db = new SQLServerHandler("FinalCS");
                db.CreateCommand("SELECT * FROM Book WHERE BookId = @b");
                db.AddParameter("@b", id);
                return db.ExecuteBookListQuery()[0];
            }
            catch(Exception ex)
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");
                return null;
            }
       }

        private void updateInventory(int bookId, int newInventory)
        {
            try
            {
                SQLServerHandler db = new SQLServerHandler("FinalCS");
                db.CreateCommand("UPDATE Book SET NumInStock = @n WHERE BookId = @b");
                db.AddParameter("@n", newInventory);
                db.AddParameter("@b", bookId);
                db.OpenConnection();
                db.ExecuteNonQuery();
                db.CloseConnection();
            }
            catch(Exception ex)
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }
        }

        private void ClearCart()
        {
            try
            {
                SQLServerHandler db = new SQLServerHandler("FinalCS");
                db.CreateCommand("DELETE FROM CartItem WHERE User_Id = @u");
                db.AddParameter("@u", Session["UserID"]);
                db.OpenConnection();
                db.ExecuteNonQuery();
                db.CloseConnection();
            }
            catch(Exception ex)
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }
        }
    }
}