using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherService.Interface;
using WeatherService.Model;

namespace WeatherService.Controllers
{
    [Route("api/[controller]")]
    public class WeatherController : Controller
    {
        private readonly IWeatherService _service;
        public WeatherController(IWeatherService service)
        {
            _service = service;
        }

        [HttpGet("[action]/{cityId}")]
        public  async Task<OpenWeatherResponse> City(string cityId)
        {
            try
            {
              return  await _service.GetWeatherReportId(cityId);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

    }
}
