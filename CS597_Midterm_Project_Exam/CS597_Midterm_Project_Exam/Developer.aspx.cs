using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CS597_Midterm_Project_Exam
{
    public partial class Developer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null || Session["UserType"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }
            else if (!Session["UserType"].Equals("Developer"))
            {
                Response.Redirect("Login.aspx");
                return;
            }
            //this is not checking IsPostBack on purpose so that the list of bugs updates if they click fix
            QueryBugs();
        }

        protected void btnFixed_Click(object sender, EventArgs e)
        {
            int bugID = -1;
            int retVal = 0;
            string changes = "";

            bugID = Int32.Parse(ddlBug.SelectedValue);
            changes = tbxSteps.Text;
            try
            {
                OleDbHandler db = new OleDbHandler("MidTermCS");
                db.CreateCommand("UPDATE Bugs SET AssignedTo=NULL,Status='Completed',Changes=@c WHERE BugID=@b");
                db.AddParameter("@c", changes);
                db.AddParameter("@b", bugID);
                db.OpenConnection();
                retVal = db.ExecuteNonQuery();
                db.CloseConnection();
            }
            catch (Exception ex)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            tbxSteps.Text = "";
            QueryBugs();
        }

        private void QueryBugs()
        {
            DataTable bugData;
            try
            {
                OleDbHandler db = new OleDbHandler("MidTermCS");
                db.CreateCommand("SELECT BugID,EnteredBy,Subject,Priority,Description FROM Bugs WHERE AssignedTo=@a");
                db.AddParameter("@a", Session["UserID"]);
                bugData = db.ExecuteDataAdapterQuery();
            }
            catch (Exception ex)
            {
                Response.Redirect("Login.aspx");
                return;
            }
            gvBugs.DataSource = bugData;
            gvBugs.DataBind();

            ddlBug.DataSource = bugData;
            ddlBug.DataTextField = "Subject";
            ddlBug.DataValueField = "BugID";
            ddlBug.DataBind();
        }
    }
}