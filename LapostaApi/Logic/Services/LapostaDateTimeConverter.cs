using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace Laposta.Services
{
    public class LapostaDateTimeConverter : DateTimeConverterBase
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            System.Diagnostics.Debug.WriteLine(value);

            writer.WriteRawValue(@"""\/Date(" + ConvertDateTimeToEpoch((DateTime)value).ToString() + @")\/""");
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null) return null;

            if (reader.TokenType == JsonToken.Integer)
                return ConvertEpochToDateTime((long)reader.Value);

            return DateTime.Parse(reader.Value.ToString());
        }

        private DateTime ConvertEpochToDateTime(long seconds)
        {
            return new DateTime(1970, 1, 1).AddSeconds(seconds);
        }

        private long ConvertDateTimeToEpoch(DateTime datetime)
        {
            var epochStart = new DateTime(1970, 1, 1);
            if (datetime < epochStart) return 0;

            return Convert.ToInt64(datetime.Subtract(epochStart).TotalSeconds);
        }
    }
}