using Newtonsoft.Json;

namespace Bzs.Mensa.Shared.DataTransferObjects
{
    /// <summary>
    /// Represents a user edit data transfer object.
    /// </summary>
    [JsonObject]
    public sealed class BenutzerEditDto : ItemDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BenutzerEditDto" /> class.
        /// </summary>
        public BenutzerEditDto()
        {
            this.Benutzername = string.Empty;
            this.Email = string.Empty;
            this.Nachname = string.Empty;
            this.Vorname = string.Empty;
            this.KlasseId = Guid.Empty;
            this.Vegetarisch = false;
            this.AllergieItems = new List<BenutzerAllergieEditDto>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BenutzerEditDto" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="benutzerName">The user name.</param>
        /// <param name="email">The email address.</param>
        /// <param name="klasseId">The class identifier.</param>
        /// <param name="vegetarisch">The vegetarian flag.</param>
        public BenutzerEditDto(Guid id, string benutzerName, string email, string nachname, string vorname, Guid klasseId, bool vegetarisch)
            : base(id)
        {
            this.Benutzername = benutzerName ?? string.Empty;
            this.Email = email ?? string.Empty;
            this.Nachname = nachname ?? string.Empty;
            this.Vorname = vorname ?? string.Empty;
            this.KlasseId = klasseId;
            this.Vegetarisch = vegetarisch;
            this.AllergieItems = new List<BenutzerAllergieEditDto>();
        }

        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        [JsonProperty(@"benutzername")]
        public string Benutzername { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        [JsonProperty(@"email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        [JsonProperty(@"nachname")]
        public string Nachname { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        [JsonProperty(@"vorname")]
        public string Vorname { get; set; }

        /// <summary>
        /// Gets or sets the class identifier.
        /// </summary>
        [JsonProperty(@"klasseId")]
        public Guid KlasseId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user is vegetarian.
        /// </summary>
        [JsonProperty(@"vegetarisch")]
        public bool Vegetarisch { get; set; }

        /// <summary>
        /// Gets or sets the allergy items.
        /// </summary>
        [JsonProperty(@"allergieItems")]
        public List<BenutzerAllergieEditDto> AllergieItems { get; set; }
    }
}
