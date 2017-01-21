using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS597_Project1
{
    public partial class GradeCalculator : System.Web.UI.Page
    {
        private bool fieldsValid;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            double quizScore, assignmentScore, midtermScore, finalExamScore, averageScore;
            string letterGrade;

            fieldsValid = true;
            quizScore = getScore(tbxQuiz);
            assignmentScore = getScore(tbxAssignment);
            midtermScore = getScore(tbxMidterm);
            finalExamScore = getScore(tbxFinal);

            if(fieldsValid)
            {
                averageScore = (quizScore * 0.15) + (assignmentScore * 0.40) + (midtermScore * 0.20) + (finalExamScore * 0.25);
                letterGrade = getLetter(averageScore);
                tbxPercentage.Text = averageScore.ToString();
                tbxLetter.Text = letterGrade.ToString();

            }
            else
            {
                tbxPercentage.Text = "Invalid";
                tbxLetter.Text = "Input";
            }

        }

        /// <summary>
        /// Retrieves the text from the passed control and validates it as a score. 
        /// Sets the class member fieldsValid to false if validation fails
        /// </summary>
        /// <param name="control">Control to retrieve text from</param>
        /// <returns>The score from the control if validation is successful. -1 otherwise</returns>
        private double getScore(TextBox control)
        {
            double score;
            try
            {
                score = Double.Parse(control.Text);
            }
            catch(FormatException e)
            {
                fieldsValid = false;
                return -1;
            }
            if(score>=0)
            {
                return score;
            }
            else
            {
                fieldsValid = false;
                return -1;
            }
        }

        public string getLetter(double score)
        {
            if (score >= 93)
                return "A";
            else if (score >= 90)
                return "A-";
            else if (score >= 87)
                return "B+";
            else if (score >= 83)
                return "B";
            else if (score >= 80)
                return "B-";
            else if (score >= 77)
                return "C+";
            else if (score >= 73)
                return "C";
            else if (score >= 70)
                return "C-";
            else if (score >= 67)
                return "D+";
            else if (score >= 63)
                return "D";
            else if (score >= 60)
                return "D-";
            else
                return "F";
        }
    }
}