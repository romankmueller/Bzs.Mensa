using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Bzs.Mensa.Shared.Helpers
{
    /// <summary>
    /// Represents the unit tests of the <see cref="PasswordHelper" /> class.
    /// </summary>
    [TestClass]
    public sealed class PasswordHelperUnitTest
    {
        /// <summary>
        /// Tests the method.
        /// </summary>
        [TestMethod]
        public void CreateSalt()
        {
            string value = PasswordHelper.CreateSalt(32);

            Assert.IsNotNull(value);
        }

        /// <summary>
        /// Tests the method.
        /// </summary>
        [TestMethod]
        public void CreateHash()
        {
            string input = @"ITest";
            string salt = PasswordHelper.CreateSalt(32);
            string value = PasswordHelper.GenerateHash(input, salt);

            Assert.AreNotEqual(input, value);
        }

        /// <summary>
        /// Tests the method.
        /// </summary>
        [TestMethod]
        public void AreEqual_Valid()
        {
            string input = @"ITest";
            string salt = PasswordHelper.CreateSalt(32);
            string hash = PasswordHelper.GenerateHash(input, salt);

            bool value = PasswordHelper.AreEqual(input, hash, salt);

            Assert.IsTrue(value);
        }

        /// <summary>
        /// Tests the method.
        /// </summary>
        [TestMethod]
        public void AreEqual_Invalid()
        {
            string input = @"ITest";
            string salt = PasswordHelper.CreateSalt(32);
            string hash = PasswordHelper.GenerateHash(input, salt);

            bool value = PasswordHelper.AreEqual(@"WATest", hash, salt);

            Assert.IsFalse(value);
        }
    }
}
