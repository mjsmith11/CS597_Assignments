using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS597_Project_2
{
    public partial class ParkingGarageCharges : System.Web.UI.Page
    {
        private const double MAX_HOURS_PARKED = 24.0;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            double hours;
            double cost;
            double roundedHours;

            hours = Utilities.getNonNegativeDoubleWithMax(tbxHours, MAX_HOURS_PARKED);

            if (hours > 0)
            {
                roundedHours = Math.Ceiling(hours);
                if (roundedHours <= 3)
                {
                    cost = 5;
                }
                else
                {
                    //$5 for first 3 hours and $1.50 for each additional hour
                    cost = 5 + (roundedHours - 3) * 1.5;
                }
                if (cost>18)
                {
                    //Maximum charge is $18
                    cost = 18;
                }

                tbxCost.Text = cost.ToString("C");
            }
            else
            {
                tbxCost.Text = "Hours must be 0-24";
            }

        }
    }
}