using System;
using Bzs.Mensa.Shared.DataTransferObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bzs.Mensa.Shared.UnitTest.DataTransferObjects
{
    /// <summary>
    /// Represents the unit tests of the <see cref="KlasseEditDto" /> class.
    /// </summary>
    [TestClass]
    public sealed class KlasseEditDtoUnitTest
    {
        /// <summary>
        /// Tests the method.
        /// </summary>
        [TestMethod]
        public void SerializeDeserialize()
        {
            KlasseEditDto item = new KlasseEditDto(Guid.NewGuid(), "TestBezeichnung", true, false);

            string json = item.ToJson();
            KlasseEditDto newItem = DtoBase.Create<KlasseEditDto>(json);

            Assert.AreEqual(item.Id, newItem.Id);
            Assert.AreEqual(item.Bezeichnung, newItem.Bezeichnung);
            Assert.AreEqual(item.Schicht1, newItem.Schicht1);
            Assert.AreEqual(item.Schicht2, newItem.Schicht2);
        }
    }
}
