using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherService.Controllers;
using WeatherService.Interface;
using WeatherService.Model;

namespace WeatherService.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var mockRepo = new Mock<IWeatherService>();
            var getWeather = GetWeather();
            var controller = new WeatherController(mockRepo.Object);
            mockRepo.Setup(x => x.GetWeatherReportId("2988507")).Returns(Task.FromResult(getWeather[0]));
            var weatherReport = controller.City("2988507");
            Assert.IsNotNull(weatherReport);
            Assert.IsTrue(weatherReport.Result.Name.ToLower() == "Paris".ToLower());
        }

        private List<OpenWeatherResponse> GetWeather()
        {
            var weather = new List<OpenWeatherResponse>();
            var test = new List<WeatherDescription>();
            test.Add(new WeatherDescription() { Main = "Clear", Description = "clear sky" });
            weather.Add(new OpenWeatherResponse()
            {
                Main = new Main() { Temp = "44" },
                Name = "Paris",
                Weather = test.ToArray(),
                id = "2988507"
            });
            weather.Add(new OpenWeatherResponse()
            {
                Main = new Main() { Temp = "44" },
                Name = "NewYork",
                Weather = test.ToArray(),
                id = "2988506"
            });
            return weather;
        }
    }

}
