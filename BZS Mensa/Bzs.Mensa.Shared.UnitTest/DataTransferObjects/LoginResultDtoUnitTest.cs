using Bzs.Mensa.Shared.DataTransferObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bzs.Mensa.Shared.UnitTest.DataTransferObjects
{
    /// <summary>
    /// Represents the unit tests of the <see cref="LoginResultDto" /> class.
    /// </summary>
    [TestClass]
    public sealed class LoginResultDtoUnitTest
    {
        /// <summary>
        /// Tests the constructor.
        /// </summary>
        [TestMethod]
        public void Constructor()
        {
            LoginResultDto item = new LoginResultDto();

            Assert.IsNotNull(item);
            Assert.IsFalse(item.Succsessful);
            Assert.AreEqual(null, item.ErrorMessage);
            Assert.AreEqual(null, item.Token);
        }

        /// <summary>
        /// Tests the method.
        /// </summary>
        [TestMethod]
        public void SerializeDeserialize()
        {
            LoginResultDto item = new LoginResultDto(@"TToken");

            string json = item.ToJson();
            LoginResultDto newItem = DtoBase.Create<LoginResultDto>(json);

            Assert.AreEqual(item.Succsessful, newItem.Succsessful);
            Assert.AreEqual(item.Token, newItem.Token);
        }

        /// <summary>
        /// Tests the method.
        /// </summary>
        [TestMethod]
        public void SerializeDeserialize_Empty()
        {
            LoginResultDto item = new LoginResultDto();

            string json = item.ToJson();
            LoginResultDto newItem = DtoBase.Create<LoginResultDto>(json);

            Assert.AreEqual(item.Succsessful, newItem.Succsessful);
            Assert.AreEqual(item.Token, newItem.Token);
        }
    }
}
