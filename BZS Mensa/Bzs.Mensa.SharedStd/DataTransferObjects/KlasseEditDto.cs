using System;
using Newtonsoft.Json;

namespace Bzs.Mensa.Shared.DataTransferObjects
{
    /// <summary>
    /// Represents a class edit data transfer object.
    /// </summary>
    [JsonObject]
    public sealed class KlasseEditDto : ItemDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KlasseEditDto" /> class.
        /// </summary>
        public KlasseEditDto()
        {
            this.Bezeichnung = string.Empty;
            this.Schicht1 = false;
            this.Schicht2 = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KlasseEditDto" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="bezeichnung">The caption.</param>
        public KlasseEditDto(Guid id, string bezeichnung)
                : this(id, bezeichnung, false, false)
        {
            this.Bezeichnung = bezeichnung;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KlasseEditDto" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="bezeichnung">The caption.</param>
        /// <param name="schicht1">The first Schicht.</param>
        /// <param name="schicht2">The second Schicht.</param>
        public KlasseEditDto(Guid id, string bezeichnung, bool schicht1, bool schicht2)
                : base(id)
        {
            this.Bezeichnung = bezeichnung;
            this.Schicht1 = schicht1;
            this.Schicht2 = schicht2;
        }

        /// <summary>
        /// Gets or sets the caption.
        /// </summary>
        [JsonProperty(@"bezeichnung")]
        public string Bezeichnung { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the Schicht 1 is set.
        /// </summary>
        [JsonProperty(@"schicht1")]
        public bool Schicht1 { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the Schicht 2 is set.
        /// </summary>
        [JsonProperty(@"schicht2")]
        public bool Schicht2 { get; set; }
    }
}
