using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;

namespace ShoppingCart
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            int userId = -1;
            string passwordFromDatabase = "";

            lblError.Text = "";
            try
            {
                SQLServerHandler db = new SQLServerHandler("FinalCS");
                db.CreateCommand("SELECT * FROM [User] WHERE Login = @L");
                db.AddParameter("@L", tbxUsername.Text);
                List<User> dbUsers = db.ExecuteUserListQuery();

                //since Logins must be unique we will have either 1 or 0 results here.
                if (dbUsers.Count() == 1)
                {
                    passwordFromDatabase = dbUsers[0].password;
                    userId = dbUsers[0].userId;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "There was an error communicating with the database.";
                return;
            }

            string passwordFromUser = tbxPassword.Text;

            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
            sha1.ComputeHash(ASCIIEncoding.ASCII.GetBytes(passwordFromUser));
            byte[] result = sha1.Hash;
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }

            string hashedPasswordFromUser = strBuilder.ToString();

            if (hashedPasswordFromUser.Equals(passwordFromDatabase) && !String.IsNullOrEmpty(passwordFromDatabase)) //passwordFromDatabase will be "" if the Login is not found in the database
            {
                Session["UserID"] = userId;
                Response.Redirect("Store.aspx");
            }
            else
            {
                lblError.Text = "Invalid Username or Password";
            }
        }
    }
}