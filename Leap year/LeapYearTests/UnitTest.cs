using Leap_year;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;

namespace LeapYearTests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IsLeapYear_InputYearLessThan1_OrOverThan9999_ThrowsArgumentOutOfRangeException()
        {
            LeapYear.IsLeapYear(-111);
        }

        [TestMethod]
        public void IsLeapYear_Input1996_ReturnsTrue()
        {
            int year = 1996;

            bool isLeapYear = LeapYear.IsLeapYear(year);

            NUnit.Framework.Assert.That(() => isLeapYear, Is.EqualTo(true));
        }

        [TestMethod]
        public void IsLeapYear_Input2001_ReturnsFalse()
        {
            int year = 2001;

            bool isLeapYear = LeapYear.IsLeapYear(year);

            NUnit.Framework.Assert.That(() => isLeapYear, Is.EqualTo(false));
        }
    }
}
