using System;
using Bzs.Mensa.Shared.DataTransferObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Bzs.Mensa.Shared.UnitTest.DataTransferObjects
{
    /// <summary>
    /// Represents the unit tests of the <see cref="AllergieEditDtoUnitTest" /> class.
    /// </summary>
    [TestClass]
    public sealed class AllergieEditDtoUnitTest
    {
        /// <summary>
        /// Tests the method.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public void SerializeDeserialize()
        {
            AllergieEditDto item = new AllergieEditDto(Guid.NewGuid(), @"TestBezeichnung");

            string json = item.ToJson();
            AllergieEditDto newItem = DtoBase.Create<AllergieEditDto>(json);

            Assert.AreEqual(item.Id, newItem.Id);
            Assert.AreEqual(item.Bezeichnung, newItem.Bezeichnung);
        }
    }
}
