using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MetaWeather.Models
{
    public class WeatherInfo
    {
        [JsonPropertyName("id")]
        public long id { get; set; }

        [JsonPropertyName("weather_state_name")]
        public string weather_state_name { get; set; }

        [JsonPropertyName("weather_state_abbr")]
        public string weather_state_abbr { get; set; }

        [JsonPropertyName("wind_direction_compass")]
        public string wind_direction_compass { get; set; }

        [JsonPropertyName("created")]
        public DateTime Created { get; set; }

        [JsonPropertyName("applicable_date")]
        public DateTime ApplicableDate { get; set; }

        [JsonPropertyName("min_temp")]
        public double? TemperatureMin { get; set; }

        [JsonPropertyName("max_temp")]
        public double? TemperatureMax { get; set; }

        [JsonPropertyName("the_temp")]
        public double? Temperature { get; set; }

        [JsonPropertyName("wind_speed")]
        public double WindSpeedMph { get; set; }

        [JsonIgnore]
        public double WindSpeedKmh => WindSpeedMph * 1.61;

        [JsonIgnore]
        public double WindSpeed => WindSpeedMph * 0.4469;

        [JsonPropertyName("wind_direction")]
        public double WindDirection { get; set; }

        [JsonPropertyName("air_pressure")]
        public double? AirPressure { get; set; }

        [JsonPropertyName("humidity")]
        public int? Humidity { get; set; }

        [JsonPropertyName("visibility")]
        public double? Visibility { get; set; }

        [JsonPropertyName("predictability")]
        public int Predictability { get; set; }
    }
}
