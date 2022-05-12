using Bzs.Mensa.Shared.Extensions;
using Newtonsoft.Json;
using System;

namespace Bzs.Mensa.Shared.DataTransferObjects
{
    /// <summary>
    /// Represents a vacation edit data transfer object.
    /// </summary>
    [JsonObject]
    public sealed class FerienEditDto : ItemDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FerienEditDto" /> class.
        /// </summary>
        public FerienEditDto()
        {
            this.Bezeichnung = string.Empty;
            this.VonDatum = DateTime.Today;
            this.BisDatum = DateTime.Today;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FerienEditDto" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="bezeichnung">The caption.</param>
        /// <param name="vonDatum">The from date.</param>
        /// <param name="bisDatum">The to date.</param>
        public FerienEditDto(Guid id, string bezeichnung, DateTime vonDatum, DateTime bisDatum)
            : base(id)
        {
            this.Bezeichnung = bezeichnung;
            this.VonDatum = vonDatum;
            this.BisDatum = bisDatum;
        }

        /// <summary>
        /// Gets or sets the caption.
        /// </summary>
        [JsonProperty(@"bezeichnung")]
        public string Bezeichnung { get; set; }

        /// <summary>
        /// Gets or sets the from date (ISO).
        /// </summary>
        [JsonProperty(@"vonDatumIso")]
        public string VonDatumIso { get; set; }

        /// <summary>
        /// Gets or sets the from date.
        /// </summary>
        public DateTime VonDatum
        {
            get
            {
                return this.VonDatumIso.FromIsoDate();
            }

            set
            {
                this.VonDatumIso = value.ToIsoDate();
            }
        }

        /// <summary>
        /// Gets or sets the to date (ISO).
        /// </summary>
        [JsonProperty(@"bisDatumIso")]
        public string BisDatumIso { get; set; }

        /// <summary>
        /// Gets or sets the to date.
        /// </summary>
        public DateTime BisDatum
        {
            get
            {
                return this.BisDatumIso.FromIsoDate();
            }

            set
            {
                this.BisDatumIso = value.ToIsoDate();
            }
        }
    }
}
