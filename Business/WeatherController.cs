using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;

namespace Business
{
    public class WeatherController : GetWeatherForecast
    {
        public WeatherController(string apiKey, string url) : base(apiKey, url)
        {
        }   
    }
}
