using System;
using Bzs.Mensa.Shared.Extensions;
using Newtonsoft.Json;

namespace Bzs.Mensa.Shared.DataTransferObjects
{
    /// <summary>
    /// Represents a meal edit data transfer object.
    /// </summary>
    [JsonObject]
    public sealed class EssenEditDto : ItemDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EssenEditDto" /> class.
        /// </summary>
        public EssenEditDto()
        {
            this.BenutzerId = Guid.Empty;
            this.Datum = DateTime.Today;
            this.Essen = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EssenEditDto" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="benutzerId">The user identifier.</param>
        /// <param name="datum">The date.</param>
        public EssenEditDto(Guid id, Guid benutzerId, DateTime datum, bool essen)
            : base(id)
        {
            this.BenutzerId = benutzerId;
            this.Datum = datum;
            this.Essen = essen;
        }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        [JsonProperty(@"benutzerId")]
        public Guid BenutzerId { get; set; }

        /// <summary>
        /// Gets or sets the ISO date (yyyy-MM-dd).
        /// </summary>
        [JsonProperty(@"datumIso")]
        public string DatumIso { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        public DateTime Datum
        {
            get
            {
                return this.DatumIso?.FromIsoDate() ?? DateTime.Today;
            }

            set
            {
                this.DatumIso = value.ToIsoDate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the user eats.
        /// </summary>
        [JsonProperty(@"essen")]
        public bool Essen { get; set; }
    }
}
