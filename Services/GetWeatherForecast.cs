using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class GetWeatherForecast
    {
        private string url;
        private string apiKey;

        public GetWeatherForecast(string apiKey, string url)
        {
            ApiKey = apiKey;
            URL = url;
        }

        public string ApiKey
        {
            get { return apiKey; }
            set { apiKey = value; }
        }

        public string URL
        {
            get { return url; }
            set { url = value; }
        }

        
    }
}
