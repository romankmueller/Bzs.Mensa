using Newtonsoft.Json;

namespace Bzs.Mensa.Shared.DataTransferObjects
{
    /// <summary>
    /// Represents a user allergy edit data transfer object.
    /// </summary>
    [JsonObject]
    public sealed class BenutzerAllergieEditDto : ItemDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BenutzerAllergieEditDto" /> class.
        /// </summary>
        public BenutzerAllergieEditDto()
        {
            this.AllergieId = Guid.Empty;
            this.AllergieBezeichnung = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BenutzerAllergieEditDto" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="allergieId">The allergy identifier.</param>
        /// <param name="allergieBezeichnung">The allergy caption.</param>
        public BenutzerAllergieEditDto(Guid id, Guid allergieId, string allergieBezeichnung)
        {
            this.AllergieId = allergieId;
            this.AllergieBezeichnung = allergieBezeichnung;
        }

        /// <summary>
        /// Gets or sets the allergy identifier.
        /// </summary>
        [JsonProperty(@"allergieId")]
        public Guid AllergieId { get; set; }

        /// <summary>
        /// Gets or sets the allergy caption.
        /// </summary>
        [JsonProperty(@"allergieBezeichnung")]
        public string AllergieBezeichnung { get; set; }
    }
}
