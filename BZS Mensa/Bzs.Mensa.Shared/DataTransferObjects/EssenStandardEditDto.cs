using Newtonsoft.Json;

namespace Bzs.Mensa.Shared.DataTransferObjects
{
    /// <summary>
    /// Represents a meal default edit data transfer object.
    /// </summary>
    [JsonObject]
    public sealed class EssenStandardEditDto : ItemDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EssenStandardEditDto" /> class.
        /// </summary>
        public EssenStandardEditDto()
        {
            this.BenutzerId = Guid.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EssenStandardEditDto" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="benutzerId">The user identifier.</param>
        /// <param name="montag">The monday.</param>
        /// <param name="dienstag">The tuesday.</param>
        /// <param name="mittwoch">The wednesday.</param>
        /// <param name="donnerstag">The thursday.</param>
        /// <param name="freitag">The friday.</param>
        /// <param name="samstag">The saturday.</param>
        /// <param name="sonntag">The sunday.</param>
        public EssenStandardEditDto(Guid id, Guid benutzerId, bool montag, bool dienstag, bool mittwoch, bool donnerstag, bool freitag, bool samstag, bool sonntag)
            : base(id)
        {
            this.BenutzerId = benutzerId;
            this.Montag = montag;
            this.Dienstag = dienstag;
            this.Mittwoch = mittwoch;
            this.Donnerstag = donnerstag;
            this.Freitag = freitag;
            this.Samstag = samstag;
            this.Sonntag = sonntag;
        }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        [JsonProperty(@"benutzerId")]
        public Guid BenutzerId { get; set; }

        /// <summary>
        /// Gets or sets the monday.
        /// </summary>
        [JsonProperty(@"montag")]
        public bool Montag { get; set; }

        /// <summary>
        /// Gets or sets the thursday.
        /// </summary>
        [JsonProperty(@"dienstag")]
        public bool Dienstag { get; set; }

        /// <summary>
        /// Gets or sets the wednesday.
        /// </summary>
        [JsonProperty(@"mittwoch")]
        public bool Mittwoch { get; set; }

        /// <summary>
        /// Gets or sets the thursday.
        /// </summary>
        [JsonProperty(@"donnerstag")]
        public bool Donnerstag { get; set; }

        /// <summary>
        /// Gets or sets the friday.
        /// </summary>
        [JsonProperty(@"freitag")]
        public bool Freitag { get; set; }

        /// <summary>
        /// Gets or sets the saturday.
        /// </summary>
        [JsonProperty(@"samstag")]
        public bool Samstag { get; set; }

        /// <summary>
        /// Gets or sets the sunday.
        /// </summary>
        [JsonProperty(@"sonntag")]
        public bool Sonntag { get; set; }
    }
}
