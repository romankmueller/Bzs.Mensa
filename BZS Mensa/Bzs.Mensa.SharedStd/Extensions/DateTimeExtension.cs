using System;

namespace Bzs.Mensa.Shared.Extensions
{
    /// <summary>
    /// Represents extension methods of the <see cref="DateTime" /> class.
    /// </summary>
    public static class DateTimeExtension
    {
        /// <summary>
        /// Converts the date to an ISO date.
        /// </summary>
        /// <param name="datum">The date.</param>
        /// <returns>The ISO date.</returns>
        public static string ToIsoDate(this DateTime datum)
        {
            return datum.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// Converts the date/time to an ISO date/time.
        /// </summary>
        /// <param name="datumZeit">The date/time.</param>
        /// <returns>The ISO date/time.</returns>
        public static string ToIsoDateTime(this DateTime datumZeit)
        {
            return datumZeit.ToString("yyyy-MM-dd'T'HH:mm:sszzz");
        }
    }
}
