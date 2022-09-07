using System;
using Bzs.Mensa.Shared.Extensions;
using Newtonsoft.Json;

namespace Bzs.Mensa.Shared.DataTransferObjects
{
    /// <summary>
    /// Represents a meal week data transfer object.
    /// </summary>
    [JsonObject]
    public class EssenWocheDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EssenWocheDto" /> class.
        /// </summary>
        public EssenWocheDto()
        {
        }

        /// <summary>
        /// Gets or sets the date (ISO).
        /// </summary>
        [JsonProperty(@"datumIso")]
        public string DatumIso { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user is registered.
        /// </summary>
        [JsonProperty(@"angemeldet")]
        public bool Angemeldet { get; set; }

        /// <summary>
        /// Gets or sets the meal description.
        /// </summary>
        [JsonProperty(@"menuBeschreibung")]
        public string MenuBeschreibung { get; set; }

        /// <summary>
        /// Gets or sets the holiday caption.
        /// </summary>
        [JsonProperty(@"feiertagBezeichnung")]
        public string FeiertagBezeichnung { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        [JsonProperty(@"Datum")]
        public DateTime Datum
        {
            get
            {
                return this.DatumIso.FromIsoDate();
            }

            set
            {
                this.DatumIso = value.ToIsoDate();
            }
        }
    }
}
