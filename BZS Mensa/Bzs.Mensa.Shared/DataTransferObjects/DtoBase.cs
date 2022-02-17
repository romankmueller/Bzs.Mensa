using Newtonsoft.Json;
using System.Diagnostics;

namespace Bzs.Mensa.Shared.DataTransferObjects
{
    /// <summary>
    /// Represents a base data transfer object.
    /// </summary>
    [JsonObject]
    public class DtoBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DtoBase" /> class.
        /// </summary>
        protected DtoBase()
        {
        }

        /// <summary>
        /// Creates the object out of the JSON representation.
        /// </summary>
        /// <typeparam name="T">The expected type.</typeparam>
        /// <param name="json">The JSON representation.</param>
        /// <returns>The object.</returns>
        /// <exception cref="ArgumentNullException">The argument nul exception.</exception>
        public static T Create<T>(string json) where T : DtoBase
        {
            if (json == null)
            {
                throw new ArgumentNullException(nameof(json));
            }

            try
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (JsonException e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        /// <summary>
        /// Creates the object list out of the JSON representation.
        /// </summary>
        /// <typeparam name="T">The expected list item type.</typeparam>
        /// <param name="json">The JSON representation.</param>
        /// <returns>The object list.</returns>
        /// <exception cref="ArgumentNullException">The argument null exception.</exception>
        public static List<T> CreateList<T>(string json) where T : DtoBase
        {
            if (json == null)
            {
                throw new ArgumentNullException(nameof(json));
            }

            try
            {
                return JsonConvert.DeserializeObject<List<T>>(json);
            }
            catch (JsonException e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        /// <summary>
        /// Returns the JSON representation of the object.
        /// </summary>
        /// <returns>The JSON representation.</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
