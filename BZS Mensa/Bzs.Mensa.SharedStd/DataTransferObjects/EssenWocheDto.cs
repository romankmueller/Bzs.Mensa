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

    public class EssenWocheDto
    {
        [JsonProperty(@"datumIso")]
        public string DatumIso { get; set; }

        [JsonProperty(@"angemeldet")]
        public bool Angemeldet { get; set; }

        [JsonProperty(@"menuBeschreibung")]
        public string MenuBeschreibung { get; set; }

        [JsonProperty(@"feiertagBezeichnung")]
        public string FeiertagBezeichnung { get; set; }

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
