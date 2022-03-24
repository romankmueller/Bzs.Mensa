using System.Globalization;

namespace Bzs.Mensa.Shared.Extensions
{
    /// <summary>
    /// Represents the extension methods of the <see cref="string" /> class.
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// Returns the date/time from the ISO date.
        /// </summary>
        /// <param name="isoDatum">The ISO date.</param>
        /// <returns>The date/time.</returns>
        public static DateTime FromIsoDate(this string isoDatum)
        {
            if (isoDatum == null || isoDatum.Length != 10)
            {
                return DateTime.Today;
            }

            return DateTime.ParseExact(isoDatum, @"yyyy-MM-dd", CultureInfo.InvariantCulture);
        }
    }
}
