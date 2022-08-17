using System.Collections.Generic;
using Newtonsoft.Json;

namespace Bzs.Mensa.Shared.DataTransferObjects
{
    /// <summary>
    /// Represents a meal overview data transfer object.
    /// </summary>
    [JsonObject]
    public class EssenUebersichtDto : DtoBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EssenUebersichtDto" /> class.
        /// </summary>
        public EssenUebersichtDto()
        {
            this.EssenWoche = new List<EssenWocheDto>();
        }

        /// <summary>
        /// Gets or sets the meal week items.
        /// </summary>
        [JsonProperty(@"essenWoche")]
        public List<EssenWocheDto> EssenWoche { get; set; }
    }
}
