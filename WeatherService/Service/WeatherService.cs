using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherService.Interface;
using WeatherService.Model;

namespace WeatherService.DependencyInjection
{
    public class WeatherServices : IWeatherService
    {
        private IConfiguration configuration;
        public WeatherServices(IConfiguration iConfig)
        {
            configuration = iConfig;
        }

        public async Task<OpenWeatherResponse>  GetWeatherReportId(string cityId)
        {
            string uri = configuration.GetSection("WeatherSettings").GetSection("Uri").Value;
            string appid = configuration.GetSection("WeatherSettings").GetSection("APPID").Value;
            var rawWeather = new OpenWeatherResponse();
            string time = DateTime.Now.ToString("yyyy-MM-dd");
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(uri);
                    var response = await client.GetAsync($"/data/2.5/weather?id={cityId}&appid={appid}");
                    response.EnsureSuccessStatusCode();
                    var stringResult = await response.Content.ReadAsStringAsync();
                     rawWeather = JsonConvert.DeserializeObject<OpenWeatherResponse>(stringResult);
                    using (StreamWriter writer = System.IO.File.AppendText($"WeatherReport_{rawWeather.Name}_{time}.txt"))
                    {
                        writer.WriteLine(new
                        {
                            Temp = rawWeather.Main.Temp,
                            Summary = string.Join(",", rawWeather.Weather.Select(x => x.Main)),
                            City = rawWeather.Name,
                            Time = DateTime.Now
                        });
                    }
                   
                }

                catch (HttpRequestException httpRequestException)
                {
                    rawWeather.errorMessage = httpRequestException.Message;
                }
                return rawWeather;
            }
        }
    }
}
