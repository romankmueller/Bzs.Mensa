using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bzs.Mensa.Shared.DataTransferObjects
{
    [JsonObject]
    public class BenutzerDto : ItemDto
    {
        [JsonProperty(@"benutzername")]
        public string Benutzername { get; set; }

        [JsonProperty(@"email")]
        public string Email { get; set; }

        [JsonProperty(@"klasseId")]
        public Guid KlasseId { get; set; }

        [JsonProperty(@"vegetarisch")]
        public bool Vegetarisch { get; set; }

    }
}
