using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherService.Model;

namespace WeatherService.Interface
{
    public interface IWeatherService
    {
         Task<OpenWeatherResponse> GetWeatherReportId(string id);
    }
}
