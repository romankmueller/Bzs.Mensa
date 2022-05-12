using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bzs.Mensa.Shared.DataTransferObjects
{
    [JsonObject]
    public class UebersichtTagReportDto
    {
        public UebersichtTagReportDto()
        {
            this.Items = new List<UebersichtTagReportItemDto>();
        }

        [JsonProperty(@"items")]
        public List<UebersichtTagReportItemDto> Items { get; set; }
    }
}
