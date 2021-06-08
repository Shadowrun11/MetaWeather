using System.Text.Json.Serialization;

namespace MetaWeather.Models
{
    public class Location
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
        public (double Latitube, double Longitube) Coordinates { get; set; }

    }
}
