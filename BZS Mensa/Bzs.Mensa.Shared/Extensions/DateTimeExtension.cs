namespace Bzs.Mensa.Shared.Extensions
{
    /// <summary>
    /// Represents extension methods of the <see cref="DateTime" /> class.
    /// </summary>
    public static class DateTimeExtension
    {
        /// <summary>
        /// Converts the date/time to an ISO date.
        /// </summary>
        /// <param name="datum">The date/time.</param>
        /// <returns>The ISO date.</returns>
        public static string ToIsoDate(this DateTime datum)
        {
            return datum.ToString("yyyy-MM-dd");
        }
    }
}
