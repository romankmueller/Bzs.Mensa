using Bzs.Mensa.Shared.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bzs.Mensa.Shared.DataTransferObjects
{
    [JsonObject]
    public class UebersichtTagReportItemDto
    {
        [JsonProperty(@"bezeichnung")]
        public string Bezeichnung { get; set; }

        [JsonProperty(@"schicht1")]
        public int Schicht1 { get; set; }

        [JsonProperty(@"schicht2")]
        public int Schicht2 { get; set; }

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

        [JsonProperty(@"sortierungsNummer")]
        public int SortierungsNummer { get; set; }
    }
}
