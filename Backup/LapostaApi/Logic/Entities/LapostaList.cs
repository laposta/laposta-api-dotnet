using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Laposta.Services;

namespace Laposta.Entities
{
    public class LapostaList
    {
        [JsonProperty("list_id")]
        public string Id { get; set; }

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

        [JsonProperty("remarks")]
        public string Remarks { get; set; }

        [JsonProperty("subscribe_notification_email")]
        public string SubscribeNotificationEmail { get; set; }

        [JsonProperty("unsubscribe_notification_email")]
        public string UnsubscribeNotificationEmail { get; set; }

        [JsonProperty("members")]
        public LapostaListMembercount Membercount { get; set; }
    }
}