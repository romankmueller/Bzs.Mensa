using Bzs.Mensa.Shared.Extensions;
using Newtonsoft.Json;

namespace Bzs.Mensa.Shared.DataTransferObjects
{
    /// <summary>
    /// Represents a meal response data transfer object.
    /// </summary>
    [JsonObject]
    public class EssenResponseDto : DtoBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EssenResponseDto" /> class.
        /// </summary>
        public EssenResponseDto()
        {
            this.GesperrtDatum = DateTime.Today;
            this.EssenItems = new List<EssenEditDto>();
        }

        /// <summary>
        /// Gets or sets the ISO lock date.
        /// </summary>
        [JsonProperty(@"gesperrtDatumIso")]
        public string GesperrtDatumIso { get; set; }

        /// <summary>
        /// Gets or sets the lock date.
        /// </summary>
        public DateTime GesperrtDatum
        {
            get
            {
                return this.GesperrtDatumIso.FromIsoDate();
            }

            set
            {
                this.GesperrtDatumIso = value.ToIsoDate();
            }
        }

        /// <summary>
        /// Gets or sets the meal items.
        /// </summary>
        [JsonProperty(@"essenItems")]
        public List<EssenEditDto> EssenItems { get; set; }
    }
}
