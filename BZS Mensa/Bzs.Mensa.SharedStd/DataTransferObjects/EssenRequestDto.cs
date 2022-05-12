using System;
using Bzs.Mensa.Shared.Extensions;
using Newtonsoft.Json;

namespace Bzs.Mensa.Shared.DataTransferObjects
{
    /// <summary>
    /// Represents a meal request data transfer object.
    /// </summary>
    [JsonObject]
    public class EssenRequestDto : DtoBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EssenRequestDto" /> class.
        /// </summary>
        public EssenRequestDto()
        {
            this.BenutzerId = Guid.Empty;
            this.VonDatum = DateTime.Today;
            this.BisDatum = DateTime.Today;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EssenRequestDto" /> class.
        /// </summary>
        /// <param name="benutzerId">The user identifier.</param>
        /// <param name="vonDatum">The from date.</param>
        /// <param name="bisDatum">The to date.</param>
        public EssenRequestDto(Guid benutzerId, DateTime vonDatum, DateTime bisDatum)
        {
            this.BenutzerId = benutzerId;
            this.VonDatum = vonDatum;
            this.BisDatum = bisDatum;
        }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        [JsonProperty(@"benutzerId")]
        public Guid BenutzerId { get; set; }

        /// <summary>
        /// Gets or sets the ISO from date.
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
        /// Gets or sets the ISO to date.
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
