using Bzs.Mensa.Shared.DataTransferObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Bzs.Mensa.Shared.UnitTest.DataTransferObjects
{
    /// <summary>
    /// Represents the unit tests of the <see cref="FerienEditDto" /> class.
    /// </summary>
    [TestClass]
    public sealed class FerienEditDtoUnitTest
    {
        /// <summary>
        /// Tests the method.
        /// </summary>
        [TestMethod]
        public void SerializeDeserialize()
        {
            FerienEditDto item = new FerienEditDto(Guid.NewGuid(), @"TBezeichnung", DateTime.Today, DateTime.Today.AddDays(1));

            string json = item.ToJson();
            FerienEditDto newItem = DtoBase.Create<FerienEditDto>(json);

            Assert.AreEqual(item.Id, newItem.Id);
            Assert.AreEqual(item.Bezeichnung, newItem.Bezeichnung);
            Assert.AreEqual(item.VonDatum, newItem.VonDatum);
            Assert.AreEqual(item.BisDatum, newItem.BisDatum);
        }
    }
}
