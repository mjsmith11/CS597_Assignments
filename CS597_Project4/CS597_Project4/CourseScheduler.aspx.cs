using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;

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
                divSelectedCourses.Visible = false;
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

            //the add button being available implies less than 4 were selected, therefore, the
            //only change we may need to make is if the addition results in 4 being selected
            if(selectedCourses.Rows.Count==4)
            {
                btnAdd.Enabled = false;
                btnSchedule.Enabled = true;
            }

            ddlCourses.DataSource = availableCourses;
            ddlCourses.DataBind();

            Session["availableCourses"] = availableCourses;
            Session["selectedCourses"] = selectedCourses;

            displaySelectedCourses();
        }

        protected void displaySelectedCourses()
        {
            DataTable selectedCourses = (DataTable)Session["selectedCourses"];
            Label[] displayLabels = new Label[] { lblSelected1, lblSelected2, lblSelected3, lblSelected4 };
            HtmlGenericControl[] listItems = new HtmlGenericControl[] { liSelected1, liSelected2, liSelected3, liSelected4 };

            //make all the items invisible and later make the ones we need visible
            foreach (HtmlGenericControl h in listItems)
                h.Visible = false;

            //the div should be visible only if we have at least 1 selected course
            divSelectedCourses.Visible = (selectedCourses.Rows.Count > 0);

            for(int i=0; i<selectedCourses.Rows.Count; i++)
            {
                //there is no risk of index out of bounds because we only allow 4 courses to be selected
                displayLabels[i].Text = selectedCourses.Rows[i]["CourseNumber"].ToString();
                listItems[i].Visible = true;
            }
        }

        protected void btnDelete1_Click(object sender, EventArgs e)
        {
            deleteFromSelected(0);
        }

        protected void btnDelete2_Click(object sender, EventArgs e)
        {
            deleteFromSelected(1);
        }

        protected void btnDelete3_Click(object sender, EventArgs e)
        {
            deleteFromSelected(2);
        }

        protected void btnDelete4_Click(object sender, EventArgs e)
        {
            deleteFromSelected(3);
        }

        protected void deleteFromSelected(int index)
        {
            DataTable availableCourses = (DataTable)Session["availableCourses"];
            DataTable selectedCourses = (DataTable)Session["selectedCourses"];

            availableCourses.ImportRow(selectedCourses.Rows[index]);
            selectedCourses.Rows.RemoveAt(index);

            //deleting means a course will be removed, so we only need to change
            //the availability of the buttons if 4 were selected and the delete results in less
            //than 4 selected
            if(selectedCourses.Rows.Count != 4)
            {
                btnAdd.Enabled = true;
                btnSchedule.Enabled = false;
            }

            ddlCourses.DataSource = availableCourses;
            ddlCourses.DataBind();
            
            Session["availableCourses"] = availableCourses;
            Session["selectedCourses"] = selectedCourses;

            displaySelectedCourses();
        }

        protected void btnSchedule_Click(object sender, EventArgs e)
        {
            DataTable selectedCourses = (DataTable)Session["selectedCourses"];
            List<List<Course>> sectionsAvailable = new List<List<Course>>();
            SQLServerHandler sql = new SQLServerHandler("CoursesCS");

            foreach(DataRow dr in selectedCourses.Rows)
            {
                sql.CreateCommand("SELECT * FROM Schedule WHERE CourseNumber = @c");
                sql.AddParameter("@c", dr["CourseNumber"].ToString());
                sectionsAvailable.Add(sql.ExecuteCourseListQuery());
            }

            Scheduler s = new Scheduler(sectionsAvailable);
            bool success = s.searchForSchedule();
            if(success)
            {
                displaySchedule(s.schedule);
            }
            else
            {
                divSchedule.InnerHtml = "<h3>No schedule found.</h3>";
            }
            
        }

        protected void displaySchedule(List<Course> courses)
        {
            string html = "";
            html += "<h3>Schedule</h3>";

            html += "<table class=\"pure-table pure-table-horizontal\">";
            html += "<thead>";
            html += "<tr>";
            html += "<th>CRN</th>";
            html += "<th>Course Number</th>";
            html += "<th>Section Number</th>";
            html += "<th>Days</th>";
            html += "<th>Start Time</th>";
            html += "<th>End Time</th>";
            html += "</tr>";
            html += "</thead>";

            html += "<tbody>";
            foreach(Course c in courses)
            {
                html += "<tr>";
                html += ("<td>" + c.CRN + "</td>");
                html += ("<td>" + c.courseNumber + "</td>");
                html += ("<td>" + c.sectionNumber + "</td>");
                html += ("<td>" + c.days + "</td>");
                html += ("<td>" + c.startTime + "</td>");
                html += ("<td>" + c.endTime + "</td>");
            }

            html += "</tbody>";
            html += "</table>";

            divSchedule.InnerHtml = html;
        }
    }
}