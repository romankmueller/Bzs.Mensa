using System;
using Bzs.Mensa.Shared.DataTransferObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bzs.Mensa.Shared.UnitTest.DataTransferObjects
{
    /// <summary>
    /// Represents the unit tests of the <see cref="BenutzerAllergieEditDto" /> class.
    /// </summary>
    [TestClass]
    public sealed class BenutzerAllergieEditDtoUnitTest
    {
        /// <summary>
        /// Tests the method.
        /// </summary>
        [TestMethod]
        public void SerializeDeserialize()
        {
            BenutzerAllergieEditDto item = new BenutzerAllergieEditDto(Guid.NewGuid(), Guid.NewGuid(), @"TestBezeichnung");

            string json = item.ToJson();
            BenutzerAllergieEditDto newItem = DtoBase.Create<BenutzerAllergieEditDto>(json);

            Assert.AreEqual(item.Id, newItem.Id);
            Assert.AreEqual(item.AllergieId, newItem.AllergieId);
            Assert.AreEqual(item.AllergieBezeichnung, newItem.AllergieBezeichnung);
        }
    }
}
