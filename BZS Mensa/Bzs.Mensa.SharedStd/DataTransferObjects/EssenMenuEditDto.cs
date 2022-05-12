using System;
using Bzs.Mensa.Shared.Extensions;
using Newtonsoft.Json;

namespace Bzs.Mensa.Shared.DataTransferObjects
{
    /// <summary>
    /// Represents a meal menu edit data transfer object.
    /// </summary>
    [JsonObject]
    public sealed class EssenMenuEditDto : ItemDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EssenMenuEditDto" /> class.
        /// </summary>
        public EssenMenuEditDto()
        {
            this.Datum = DateTime.Today;
            this.MenuBeschreibung = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EssenMenuEditDto" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="datum">The date.</param>
        /// <param name="menuBeschreibung">The menu description.</param>
        public EssenMenuEditDto(Guid id, DateTime datum, string menuBeschreibung)
            : base(id)
        {
            this.Datum = datum;
            this.MenuBeschreibung = menuBeschreibung;
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

        /// <summary>
        /// Gets or sets the menu description.
        /// </summary>
        [JsonProperty(@"menuBeschreibung")]
        public string MenuBeschreibung { get; set; }
    }
}
