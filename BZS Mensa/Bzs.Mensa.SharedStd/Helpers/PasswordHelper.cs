using System;
using System.Security.Cryptography;
using System.Text;

namespace Bzs.Mensa.Shared.Helpers
{
    /// <summary>
    /// Represents a password helper.
    /// </summary>
    public static class PasswordHelper
    {
        /// <summary>
        /// Creates a salt.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <returns>The salt.</returns>
        public static string CreateSalt(int size)
        {
            byte[] buffer = new byte[size];
            using (RandomNumberGenerator rng = RNGCryptoServiceProvider.Create())
            {
                rng.GetBytes(buffer);
            }

            return Convert.ToBase64String(buffer);
        }

        /// <summary>
        /// Returns the hash.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="salt">The salt.</param>
        /// <returns>The hash.</returns>
        public static string GenerateHash(string input, string salt)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input + salt);
            byte[] hash;
            using (SHA256 sha256ManagedString = SHA256Managed.Create())
            {
                hash = sha256ManagedString.ComputeHash(bytes);
            }

            return Convert.ToBase64String(hash);
        }

        /// <summary>
        /// Returns a value indicating whether the plain text input equals the hash input.
        /// </summary>
        /// <param name="plainTextInput">The plain text input.</param>
        /// <param name="hashedInput">The hashed input.</param>
        /// <param name="salt">The salt.</param>
        /// <returns>The values are equal.</returns>
        public static bool AreEqual(string plainTextInput, string hashedInput, string salt)
        {
            string hashedPlainText = GenerateHash(plainTextInput, salt);
            return hashedPlainText.Equals(hashedInput, StringComparison.Ordinal);
        }
    }
}
