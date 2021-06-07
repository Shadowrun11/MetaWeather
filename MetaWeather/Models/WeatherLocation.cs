using System.Text.Json.Serialization;

namespace MetaWeather
{
    public class WeatherLocation
    {
        [JsonPropertyName("woeid")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("location_type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public LocationType Type { get; set; }

        [JsonPropertyName("latt_long")]
        [JsonConverter(typeof(JsoonCoordinateConverted))]
        public (double Latitube, double Longitube) Location { get; set; }

        [JsonPropertyName("distance")]
        public int Distance { get; set; }
    }
}
