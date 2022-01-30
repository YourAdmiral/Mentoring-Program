using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using StringSum;
using System;

namespace StringSumTests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Sum_ThrowsArgumentNullException()
        {
            StringSummer.Sum(null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Sum_With_NullArgument_ThrowsArgumentNullException()
        {
            StringSummer.Sum(null, "5");
        }

        [TestMethod]
        public void Sum_InvalidNumberFormat_ThrowFormatException()
        {
            NUnit.Framework.Assert.That(() => StringSummer.Sum("0xFA1B", "-9999999999999999"), Throws.InstanceOf<FormatException>());
        }

        [TestMethod]
        public void Sum_NotNaturalNums_Returns0()
        {
            NUnit.Framework.Assert.That(() => StringSummer.Sum("6", "8"), Is.EqualTo("0"));
        }

        [TestMethod]
        public void Sum_NaturalNums_Returns7()
        {
            NUnit.Framework.Assert.That(() => StringSummer.Sum("2", "5"), Is.EqualTo("7"));
        }
    }
}
