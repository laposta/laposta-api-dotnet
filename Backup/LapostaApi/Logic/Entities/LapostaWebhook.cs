using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Laposta.Services;

namespace Laposta.Entities
{
    public class LapostaWebhook
    {
        [JsonProperty("webhook_id")]
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

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("blocked")]
        public bool? Blocked { get; set; }
    }
}