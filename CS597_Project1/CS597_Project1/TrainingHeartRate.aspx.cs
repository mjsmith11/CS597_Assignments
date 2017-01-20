using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS597_Project1
{
    public partial class TrainingHeartRate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            int age;
            int restingHeartRate;
            int maxHeartRate;
            //training heart rate may be a decimal because the calculation involves taking 60% of a quantity
            double trainingHeartRate;

            age = getAge();
            if(age==-1)
            {
                return;
            }

            restingHeartRate = getRestingHR();
            if(restingHeartRate==-1)
            {
                return;
            }

            maxHeartRate = 220 - age;
            trainingHeartRate = ((maxHeartRate - restingHeartRate) * 0.6) + restingHeartRate;

            tbxTrainingHR.Text = trainingHeartRate.ToString();    
        }

        /// <summary>
        /// Parses tbxAge.Text for an integer and checks that the integer is between 0 and 100.
        /// Puts an error message in tbxTrainingHR if the age input fails validation
        /// </summary>
        /// <returns>Age input if it passes validation. -1 otherwise</returns>
        private int getAge()
        {
            int age;
            try
            {
                age = Int32.Parse(tbxAge.Text);
            }
            catch (FormatException e)
            {
                tbxTrainingHR.Text = "Age must be a whole number";
                return -1;
            }
            if (age>100 || age<0)
            {
                tbxTrainingHR.Text = "Age must be between 0 and 100";
                return -1;
            }

            return age;
        }

        /// <summary>
        /// Parses tbxRestingHR for an integer and checks that the integer is between 30 and 110
        /// (From the mayo clinic website normal resting heart rates are between 60 and 100. Additionally,
        /// a well-trained athlete's resting heart rate may be as low as 40)
        /// Puts an error message in tbxTrainingHR if the resting heart rate fails validation
        /// </summary>
        /// <returns>Resting Heart Rate Input if it passes validation. -1 otherwise</returns>
        private int getRestingHR()
        {
            int hr;
            try
            {
                hr = Int32.Parse(tbxRestingHR.Text);
            }
            catch(FormatException e)
            {
                tbxTrainingHR.Text = "Resting Heart Rate must be a whole number";
                return -1;
            }
            if(hr>110 || hr<30)
            {
                tbxTrainingHR.Text = "Resting Heart Rate must be between 30 and 110";
                return -1;
            }
            return hr;
        }
    }
}