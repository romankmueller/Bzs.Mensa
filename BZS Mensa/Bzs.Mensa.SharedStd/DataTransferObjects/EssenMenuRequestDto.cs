using System;
using Bzs.Mensa.Shared.Extensions;
using Newtonsoft.Json;

namespace Bzs.Mensa.Shared.DataTransferObjects
{
    /// <summary>
    /// Represents a meal menu request data transfer object.
    /// </summary>
    [JsonObject]
    public sealed class EssenMenuRequestDto : DtoBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EssenMenuRequestDto" /> class.
        /// </summary>
        public EssenMenuRequestDto()
        {
            this.Datum = DateTime.Today;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EssenMenuRequestDto" /> class.
        /// </summary>
        /// <param name="datum">The date.</param>
        public EssenMenuRequestDto(DateTime datum)
        {
            this.Datum = datum.Date;
        }

        /// <summary>
        /// Gets or sets the ISO date.
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
                return this.DatumIso.FromIsoDate();
            }

            set
            {
                this.DatumIso = value.ToIsoDate();
            }
        }
    }
}
