using System;
using System.Collections.Generic;
using Bzs.Mensa.Shared.DataTransferObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bzs.Mensa.Shared.UnitTest.DataTransferObjects
{
    /// <summary>
    /// Represents the unit tests of the <see cref="ItemDto" /> class.
    /// </summary>
    [TestClass]
    public class ItemDtoUnitTest
    {
        /// <summary>
        /// Tests the default constructor.
        /// </summary>
        [TestMethod]
        public void Constructor()
        {
            ItemDto item = new ItemDto();

            Assert.IsNotNull(item);
            Assert.IsFalse(item.Id == Guid.Empty);
        }

        /// <summary>
        /// Tests the default constructor.
        /// </summary>
        [TestMethod]
        public void Constructor_Id()
        {
            Guid id = Guid.NewGuid();

            ItemDto item = new ItemDto(id);

            Assert.IsNotNull(item);
            Assert.IsTrue(item.Id == id);
        }

        /// <summary>
        /// Tests the serialization/deserialization.
        /// </summary>
        [TestMethod]
        public void SerializeDeserialize()
        {
            ItemDto source = new ItemDto(Guid.NewGuid());

            string json = source.ToJson();

            ItemDto target = DtoBase.Create<ItemDto>(json);

            Assert.IsNotNull(target);
            Assert.AreEqual(source.Id, target.Id);
        }

        /// <summary>
        /// Tests the serialization/deserialization of a list.
        /// </summary>
        [TestMethod]
        public void SerializeDeserialize_List()
        {
            List<ItemDto> sourceItems = new List<ItemDto>();
            sourceItems.Add(new ItemDto(Guid.NewGuid()));
            sourceItems.Add(new ItemDto(Guid.NewGuid()));

            string json = sourceItems.ToJson();

            List<ItemDto> targetItems = DtoBase.CreateList<ItemDto>(json);

            Assert.IsNotNull(targetItems);
            Assert.AreEqual(sourceItems.Count, targetItems.Count);
        }
    }
}