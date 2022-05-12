using System;
using Newtonsoft.Json;

namespace Bzs.Mensa.Shared.DataTransferObjects
{
    /// <summary>
    /// Represents an item data transfer object.
    /// </summary>
    [JsonObject]
    public class ItemDto : DtoBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ItemDto" /> class.
        /// </summary>
        public ItemDto()
        {
            this.Id = Guid.NewGuid();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemDto" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public ItemDto(Guid id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        [JsonProperty(@"id")]
        public Guid Id { get; set; }
    }
}
