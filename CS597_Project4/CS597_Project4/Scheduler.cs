using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS597_Project4
{
    public class Scheduler
    {
        private List<List<Course>> sections { get; set; }
        public List<Course> schedule { get; set; }
        public bool resultFound { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="sections">The scheduler will attempt to choose one course from each List<Course> in the outer list such that the times do not conflict.</param>
        Scheduler(List<List<Course>> sections)
        {
            this.sections = sections;
            this.schedule = new List<Course>();
            resultFound = true;
        }


        public static bool haveOverlap(Course c1, Course c2)
        {
            return (haveDayOverlap(c1, c2) && haveTimeOverlap(c1, c2));
        }
        public static bool haveDayOverlap(Course c1, Course c2)
        {
            foreach(char ch in c1.days)
            {
                if (c2.days.Contains(ch))
                    return true;
            }

            return false;
        }

        public static bool haveTimeOverlap(Course c1, Course c2)
        {
            int start1 = Int32.Parse(c1.startTime);
            int end1 = Int32.Parse(c1.endTime);
            int start2 = Int32.Parse(c2.startTime);
            int end2 = Int32.Parse(c2.endTime);

            //c1 ends before c2 starts
            if (end1 <= start2)
                return false;

            if (end2 <= start1)
                return false;

            return true;
        }
    }
}