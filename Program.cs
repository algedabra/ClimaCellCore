using ClimaCellCore.Services;
using System;
using System.IO;
using System.Linq;

namespace ClimaCellCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Forecast();
            Console.ReadKey();
        }
        public static async void Forecast()
        {
            var apiKey = File.ReadLines(@"d:\temp\climacell\apikey.txt").First();
            var climaCell = new ClimaCellService(apiKey);

            var forecast = await climaCell.GetForecast(52.99042, 8.81614);

            if (forecast?.IsSuccessStatus == true)
            {
                Console.WriteLine("Latitude: " + forecast.Response.Lat);
                Console.WriteLine("Longitude: " + forecast.Response.Lon);
                Console.WriteLine("Precipitation: " + forecast.Response.Precipitation.Value);
                Console.WriteLine("Precipitation unit: " + forecast.Response.Precipitation.Units);
            }
            else
            {
                Console.WriteLine("No current weather data");
            }
            Console.WriteLine(forecast.AttributionLine);
            Console.WriteLine(forecast.DataSource);
        }
    }
}
