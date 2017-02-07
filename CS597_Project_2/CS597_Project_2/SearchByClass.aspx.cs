using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS597_Project_2
{
    public partial class SearchByClass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ddlClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string whereClause = GetWhereClause(ddlClasses.SelectedValue);
            if(whereClause!="")
            {
                lblError.Text = "";
                string qry = "SELECT FirstName,LastName FROM Academics AS a INNER JOIN Information AS i ON a.StudentIDNumber=i.StudentIDNumber "+whereClause;
                gvDisplay.DataSource = Utilities.NoParmSelect(qry);
                gvDisplay.DataBind();
            }
            else
            {
                lblError.Text = "An Error Has Occured";
            }
        }
        /// <summary>
        /// Returns an SQL where clause to filter on class as determined by credit hours
        /// </summary>
        /// <param name="classValue">fr for Freshman, so for Sophomore, ju for Junior, se for Senior</param>
        /// <returns>SQL Where Clause or "" for invalid input</returns>
        private string GetWhereClause(string classValue)
        {
            switch(classValue)
            {
                case "fr":
                    return "WHERE CreditHours>=0 AND CreditHours<=30";
                case "so":
                    return "WHERE CreditHours>=31 AND CreditHours<=60";
                case "ju":
                    return "WHERE CreditHours>=61 AND CreditHours<=90";
                case "se":
                    return "WHERE CreditHours>=91 AND CreditHours<=120";
                default:
                    return "";

            }
        }
    }
}