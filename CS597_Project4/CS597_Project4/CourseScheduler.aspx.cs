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
        DataTable availableCourses;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                SQLServerHandler sql = new SQLServerHandler("CoursesCS");
                sql.CreateCommand("SELECT DISTINCT CourseNumber FROM Schedule");
                availableCourses = sql.ExecuteDataAdapterQuery();
                ddlCourses.DataSource = availableCourses;
                ddlCourses.DataTextField = "CourseNumber";
                ddlCourses.DataValueField = "CourseNumber";
                ddlCourses.DataBind();
            }
            
        }
    }
}