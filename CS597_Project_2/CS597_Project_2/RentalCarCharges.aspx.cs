using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS597_Project_2
{
    public partial class RentalCarCharges : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            double price,cost;
            int days;
            price = Utilities.getNonNegativeDouble(ddlType);
            //This works under the assumption that cars are rented in whole days
            days = Utilities.getNonNegativeInt(tbxDays);

            if(price<0)
            {
                tbxCharges.Text = "Invalid Vehicle Type";
            }
            else if(days<0)
            {
                tbxCharges.Text = "Invalid Number of Days";
            }
            else
            {
                cost = price * days;
                tbxCharges.Text = cost.ToString("C");
            }

        }
    }
}