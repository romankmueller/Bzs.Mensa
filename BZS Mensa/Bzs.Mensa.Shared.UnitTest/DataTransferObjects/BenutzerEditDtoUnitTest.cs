using System;
using Bzs.Mensa.Shared.DataTransferObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bzs.Mensa.Shared.UnitTest.DataTransferObjects
{
    /// <summary>
    /// Represents the unit tests of the <see cref="BenutzerEditDto" /> class.
    /// </summary>
    [TestClass]
    public sealed class BenutzerEditDtoUnitTest
    {
        /// <summary>
        /// Tests the method.
        /// </summary>
        [TestMethod]
        public void SerializeDeserialize()
        {
            BenutzerEditDto item = new BenutzerEditDto(Guid.NewGuid(), @"TBenutzerName", "test@email.com", "TNachname", "TVorname", Guid.NewGuid(), true);

            string json = item.ToJson();
            BenutzerEditDto newItem = DtoBase.Create<BenutzerEditDto>(json);

            Assert.AreEqual(item.Id, newItem.Id);
            Assert.AreEqual(item.Benutzername, newItem.Benutzername);
            Assert.AreEqual(item.Email, newItem.Email);
            Assert.AreEqual(item.Nachname, newItem.Nachname);
            Assert.AreEqual(item.Vorname, newItem.Vorname);
            Assert.AreEqual(item.KlasseId, newItem.KlasseId);
            Assert.AreEqual(item.Vegetarisch, newItem.Vegetarisch);
        }
    }
}
