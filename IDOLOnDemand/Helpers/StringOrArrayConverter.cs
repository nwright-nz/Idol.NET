using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace IDOLOnDemand.Helpers
{
   public class StringOrArrayConverter : JsonConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.String:
                case JsonToken.Null:
                    return reader.Value;
                case JsonToken.StartArray:
                    reader.Read();
                    if (reader.TokenType != JsonToken.EndArray)
                        throw new JsonReaderException("Empty array expected.");
                    return "";
            }
            throw new JsonReaderException("Expected string or null or empty array.");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }
    }
}
