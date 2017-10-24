using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Laposta.Services;
using System.Collections.Generic;

namespace Laposta.Entities
{
    public class LapostaCampaign
    {
        [JsonProperty("account_id")]
        public string Id { get; set; }

        [JsonProperty("campaign_id")]
        public string CampaignId { get; set; }

        [JsonProperty("created")]
        [JsonConverter(typeof(LapostaDateTimeConverter))]
        public DateTime Created { get; set; }

        [JsonProperty("modified")]
        [JsonConverter(typeof(LapostaDateTimeConverter))]
        public DateTime? Modified { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("delivery_requested")]
        [JsonConverter(typeof(LapostaDateTimeConverter))]
        public DateTime? DeliveryRequested { get; set; }

        [JsonProperty("delivery_started")]
        [JsonConverter(typeof(LapostaDateTimeConverter))]
        public DateTime? DeliveryStarted { get; set; }

        [JsonProperty("delivery_ended")]
        [JsonConverter(typeof(LapostaDateTimeConverter))]
        public DateTime? DeliveryEnded { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("from")]
        public FromObject From { get; set; }

        [JsonProperty("reply_to")]
        public string ReplyTo { get; set; }

        [JsonProperty("list_ids")]
        public string[] ListIds { get; set; }

        [JsonProperty("stats")]
        public Dictionary<string, object> Stats { get; set; }

        [JsonProperty("web")]
        public string Web { get; set; }

        [JsonProperty("screenshot")]
        public Dictionary<string, object> Screenshots { get; set; }

        [JsonProperty("plaintext")]
        public string PlainText { get; set; }

        [JsonProperty("html")]
        public string Html { get; set; }

        [JsonProperty("import_url")]
        public string ImportUrl { get; set; }

        [JsonProperty("report")]
        public Dictionary<string,object> Report { get; set; } 

        [JsonProperty("state")]
        public string State { get; set; }

        public LapostaCampaign()
        {
            From = new FromObject();
            ListIds = new string[20];
            Stats = new Dictionary<string, object>();
            Screenshots = new Dictionary<string, object>();
        }
    }

    public class FromObject
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }
}