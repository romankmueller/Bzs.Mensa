using System;
using Bzs.Mensa.Shared.DataTransferObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bzs.Mensa.Shared.UnitTest.DataTransferObjects
{
    /// <summary>
    /// Represents the unit tests of the <see cref="ResultDto" /> class.
    /// </summary>
    [TestClass]
    public sealed class ResultDtoUnitTest
    {
        /// <summary>
        /// Tests the constructor.
        /// </summary>
        [TestMethod]
        public void Constructor_Standard()
        {
            ResultDto item = new ResultDto();

            Assert.IsNotNull(item);
            Assert.IsFalse(item.Succsessful);
            Assert.AreEqual(null, item.ErrorMessage);
        }

        /// <summary>
        /// Tests the constructor.
        /// </summary>
        [TestMethod]
        public void Constructor_Successful()
        {
            ResultDto item = new ResultDto(true);

            Assert.IsNotNull(item);
            Assert.IsTrue(item.Succsessful);
            Assert.AreEqual(null, item.ErrorMessage);
        }

        /// <summary>
        /// Tests the constructor.
        /// </summary>
        [TestMethod]
        public void Constructor_ErrorMessage()
        {
            string errorMessage = @"TErrorMessage";

            ResultDto item = new ResultDto(errorMessage);

            Assert.IsNotNull(item);
            Assert.IsFalse(item.Succsessful);
            Assert.AreEqual(errorMessage, item.ErrorMessage);
        }

        /// <summary>
        /// Tests the constructor.
        /// </summary>
        [TestMethod]
        public void Constructor_Exception()
        {
            ResultDto item = new ResultDto(new NotImplementedException());

            Assert.IsNotNull(item);
            Assert.IsFalse(item.Succsessful);
            Assert.IsFalse(string.IsNullOrEmpty(item.ErrorMessage));
        }

        /// <summary>
        /// Tests the method.
        /// </summary>
        [TestMethod]
        public void SerializeDeserialize()
        {
            ResultDto item = new ResultDto(true);
            item.ErrorMessage = @"TErrorMessage";

            string json = item.ToJson();
            ResultDto newItem = DtoBase.Create<ResultDto>(json);

            Assert.AreEqual(item.Succsessful, newItem.Succsessful);
            Assert.AreEqual(item.ErrorMessage, newItem.ErrorMessage);
        }
    }
}
