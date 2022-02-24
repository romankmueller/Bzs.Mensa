using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bzs.Mensa.Shared.DataTransferObjects
{
    [JsonObject]
    public class BenutzerPasswortDto : ItemDto
    {
        [JsonProperty("@passwort")]
        public string Passwort { get; set; }
    }
}
