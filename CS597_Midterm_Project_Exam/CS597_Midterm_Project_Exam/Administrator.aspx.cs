using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace CS597_Midterm_Project_Exam
{
    public partial class Administrator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null || Session["UserType"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }
            else if (!Session["UserType"].Equals("Administrator"))
            {
                Response.Redirect("Login.aspx");
                return;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int userID = -1;
            string name = "";
            string login = "";
            string hashedPassword = "";
            string type = "";
            int retVal = -1;

            lblFeedback.Text = "";

            try
            {
                OleDbHandler db = new OleDbHandler("MidTermCS");
                db.CreateCommand("SELECT MAX(UserID) as U FROM Users");
                DataTable temp = db.ExecuteDataAdapterQuery();
                try
                {
                    userID = Int32.Parse(temp.Rows[0]["U"].ToString());
                    userID++;
                }
                catch (FormatException ex)
                {
                    //this most likely means that the Users Table is empty and the query returned ""
                    //This is here mostly for safety because the table should never be empty
                    //The administrator creating a user should be in it
                    userID = 1;
                }

                string loginFromUser = tbxLogin.Text;
                db.CreateCommand("SELECT COUNT(*) AS C FROM Users WHERE Login=@l");
                db.AddParameter("@l", loginFromUser);
                temp = db.ExecuteDataAdapterQuery();

                if(Int32.Parse(temp.Rows[0]["C"].ToString())>0)
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
                Response.Redirect("Login.aspx");
                return;
            }

            name = tbxName.Text;
            type = ddlType.SelectedValue;

            string passwordFromUser = tbxPassword.Text;
            if(passwordFromUser.Length<8)
            {
                lblFeedback.Text = "Password must be at least 8 characters.";
                return;
            }
            if (!passwordFromUser.Any(char.IsLetter))
            {
                lblFeedback.Text = "Password must contain at least 1 letter";
                return;
            }
            if(!passwordFromUser.Any(char.IsDigit))
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

            //try
            //{
                OleDbHandler db1 = new OleDbHandler("MidTermCS");
                db1.CreateCommand("INSERT INTO Users (UserID, Name, Login, [Password], Type) VALUES (@u, @n, @l, @p, @t)");
                db1.AddParameter("@u", userID);
                db1.AddParameter("@n", name);
                db1.AddParameter("@l", login);
                db1.AddParameter("@p", hashedPassword);
                db1.AddParameter("@t", type);
                db1.OpenConnection();
                retVal = db1.ExecuteNonQuery();
                db1.CloseConnection();
            /*}
            catch(Exception ex)
            {
                Response.Redirect("Login.aspx");
                return;
            }*/
            tbxName.Text = "";
            tbxLogin.Text = "";
            tbxPassword.Text = "";
            ddlType.SelectedIndex = 0;

            if (retVal == 1)
            {
                lblFeedback.Text = "User " + name + " Added.";
            }
        }
    }
}