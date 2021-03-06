using MetaWeather.Models;
using System;
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

        public async Task<LocationInfo> GetInfo(int WoeId, CancellationToken Cancel = default)
        {
            return await _Client.GetFromJsonAsync<LocationInfo>($"/api/location/{WoeId}", Cancel).ConfigureAwait(false);
        }

        public Task<LocationInfo> GetInfo(WeatherLocation Location, CancellationToken Cancel = default) =>
            GetInfo(Location.Id, Cancel);

        public async Task<WeatherInfo[]> GetWeather(int WoeId, DateTime Time, CancellationToken Cancel = default)
        {
            return await _Client
                .GetFromJsonAsync<WeatherInfo[]>($"/api/location/{WoeId}/{Time:yyyy}/{Time:MM}/{Time:dd}/", Cancel)
                .ConfigureAwait(false);
        }

        public Task<WeatherInfo[]> GetWeather(LocationInfo Location, DateTime Time, CancellationToken Cancel = default) =>
            GetWeather(Location.Id, Time, Cancel);

        public Task<WeatherInfo[]> GetWeather(WeatherLocation Location, DateTime Time, CancellationToken Cancel = default) =>
            GetWeather(Location.Id, Time, Cancel);

    }
}
