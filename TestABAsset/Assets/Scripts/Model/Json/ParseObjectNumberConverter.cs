using Newtonsoft.Json;
using System;
public class ParseObjectNumberConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(object);
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        serializer.Serialize(writer, value);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        object value = null;
        if (reader.TokenType == JsonToken.Integer)
            value = Convert.ToInt32(reader.Value);      // convert to Int32 instead of Int64
        else if (reader.TokenType == JsonToken.Float)
            value = Convert.ToSingle(reader.Value);      // convert to Float instead of Double
        else
            value = serializer.Deserialize(reader);     // let the serializer handle all other cases
        return value;
    }
}