using Bzs.Mensa.Shared.Extensions;
using Newtonsoft.Json;

namespace Bzs.Mensa.Shared.DataTransferObjects
{
    /// <summary>
    /// Represents a holiday edit data transfer object.
    /// </summary>
    [JsonObject]
    public sealed class FeiertagEditDto : ItemDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FeiertagEditDto" /> class.
        /// </summary>
        public FeiertagEditDto()
        {
            this.Bezeichnung = string.Empty;
            this.Datum = DateTime.Today;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FeiertagEditDto" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="bezeichnung">The caption.</param>
        /// <param name="datum">The date.</param>
        public FeiertagEditDto(Guid id, string bezeichnung, DateTime datum)
            : base(id)
        {
            this.Bezeichnung = bezeichnung;
            this.Datum = datum;
        }

        /// <summary>
        /// Gets or sets the caption.
        /// </summary>
        [JsonProperty(@"bezeichnung")]
        public string Bezeichnung { get; set; }

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
