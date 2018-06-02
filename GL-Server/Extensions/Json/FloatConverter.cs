namespace GL.Servers.CoC.Extensions.Json
{
    using System;

    using Newtonsoft.Json;

    internal class FloatConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteRawValue(JsonConvert.SerializeObject((int)(float)value));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        
        public override bool CanWrite { get; } = true;
        public override bool CanRead { get; } = false;

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(float) || objectType == typeof(float?);
        }
    }
}
