using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace ShoppingCart
{
    public partial class CreateAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lnkLogin.Visible = false;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string name = "";
            string login = "";
            string hashedPassword = "";
            int retVal = -1;

            lblFeedback.Text = "";

            try
            {
                SQLServerHandler db = new SQLServerHandler("FinalCS");
                string loginFromUser = tbxLogin.Text;
                db.CreateCommand("SELECT COUNT(*) AS C FROM [User] WHERE Login=@l");
                db.AddParameter("@l", loginFromUser);
                DataTable temp = db.ExecuteDataAdapterQuery();

                if (Int32.Parse(temp.Rows[0]["C"].ToString()) > 0)
                {
                    lblFeedback.Text = "Login already taken";
                    return;
                }
                else
                {
                    login = loginFromUser;
                }
            }
            catch (Exception ex)
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");
                return;
            }

            name = tbxName.Text;

            string passwordFromUser = tbxPassword.Text;
            if (passwordFromUser.Length < 8)
            {
                lblFeedback.Text = "Password must be at least 8 characters.";
                return;
            }
            if (!passwordFromUser.Any(char.IsLetter))
            {
                lblFeedback.Text = "Password must contain at least 1 letter";
                return;
            }
            if (!passwordFromUser.Any(char.IsDigit))
            {
                lblFeedback.Text = "Password must contain at least 1 number";
                return;
            }

            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
            sha1.ComputeHash(ASCIIEncoding.ASCII.GetBytes(passwordFromUser));
            byte[] result = sha1.Hash;
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2")); //x2 is for 2 hex because we are sending in a byte at a time
            }
            hashedPassword = strBuilder.ToString();

            try
            {
                SQLServerHandler db1 = new SQLServerHandler("FinalCS");
                db1.CreateCommand("INSERT INTO [User] (Name, Login, [Password]) VALUES (@n, @l, @p)");
                db1.AddParameter("@n", name);
                db1.AddParameter("@l", login);
                db1.AddParameter("@p", hashedPassword);
                db1.OpenConnection();
                retVal = db1.ExecuteNonQuery();
                db1.CloseConnection();
        }
            catch (Exception ex)
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");
                return;
            }
    tbxName.Text = "";
            tbxLogin.Text = "";
            tbxPassword.Text = "";

            if (retVal == 1)
            {
                lblFeedback.Text = "Account has been created!";
                lnkLogin.Visible = true;
            }
        }
    }
}