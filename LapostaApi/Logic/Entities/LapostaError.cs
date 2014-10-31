using Newtonsoft.Json;

namespace Laposta.Entities
{
    public class LapostaError
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("parameter")]
        public string Parameter { get; set; }
    }
}