using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS597_Project_2
{
    public partial class SearchByState : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ddlStates.DataSource = Utilities.NoParmSelect("SELECT DISTINCT State From Information");
                ddlStates.DataValueField = "State";
                ddlStates.DataTextField = "State";
                ddlStates.DataBind();

            }
        }

        protected void ddlStates_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvDisplay.DataSource = Utilities.OneParmSelect("SELECT FirstName,LastName FROM Information WHERE State=@s", "@s", ddlStates.SelectedValue);
            gvDisplay.DataBind();
        }
    }
}