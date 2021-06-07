using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MetaWeather
{
    internal class JsoonCoordinateConverted : JsonConverter<(double Latitube, double Longitube)>
    {
        public override (double Latitube, double Longitube) Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {

            return reader.GetString() is not { Length: >= 3 } str
            || str.Split(',') is not { Length:  2 } components
            || !double.TryParse(components[0], NumberStyles.Any, CultureInfo.InvariantCulture, out var lat)
            || !double.TryParse(components[1], NumberStyles.Any, CultureInfo.InvariantCulture, out var lon)
                ? (double.NaN, double.NaN)
                : (lat, lon);
        }

        public override void Write(Utf8JsonWriter writer, (double Latitube, double Longitube) value, JsonSerializerOptions options)
        {
            writer.WriteStringValue($"{value.Latitube.ToString(CultureInfo.InvariantCulture)},{value.Longitube.ToString(CultureInfo.InvariantCulture)}");
        }
    }
}
