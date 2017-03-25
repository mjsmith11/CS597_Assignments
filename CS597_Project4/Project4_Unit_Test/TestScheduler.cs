using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

using CS597_Project4;

namespace Project4_Unit_Test
{
    [TestClass]
    public class TestScheduler
    {
        [TestMethod]
        public void TestHasDayOverlap()
        {
            Course c1 = new Course(1, "123", "01", "MWF", "0800", "0900");
            Course c2 = new Course(2, "125", "01", "TR", "0800", "0900");
            Assert.IsFalse(Scheduler.haveDayOverlap(c1,c2), "No days in common");

            c2.days = "MTR";
            Assert.IsTrue(Scheduler.haveDayOverlap(c1, c2), "One day in common");

            c2.days = "MW";
            Assert.IsTrue(Scheduler.haveDayOverlap(c1, c2), "Two days in common");

            c2.days = "MWF";
            Assert.IsTrue(Scheduler.haveDayOverlap(c1, c2), "Identical days");
        }

        [TestMethod]
        public void TestHasTimeOverlap()
        {
            Course c1 = new Course(1, "123", "01", "MWF", "0800", "0900");
            Course c2 = new Course(2, "125", "01", "TR", "0900", "1000");

            Assert.IsTrue(Scheduler.haveTimeOverlap(c1, c1), "Courses at the same time");

            Assert.IsFalse(Scheduler.haveTimeOverlap(c1, c2), "Course 2 immediately after Course 1");
            Assert.IsFalse(Scheduler.haveTimeOverlap(c2, c1), "Course 1 immediately after Course 2");

            c2.startTime = "1000";
            c2.endTime = "1100";
            Assert.IsFalse(Scheduler.haveTimeOverlap(c1, c2), "Course 2 after Course 1 with a gap");
            Assert.IsFalse(Scheduler.haveTimeOverlap(c2, c1), "Course 2 after Course 1 with a gap");

            c2.startTime = "0845";
            c2.endTime = "0945";
            Assert.IsTrue(Scheduler.haveTimeOverlap(c1, c2), "Course 2 starts before Course 1 ends");
            Assert.IsTrue(Scheduler.haveTimeOverlap(c2, c1), "Course 1 starts before Course 2 ends");

            c2.startTime = "0730";
            c2.endTime = "0930";
            Assert.IsTrue(Scheduler.haveTimeOverlap(c1, c2), "Course 2 occurs during part of Course 1");
            Assert.IsTrue(Scheduler.haveTimeOverlap(c2, c1), "Course 1 occurs during part of Course 2");

            c2.startTime = "0800";
            c2.endTime = "0930";
            Assert.IsTrue(Scheduler.haveTimeOverlap(c1, c2), "Courses start at the same time but Course 1 ends first");
            Assert.IsTrue(Scheduler.haveTimeOverlap(c2, c1), "Courses start at the same time but Course 2 ends first");

            c2.startTime = "0730";
            c2.endTime = "0900";
            Assert.IsTrue(Scheduler.haveTimeOverlap(c1, c2), "Courses end at the same time, but Course 2 starts first");
            Assert.IsTrue(Scheduler.haveTimeOverlap(c2, c1), "Courses end at the same time, but Course 1 starts first");
        }

        [TestMethod]
        public void TestSearchForSchedule()
        {
            //create a list of options with no solution
            List<List<Course>> options = new List<List<Course>>();
            List<Course> c1 = new List<Course>();
            List<Course> c2 = new List<Course>();
            List<Course> c3 = new List<Course>();
            List<Course> c4 = new List<Course>();

            c1.Add(new Course(1, "101", "1", "MWF", "0800", "0900"));
            c2.Add(new Course(2, "202", "1", "MW", "0845", "0930"));
            c3.Add(new Course(3, "303", "1", "W", "0830", "0945"));
            c4.Add(new Course(4, "404", "1", "MWF", "1300", "1400"));

            options.Add(c1);
            options.Add(c2);
            options.Add(c3);
            options.Add(c4);

            Scheduler s = new Scheduler(options);
            Assert.IsFalse(s.searchForSchedule(), "No schedules are possible #1");

            //add another section of a course, but still no possible schedules will exist
            options[0].Add(new Course(5, "101", "2", "TR", "1100", "1215"));

            s = new Scheduler(options);
            Assert.IsFalse(s.searchForSchedule(), "No schedules are possible #2");

            //add a section that will create a possible schedule
            options[2].Add(new Course(6, "303", "2", "F", "1500", "1550"));

            s = new Scheduler(options);
            Assert.IsTrue(s.searchForSchedule(), "A schedule is possible #3");

            Assert.AreEqual(4, s.schedule.Count, "#3 Schedule should have 4 courses");

            Assert.IsTrue(s.schedule.Contains(options[0][1]), "#3 Schedule should contain course with id 5");
            Assert.IsTrue(s.schedule.Contains(options[1][0]), "#3 Schedule should contain course with id 2");
            Assert.IsTrue(s.schedule.Contains(options[2][1]), "#3 Schedule should contain course with id 6");
            Assert.IsTrue(s.schedule.Contains(options[3][0]), "#3 Schedule should contain course with id 4");

            Assert.IsFalse(s.schedule.Contains(options[0][0]), "#3 Schedule should not contain course with id 1");
            Assert.IsFalse(s.schedule.Contains(options[2][0]), "#3 Schedule should not contain course with id 3");

            //create new larger input for a more complex test
            options = new List<List<Course>>();
            c1 = new List<Course>();
            c2 = new List<Course>();
            c3 = new List<Course>();
            c4 = new List<Course>();

            c1.Add(new Course(1, "101", "1", "MWF", "0800", "0850"));
            c1.Add(new Course(5, "101", "2", "TR", "1100", "1215"));
            c1.Add(new Course(6, "101", "3", "MWF", "1300", "1350"));

            c2.Add(new Course(7, "202", "2", "WF", "1400", "1450"));
            c2.Add(new Course(2, "202", "1", "MW", "0845", "0935"));

            c3.Add(new Course(3, "303", "1", "W", "1430", "1520"));

            c4.Add(new Course(4, "404", "1", "MWF", "1300", "1400"));
            c4.Add(new Course(8, "404", "2", "TR", "0930", "1045"));
            c4.Add(new Course(9, "404", "3", "TR", "1400", "1515"));

            options.Add(c1);
            options.Add(c2);
            options.Add(c3);
            options.Add(c4);

            s = new Scheduler(options);
            Assert.IsTrue(s.searchForSchedule(), "A schedule is possible #4");

            Assert.AreEqual(4, s.schedule.Count, "#4 schedule should have 4 courses");

            Assert.IsTrue(s.schedule.Contains(options[0][1]), "#4 Schedule should contain course with id 5");
            Assert.IsTrue(s.schedule.Contains(options[1][1]), "#4 Schedule should contain course with id 2");
            Assert.IsTrue(s.schedule.Contains(options[2][0]), "#4 Schedule should contain course with id 3");
            Assert.IsTrue(s.schedule.Contains(options[3][0]), "#4 Schedule should contain course with id 4");

            Assert.IsFalse(s.schedule.Contains(options[0][0]), "#4 Schedule should not contain course with id 1");
            Assert.IsFalse(s.schedule.Contains(options[0][2]), "#4 Schedule should not contain course with id 6");
            Assert.IsFalse(s.schedule.Contains(options[1][0]), "#4 Schedule should not contain course with id 7");
            Assert.IsFalse(s.schedule.Contains(options[3][1]), "#4 Schedule should not contain course with id 8");
            Assert.IsFalse(s.schedule.Contains(options[3][2]), "#4 Schedule should not contain course with id 9");



        }
    }
}
