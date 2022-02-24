using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bzs.Mensa.Shared.DataTransferObjects
{
    [JsonObject]
    public class ResultDto : DtoBase
    {
        [JsonProperty("@successful")]
        public bool Succsessful { get; set; }
    }
}
