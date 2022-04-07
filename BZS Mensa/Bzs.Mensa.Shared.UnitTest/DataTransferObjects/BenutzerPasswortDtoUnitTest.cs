using System;
using Bzs.Mensa.Shared.DataTransferObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bzs.Mensa.Shared.UnitTest.DataTransferObjects
{
    /// <summary>
    /// Represents the unit tests of the <see cref="BenutzerPasswortDto" /> class.
    /// </summary>
    [TestClass]
    public sealed class BenutzerPasswortDtoUnitTest
    {
        /// <summary>
        /// Tests the method.
        /// </summary>
        [TestMethod]
        public void SerializeDeserialize()
        {
            BenutzerPasswortDto item = new BenutzerPasswortDto(Guid.NewGuid(), @"TPasswort");

            string json = item.ToJson();
            BenutzerPasswortDto newItem = DtoBase.Create<BenutzerPasswortDto>(json);

            Assert.AreEqual(item.Id, newItem.Id);
            Assert.AreEqual(item.Passwort, newItem.Passwort);
        }
    }
}
