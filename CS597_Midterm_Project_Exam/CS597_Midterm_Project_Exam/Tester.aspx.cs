using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CS597_Midterm_Project_Exam
{
    public partial class Tester : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["UserID"]==null || Session["UserType"]==null)
            {
                Response.Redirect("Login.aspx");
            }
            else if(!Session["UserType"].Equals("Tester"))
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int bugID = -1;
            int enteredBy = -1;
            string subject = "";
            string priority = "";
            string description = "";

            try
            {
                OleDbHandler db = new OleDbHandler("MidTermCS");
                db.CreateCommand("SELECT MAX(BugID) as B FROM Bugs");
                DataTable temp = db.ExecuteDataAdapterQuery();
                try
                {
                    bugID = Int32.Parse(temp.Rows[0]["B"].ToString());
                    bugID++;
                }
                catch(FormatException ex)
                {
                    //this most likely means that the Bugs Table is empty and the query returned ""
                    bugID = 1;
                }
            }
            catch(Exception ex)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            enteredBy = Int32.Parse(Session["UserID"].ToString());
            subject = tbxSubject.Text;
            priority = ddlPriority.SelectedValue;
            description = tbxDescription.Text;

            try
            {
                OleDbHandler db = new OleDbHandler("MidTermCS");
                db.CreateCommand("INSERT INTO Bugs (BugID, EnteredBy, Subject, Priority, Description, Status) VALUES (@b, @e, @subject, @p, @d, @status)");
                db.AddParameter("@b", bugID);
                db.AddParameter("@e", enteredBy);
                db.AddParameter("@subject", subject);
                db.AddParameter("@p", priority);
                db.AddParameter("@d", description);
                db.AddParameter("@status", "Open");

                db.OpenConnection();
                db.ExecuteNonQuery();
                db.CloseConnection();
            }
            catch(Exception ex)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            //reset form
            tbxSubject.Text = "";
            ddlPriority.SelectedIndex = 0;
            tbxDescription.Text = "";

        }
    }
}