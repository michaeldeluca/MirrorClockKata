using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MirroredClock.Tests
{
    [TestClass]
    public class MirroredClockTests
    {
        [DataTestMethod]
        [DataRow("12:22", "11:38")]
        [DataRow("01:50", "10:10")]
        [DataRow("11:58", "12:02")]
        [DataRow("12:01", "11:59")]
        [DataRow("12:02", "11:58")]
        [DataRow("10:36", "01:24")]
        [DataRow("12:00", "12:00")]
        [DataRow("11:00", "01:00")]
        public void Mirrored_time_is_correct(string time, string expected)
        {
            var actual = new TimeConverter().Mirror(time);
            Assert.AreEqual(expected, actual);
        }
    }

    public class TimeConverter
    {
        public string Mirror(string time)
        {
            var timeAsDateTime = DateTime.Parse(time);

            return new DateTime(2021, 01, 01)
                      .AddHours(11 - timeAsDateTime.Hour)
                      .AddMinutes(60 - timeAsDateTime.Minute)
                      .ToString("hh:mm");
        }
    }
}