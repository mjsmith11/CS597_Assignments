using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS597_Project_2
{
    public partial class SearchByAreaCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //Since we are searching by area code a wildcard is only needed at the end.
            //Invalid input will not cause an exception. it will simply yield no results
            string qry = "SELECT * FROM Information WHERE Phone LIKE @p";
            gvDisplay.DataSource = Utilities.OneParmSelect(qry, "@p", tbxAreaCode.Text+"%");
            gvDisplay.DataBind();
        }
    }
}