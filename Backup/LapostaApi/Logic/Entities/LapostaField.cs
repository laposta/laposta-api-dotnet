using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Laposta.Services;

namespace Laposta.Entities
{
    public class LapostaField
    {
        [JsonProperty("field_id")]
        public string Id { get; set; }

        [JsonProperty("list_id")]
        public string ListId { get; set; }

        [JsonProperty("created")]
        [JsonConverter(typeof(LapostaDateTimeConverter))]
        public DateTime Created { get; set; }

        [JsonProperty("modified")]
        [JsonConverter(typeof(LapostaDateTimeConverter))]
        public DateTime? Modified { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("datatype")]
        public string Datatype { get; set; }

        [JsonProperty("required")]
        public bool? Required { get; set; }

        [JsonProperty("in_form")]
        public bool? InForm { get; set; }

        [JsonProperty("in_list")]
        public bool? InList { get; set; }
    }
}