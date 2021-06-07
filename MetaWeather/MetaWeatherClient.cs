﻿using MetaWeather.Models;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace MetaWeather
{
    public class MetaWeatherClient
    {
        private readonly HttpClient _Client;
        public MetaWeatherClient(HttpClient Client) => _Client = Client;

        //private static readonly JsonSerializerOptions __JsonOptions = new()
        //{

        //    Converters =
        //    {
        //        new JsonStringEnumConverter(),
        //        new JsoonCoordinateConverted()
        //    }
        //};

        public async Task<WeatherLocation[]> GetLocation(string Name, CancellationToken Cancel = default)
        {
            return await _Client.GetFromJsonAsync<WeatherLocation[]>($"/api/location/search/?query={Name}", /*__JsonOptions,*/ Cancel)
                .ConfigureAwait(false);
        }

        public async Task<WeatherLocation[]> GetLocation((double Latitube, double Longitude) Location, CancellationToken Cancel = default)
        {
            return await _Client.GetFromJsonAsync<WeatherLocation[]>($"/api/location/search/?lattlong={Location.Latitube.ToString(CultureInfo.InvariantCulture)},{Location.Longitude.ToString(CultureInfo.InvariantCulture)}", /*__JsonOptions,*/ Cancel)
                .ConfigureAwait(false);
        }
    }
}
