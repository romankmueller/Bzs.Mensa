using Bzs.Mensa.Shared.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Bzs.Mensa.Shared.UnitTest.Extensions
{
    /// <summary>
    /// Represents the unit tests of the <see cref="StringExtension" /> class.
    /// </summary>
    [TestClass]
    public sealed class StringExtensionUnitTest
    {
        /// <summary>
        /// Tests the method.
        /// </summary>
        [TestMethod]
        public void FromIsoDate()
        {
            string isoDatum = "2022-12-31";

            DateTime datum = isoDatum.FromIsoDate();

            Assert.AreEqual(new DateTime(2022, 12, 31), datum);
        }

        /// <summary>
        /// Tests the method.
        /// </summary>
        [TestMethod]
        public void FromIsoDateTime()
        {
            string isoDatumZeit = "2022-12-31T13:14:15+01:00";

            DateTime datumZeit = isoDatumZeit.FromIsoDateTime();

            Assert.AreEqual(new DateTime(2022, 12, 31, 13, 14, 15, 0), datumZeit);
        }
    }
}
