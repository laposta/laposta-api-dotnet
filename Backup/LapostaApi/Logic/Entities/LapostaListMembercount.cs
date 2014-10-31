using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Laposta.Services;

namespace Laposta.Entities
{
    public class LapostaListMembercount
    {
        [JsonProperty("active")]
        public int active { get; set; }

        [JsonProperty("unsubscribed")]
        public int unsubscribed { get; set; }

        [JsonProperty("cleaned")]
        public int cleaned { get; set; }
    }
}