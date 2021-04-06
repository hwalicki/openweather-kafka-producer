using OpenWeather.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace OpenWeather
{
    public class OpenWeatherApiProxy
    {
        private string apiKey = "apiKey"; // Insert your api key
        private static readonly HttpClient client = new HttpClient();


        public async Task<string> GetCurrentWeather(Location location)
        {
            try
            {
                var currentWeatherUrl = $"http://api.openweathermap.org/data/2.5/onecall?lat={location.Lat}&lon={location.Lon}&units=imperial&exclude=minutely,hourly&appid={apiKey}";
                var weather = await client.GetStringAsync(currentWeatherUrl);

                return weather;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> GetAirPollution(Location location)
        {
            try
            {
                var airPollutionUrl = $"http://api.openweathermap.org/data/2.5/air_pollution?lat={location.Lat}&lon={location.Lon}&appid={apiKey}";
                var pollution = await client.GetStringAsync(airPollutionUrl);

                return pollution;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
