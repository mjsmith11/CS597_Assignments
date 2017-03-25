using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS597_Project4
{
    public class Course
    {
        public int CRN { get; set; }
        public string courseNumber { get; set; }
        public string sectionNumber { get; set; }
        public string days { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }


        public Course(int CRN, string courseNumber, string sectionNumber, string days, string startTime, string endTime)
        {
            this.CRN = CRN;
            this.courseNumber = courseNumber;
            this.sectionNumber = sectionNumber;
            this.days = days;
            this.startTime = startTime;
            this.endTime = endTime;
        }
    }
}