using Newtonsoft.Json;

namespace Bzs.Mensa.Shared.DataTransferObjects
{
    /// <summary>
    /// Represents an allergy edit data transfer object.
    /// </summary>
    [JsonObject]
    public sealed class AllergieEditDto : ItemDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AllergieEditDto" /> class.
        /// </summary>
        public AllergieEditDto()
        {
            this.Bezeichnung = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AllergieEditDto" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="bezeichnung">The caption.</param>
        public AllergieEditDto(Guid id, string bezeichnung)
            : base(id)
        {
            this.Bezeichnung = bezeichnung;
        }

        /// <summary>
        /// Gets or sets the caption.
        /// </summary>
        [JsonProperty(@"bezeichnung")]
        public string Bezeichnung { get; set; }
    }
}
