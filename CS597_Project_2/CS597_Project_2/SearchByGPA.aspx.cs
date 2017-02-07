using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS597_Project_2
{
    public partial class SearchByGPA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            double searchGPA = Utilities.GetNonNegativeDouble(tbxGPA);
            if(searchGPA>=0)
            {
                string qry = "SELECT FirstName, LastName FROM Academics AS a INNER JOIN Information AS i ON a.StudentIDNumber = i.StudentIDNumber WHERE GPA >= @g";
                gvDisplay.DataSource = Utilities.OneParmSelect(qry, "@g", searchGPA.ToString());
                gvDisplay.DataBind();
            }
            else
            {
                gvDisplay.DataSource = null;
                gvDisplay.DataBind();
                lblError.Text = "GPA Input Invalid";
            }
        }
    }
}