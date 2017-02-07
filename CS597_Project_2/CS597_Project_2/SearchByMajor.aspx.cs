using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS597_Project_2
{
    public partial class SearchByMajor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlMajors.DataSource = Utilities.NoParmSelect("SELECT * From Majors");
                ddlMajors.DataValueField = "MajorCode";
                ddlMajors.DataTextField = "MajorName";
                ddlMajors.DataBind();

            }
        }

        protected void ddlMajors_SelectedIndexChanged(object sender, EventArgs e)
        {
            string qry = "SELECT FirstName,LastName FROM Academics AS a INNER JOIN Information AS i ON a.StudentIDNumber=i.StudentIDNumber WHERE MajorCode=@m";
            gvDisplay.DataSource = Utilities.OneParmSelect(qry, "@m", ddlMajors.SelectedValue);
            gvDisplay.DataBind();
        }
    }
}