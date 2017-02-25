using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Security.Cryptography;
using System.Text;

namespace CS597_Midterm_Project_Exam
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
            string userType = "";

            lblError.Text = "";
            try
            {
                OleDbHandler db = new OleDbHandler("MidTermCS");
                db.CreateCommand("SELECT Password,UserID,Type FROM Users WHERE Login = @L");
                db.AddParameter("@L", tbxUsername.Text);
                db.OpenConnection();
                OleDbDataReader rdr = db.GetDataReader();
                while (rdr.Read())
                {
                    passwordFromDatabase = rdr["Password"].ToString();
                    userId = Int32.Parse(rdr["userID"].ToString());
                    userType = rdr["Type"].ToString();
                }

                rdr.Close();
                db.CloseConnection();
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

            if (hashedPasswordFromUser.Equals(passwordFromDatabase))
            {
                Session["UserID"] = userId;
                Session["UserType"] = userType;
                if(userType.Equals("Tester"))
                {
                    Response.Redirect("Tester.aspx");
                }
                else if(userType.Equals("Manager"))
                {
                    Response.Redirect("Manager.aspx");
                }
                else if(userType.Equals("Developer"))
                {
                    Response.Redirect("Developer.aspx");
                }
                else if(userType.Equals("Administrator"))
                {
                    Response.Redirect("Administrator.aspx");
                }
            }
            else
            {
                lblError.Text = "Invalid Username or Password";
            }
        }

    }
}