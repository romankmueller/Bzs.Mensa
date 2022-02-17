using System;
using System.Collections.Generic;
using Bzs.Mensa.Shared.DataTransferObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bzs.Mensa.Shared.UnitTest.DataTransferObjects
{
    /// <summary>
    /// Represents the unit tests of the <see cref="DtoBase" /> class.
    /// </summary>
    [TestClass]
    public class DtoBaseUnitTest
    {
        /// <summary>
        /// Tests the creation of an object with a NULL JSON representation.
        /// </summary>
        [TestMethod]
        public void Create_Null_ArgumentNullException()
        {
            try
            {
                DtoBase.Create<DtoBase>(null);

                Assert.Fail(@"Should throw an ArgumentNullException.");
            }
            catch (ArgumentNullException)
            {
            }
        }

        /// <summary>
        /// Tests the creation of an object with an empty JSON representation.
        /// </summary>
        [TestMethod]
        public void Create_Empty()
        {
            DtoBase value = DtoBase.Create<DtoBase>(string.Empty);

            Assert.IsNull(value);
        }

        /// <summary>
        /// Tests the creation of an object with a JSON representation.
        /// </summary>
        [TestMethod]
        public void Create_Json()
        {
            DtoBase value = DtoBase.Create<DtoBase>(@"{ }");

            Assert.IsNotNull(value);
        }

        /// <summary>
        /// Tests the creation of an object list with a NULL JSON representation.
        /// </summary>
        [TestMethod]
        public void CreateList_Null()
        {
            try
            {
                DtoBase.CreateList<DtoBase>(null);

                Assert.Fail(@"Should throw an ArgumentNullException.");
            }
            catch (ArgumentNullException)
            {
            }
        }

        /// <summary>
        /// Tests the creation of an object list with an empty JSON representation.
        /// </summary>
        [TestMethod]
        public void CreateList_Empty()
        {
            List<DtoBase> value = DtoBase.CreateList<DtoBase>(string.Empty);

            Assert.IsNull(value);
        }

        /// <summary>
        /// Tests the creation of an object list with a JSON representation.
        /// </summary>
        [TestMethod]
        public void CreateList_Json()
        {
            List<DtoBase> value = DtoBase.CreateList<DtoBase>(@"[]");

            Assert.IsNotNull(value);
        }
    }
}
