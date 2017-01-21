using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS597_Project1
{
    public partial class MonthlyPayment : System.Web.UI.Page
    {
        private bool fieldsValid;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            double price, downPayment, APR, years, monthlyPayment, i, n;

            fieldsValid = true;
            price = getPositiveDecimal(tbxPrice);
            downPayment = getPositiveDecimal(tbxDownPayment);
            APR = getPositiveDecimal(tbxAPR);
            years = getPositiveDecimal(tbxYears);

            if (fieldsValid)
            {
                i = APR / 1200;
                n = years * 12;

                monthlyPayment = ((price - downPayment) * i * Math.Pow(1 + i, n)) / (Math.Pow(1 + i, n) - 1);
                tbxMonthlyPayment.Text = monthlyPayment.ToString("C");
            }
            else
            {
                tbxMonthlyPayment.Text = "Invalid Input";
            }
        }
        /// <summary>
        /// Retrieves the text from the passed control and validates it as a positive double. 
        /// Sets the class member fieldsValid to false if validation fails
        /// </summary>
        /// <param name="control">Control to retrieve text from</param>
        /// <returns>The value from the control if validation is successful. -1 otherwise</returns>
        private double getPositiveDecimal(TextBox control)
        {
            double value;
            try
            {
                value = Double.Parse(control.Text);
            }
            catch(FormatException e)
            {
                fieldsValid = false;
                return -1;
            }

            if(value >= 0)
            {
                return value;
            }
            else
            {
                fieldsValid = false;
                return -1;
            }
        }
    }
};