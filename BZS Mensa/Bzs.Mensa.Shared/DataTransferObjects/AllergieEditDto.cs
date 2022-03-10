using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bzs.Mensa.Shared.DataTransferObjects
{
    [JsonObject]
    public class AllergieEditDto
    {
        [JsonProperty(@"id")]
        public Guid Id { get; set; }

        [JsonProperty(@"bezeichnung")]
        public string Bezeichnung { get; set; }
    }
}
