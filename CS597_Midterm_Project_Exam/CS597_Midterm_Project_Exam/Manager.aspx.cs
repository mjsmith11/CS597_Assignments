using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;

namespace CS597_Midterm_Project_Exam
{
    public partial class Manager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null || Session["UserType"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }
            else if (!Session["UserType"].Equals("Manager"))
            {
                Response.Redirect("Login.aspx");
                return;
            }

            if(!IsPostBack)
            {
                try
                {
                    OleDbHandler db = new OleDbHandler("MidTermCS");
                    db.CreateCommand("SELECT Subject,BugID FROM Bugs WHERE Status='Open'");
                    db.OpenConnection();
                    OleDbDataReader rdr = db.GetDataReader();
                    while(rdr.Read())
                    {
                        ddlBug.Items.Add(new ListItem(rdr["Subject"].ToString(), rdr["BugID"].ToString()));
                    }

                    rdr.Close();
                    db.CloseConnection();

                    db.CreateCommand("SELECT UserID, Name FROM Users WHERE Type='Developer'");
                    db.OpenConnection();
                    rdr = db.GetDataReader();
                    while(rdr.Read())
                    {
                        ddlDeveloper.Items.Add(new ListItem(rdr["Name"].ToString(), rdr["UserID"].ToString()));
                    }
                    rdr.Close();
                    db.CloseConnection();
                }
                catch(Exception ex)
                {
                    Response.Redirect("Login.aspx");
                    return;
                }
                ddlBug_SelectedIndexChanged(null, null);
            }
        }

        protected void btnAssign_Click(object sender, EventArgs e)
        {
            int developerID = -1;
            int bugID = -1;
            int retVal = 0;

            lblFeedback.Text = "";
            developerID = Int32.Parse(ddlDeveloper.SelectedValue);
            bugID = Int32.Parse(ddlBug.SelectedValue);

            try
            {
                OleDbHandler db = new OleDbHandler("MidTermCS");
                db.CreateCommand("UPDATE Bugs SET AssignedTo=@d,Status=@s WHERE BugID=@b");
                db.AddParameter("@d", developerID);
                db.AddParameter("@s", "Assigned");
                db.AddParameter("@b", bugID);
                db.OpenConnection();
                retVal = db.ExecuteNonQuery();
                db.CloseConnection();
            }
            catch(Exception ex)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            lblFeedback.Text = ddlBug.SelectedItem.Text + " assigned to " + ddlDeveloper.SelectedItem.Text;


        }

        protected void ddlBug_SelectedIndexChanged(object sender, EventArgs e)
        {
            int bugID = -1;
            bugID = Int32.Parse(ddlBug.SelectedValue);

            try
            {
                OleDbHandler db = new OleDbHandler("MidTermCS");
                db.CreateCommand("SELECT BugID, EnteredBy, Subject, Priority, Description FROM Bugs WHERE BugID=@b");
                db.AddParameter("@b", bugID);
                DataTable dt = db.ExecuteDataAdapterQuery();
                dvBugDisplay.DataSource = dt;
                dvBugDisplay.DataBind();
            }
            catch(Exception ex)
            {
                Response.Redirect("Login.aspx");
                return;
            }
        }
    }
}