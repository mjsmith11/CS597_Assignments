using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    }
}
