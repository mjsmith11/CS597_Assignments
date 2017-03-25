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
        public bool scheduleFound { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="sections">The scheduler will attempt to choose one course from each List<Course> in the outer list such that the times do not conflict.</param>
        public Scheduler(List<List<Course>> sections)
        {
            this.sections = sections;
            this.schedule = new List<Course>();
            scheduleFound = true;
        }

        /// <summary>
        /// initializes variables and starts the recursive search
        /// </summary>
        /// <returns></returns>
        public bool searchForSchedule()
        {
            scheduleFound = false;
            schedule.Clear();
            return recursiveSearch();
        }
        /// <summary>
        /// Recursively searches for a schedule for the courses in sections that has no conflicts
        /// </summary>
        /// <param name="courseToAdd">Indicates which index of sections we are trying to add a course from. In most cases
        /// this should be the default value of 0 with the exception of recursive calls.</param>
        /// <returns>boolean indicating if an acceptable schedule was found</returns>
        private bool recursiveSearch(int courseToAdd=0)
        {
            if (foundSolution())
                return true;
            foreach(Course c in sections[courseToAdd])
            {
                if(safeToAdd(c))
                {
                    //push c onto the stack
                    schedule.Add(c); 

                    //the courseToAdd+1 will not cause an out of bounds index exception because foundSolution() will be true 
                    //if the index is out of bounds and recursiveSearch will return true
                    if(recursiveSearch(courseToAdd+1))
                    {
                        return true; //schedule is found!
                    }
                    else
                    {
                        //pop from the stack
                        schedule.RemoveAt(schedule.Count - 1);
                    }
                }
            }

            return false; //unable to find a solution
        }

        /// <summary>
        /// checks a course for time conflicts with the courses in the schedule
        /// </summary>
        /// <param name="c">course to check</param>
        /// <returns>true if c has no conflicts and false otherwise</returns>
        private bool safeToAdd(Course c)
        {
            foreach(Course scheduled in schedule)
            {
                if (Scheduler.haveOverlap(scheduled, c))
                    return false;
            }
            return true;
        }
        private bool foundSolution()
        {
            scheduleFound = (sections.Count == schedule.Count);
            return scheduleFound;
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