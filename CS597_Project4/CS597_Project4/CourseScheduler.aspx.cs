using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CS597_Project4
{
    public partial class CourseScheduler : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                DataTable availableCourses;
                DataTable selectedCourses;

                SQLServerHandler sql = new SQLServerHandler("CoursesCS");
                sql.CreateCommand("SELECT DISTINCT CourseNumber FROM Schedule");
                availableCourses = sql.ExecuteDataAdapterQuery();
                ddlCourses.DataSource = availableCourses;
                ddlCourses.DataTextField = "CourseNumber";
                ddlCourses.DataValueField = "CourseNumber";
                ddlCourses.DataBind();

                btnSchedule.Enabled = false;

                selectedCourses = new DataTable("selectedCourses");
                DataColumn colId = new DataColumn("CourseNumber", typeof(String));
                selectedCourses.Columns.Add(colId);

                Session["availableCourses"] = availableCourses;
                Session["selectedCourses"] = selectedCourses;
            }
            
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            DataTable availableCourses = (DataTable)Session["availableCourses"];
            DataTable selectedCourses = (DataTable)Session["selectedCourses"];

            string courseToAdd = ddlCourses.SelectedValue;

            //add the selected course to selected courses and remove it from available courses
            for(int i = availableCourses.Rows.Count - 1; i>=0; i--)
            {
                DataRow dr = availableCourses.Rows[i];
                if(dr["CourseNumber"].Equals(courseToAdd))
                {
                    selectedCourses.ImportRow(dr);
                    availableCourses.Rows.Remove(dr);
                }
            }

            if(selectedCourses.Rows.Count==4)
            {
                btnAdd.Enabled = false;
                btnSchedule.Enabled = true;
            }

            ddlCourses.DataSource = availableCourses;
            ddlCourses.DataBind();
            displaySelectedCourses();

            Session["availableCourses"] = availableCourses;
            Session["selectedCourses"] = selectedCourses;
        }

        protected void displaySelectedCourses()
        {
            DataTable selectedCourses = (DataTable)Session["selectedCourses"];
            string html = "";
            if(selectedCourses.Rows.Count>0)
            {
                html += "<h3>Selected Courses</h3>";
                html += "<ul>";
                
                foreach(DataRow dr in selectedCourses.Rows)
                {
                    html += "<li>";
                    html += dr["CourseNumber"];
                    html += "</li>";
                }

                html += "</ul>";

                divSelectedCourses.InnerHtml = html;
            }
        }
    }
}