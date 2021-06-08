﻿
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace MetaWeather.TestConsole
{
    class Program
    {
        private static IHost __Hosting;

        public static IHost Hosting => __Hosting ??= CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

        public static IServiceProvider Services => Hosting.Services;
        public static IHostBuilder CreateHostBuilder(string[] args) => Host
            .CreateDefaultBuilder(args)
            .ConfigureServices(ConfigureServices);

        private static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            services.AddHttpClient<MetaWeatherClient>(client => client.BaseAddress = new Uri(host.Configuration["MetaWeather"]));
        }

        static async Task Main(string[] args)
        {
            using var host = Hosting;
            await host.StartAsync();

            var weather = Services.GetRequiredService<MetaWeatherClient>();

            var moscow = await weather.GetLocation("Moscow");

            var info = await weather.GetInfo(moscow[0]);

            var weather_info = await weather.GetWeather(moscow[0].Id, DateTime.Now);

           // var locations = await weather.GetLocation(moscow[0].Coordinates);

            Console.WriteLine("Завершено!");
            Console.ReadLine();
            await host.StopAsync();
        }
    }
}
