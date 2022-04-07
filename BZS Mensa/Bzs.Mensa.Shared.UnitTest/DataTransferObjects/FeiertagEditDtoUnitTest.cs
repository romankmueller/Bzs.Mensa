using Bzs.Mensa.Shared.DataTransferObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Bzs.Mensa.Shared.UnitTest.DataTransferObjects
{
    /// <summary>
    /// Represents the unit tests of the <see cref="FeiertagEditDto" /> class.
    /// </summary>
    [TestClass]
    public sealed class FeiertagEditDtoUnitTest
    {
        /// <summary>
        /// Tests the method.
        /// </summary>
        [TestMethod]
        public void SerializeDeserialize()
        {
            FeiertagEditDto item = new FeiertagEditDto(Guid.NewGuid(), @"TBezeichnung", DateTime.Today);

            string json = item.ToJson();
            FeiertagEditDto newItem = DtoBase.Create<FeiertagEditDto>(json);

            Assert.AreEqual(item.Id, newItem.Id);
            Assert.AreEqual(item.Bezeichnung, newItem.Bezeichnung);
            Assert.AreEqual(item.Datum, newItem.Datum);
        }
    }
}
