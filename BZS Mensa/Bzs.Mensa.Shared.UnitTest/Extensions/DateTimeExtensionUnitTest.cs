using System;
using Bzs.Mensa.Shared.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bzs.Mensa.Shared.UnitTest.Extensions
{
    /// <summary>
    /// Represents the unit tests of the <see cref="DateTimeExtension" /> class.
    /// </summary>
    [TestClass]
    public sealed class DateTimeExtensionUnitTest
    {
        /// <summary>
        /// Tests the method.
        /// </summary>
        [TestMethod]
        public void ToIsoDate()
        {
            DateTime datum = new DateTime(2022, 12, 13);

            string isoDatum = datum.ToIsoDate();

            Assert.AreEqual(@"2022-12-13", isoDatum);
        }

        /// <summary>
        /// Tests the method.
        /// </summary>
        [TestMethod]
        public void ToIsoDateTime()
        {
            DateTime datum = new DateTime(2022, 12, 13, 23, 59, 35);

            string isoDatum = datum.ToIsoDateTime();

            Assert.AreEqual(@"2022-12-13T23:59:35+01:00", isoDatum);
        }
    }
}
