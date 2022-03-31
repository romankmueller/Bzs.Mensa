using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bzs.Mensa.Shared.DataTransferObjects
{
    [JsonObject]
    public  class EssenUebersichtDto
    {
        [JsonProperty(@"essenWoche")]
        public List<EssenWocheDto> EssenWoche { get; set; }
    }
}
