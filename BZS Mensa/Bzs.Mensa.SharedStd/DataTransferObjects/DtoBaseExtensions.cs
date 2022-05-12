using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Bzs.Mensa.Shared.DataTransferObjects
{
    /// <summary>
    /// Represents extensions of the <see cref="DtoBase" /> class.
    /// </summary>
    public static class DtoBaseExtensions
    {
        /// <summary>
        /// Creates the JSON representation of the object.
        /// </summary>
        /// <returns>The JSON representation.</returns>
        /// <exception cref="ArgumentNullException">The argument null exception.</exception>
        public static string ToJson<T>(T item) where T : DtoBase
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            return JsonConvert.SerializeObject(item);
        }

        /// <summary>
        /// Creates the JSON representation of the object list.
        /// </summary>
        /// <typeparam name="T">The object item type.</typeparam>
        /// <param name="items">The items.</param>
        /// <returns>The JSON representation.</returns>
        /// <exception cref="ArgumentNullException">The argument null exception.</exception>
        public static string ToJson<T>(this List<T> items) where T : DtoBase
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            return JsonConvert.SerializeObject(items);
        }
    }
}
