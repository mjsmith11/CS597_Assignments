using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace CS597_Project_2
{
    public class Utilities
    {
        /// <summary>
        /// Parses the value of a drop down list for a double value that is not less than 0
        /// </summary>
        /// <param name="ddl">Drop Down List Control</param>
        /// <returns>The double value from the control if it is non-negative
        ///          -1 if the value cannot be parsed as a double
        ///          -2 if the value is negative</returns>
        public static double getNonNegativeDouble(DropDownList ddl)
        {
            double value;
            try
            {
                value = Double.Parse(ddl.SelectedValue);
            }
            catch (FormatException e)
            {
                return -1;
            }
            if (value < 0)
            {
                return -2;
            }

            return value;
        }
    

        /// <summary>
        /// Parses the value of a textbox for a int value that is not less than 0
        /// </summary>
        /// <param name="tbx">TextBox Control</param>
        /// <returns>The int value from the control if it is non-negative
        ///          -1 if the value cannot be parsed as a int
        ///          -2 if the value is negative</returns>
        public static int getNonNegativeInt(TextBox tbx)
        {
            int value;
            try
            {
                value = Int32.Parse(tbx.Text);
            }
            catch (FormatException e)
            {
                return -1;
            }
            if (value < 0)
            {
                return -2;
            }

            return value;
        }

        /// <summary>
        /// Parses the value of a textbox for a double value that is between 0 and max inclusive
        /// </summary>
        /// <param name="tbx">TextBox Control</param>
        /// <param name="max">Maximum Valid Value</param>
        /// <returns>The int value from the control if it is non-negative
        ///          -1 if the value cannot be parsed as a int
        ///          -2 if the value is negative
        ///          -3 if the value is too large</returns>
        public static double getNonNegativeDoubleWithMax(TextBox tbx,double max)
        {
            double value;
            try
            {
                value = Double.Parse(tbx.Text);
            }
            catch (FormatException e)
            {
                return -1;
            }
            if (value < 0)
            {
                return -2;
            }
            else if(value>max)
            {
                return -3;
            }

            return value;
        }
    }
    
}