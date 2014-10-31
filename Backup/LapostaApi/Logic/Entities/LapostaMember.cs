using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Laposta.Services;

namespace Laposta.Entities
{
    public class LapostaMember
    {
        [JsonProperty("member_id")]
        public string Id { get; set; }

        [JsonProperty("list_id")]
        public string ListId { get; set; }

        [JsonProperty("signup_date")]
        [JsonConverter(typeof(LapostaDateTimeConverter))]
        public DateTime Signup { get; set; }

        [JsonProperty("modified")]
        [JsonConverter(typeof(LapostaDateTimeConverter))]
        public DateTime? Modified { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("ip")]
        public string IP { get; set; }

        [JsonProperty("source_url")]
        public string SourceUrl { get; set; }

        [JsonProperty("custom_fields")]
      //  [JsonDictionary(typeof(Dictionary<string, string>))]
        public Dictionary<string, string> CustomFields { get; set; }
    }
}