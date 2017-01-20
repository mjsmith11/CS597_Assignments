using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS597_Project1
{
    public partial class TotalDue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            int serviceCost, discountPercent;
            double totalCost;

            serviceCost = Int32.Parse(ddlService.SelectedValue);
            discountPercent = Int32.Parse(ddlDiscount.SelectedValue);

            totalCost = serviceCost - (serviceCost * (discountPercent / 100.0));

            tbxTotal.Text = totalCost.ToString("C");
        }
    }
}