using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.VisualBasic;

namespace WeatherAppAppWpf
{
    class WeatherManager
    {
        private readonly string _apiKey;

        public WeatherManager(string apiKey)
        {
            _apiKey = apiKey;
        }

        public WeatherData GetWeather(string city)
        {

            var client = new RestClient("https://api.openweathermap.org/data/2.5/");

            var request = new RestRequest("weather", Method.Get);


            request.AddParameter("q", city);             // Город
            request.AddParameter("appid", _apiKey);     // API-ключ
            request.AddParameter("units", "metric");    // Градусы Цельсия
            request.AddParameter("lang", "ru");         // Язык ответа


            var response = client.Execute(request);


            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<WeatherData>(response.Content);
            }

            throw new Exception($"Ошибка: {response.StatusCode} - {response.ErrorMessage}");
        }
    }
    public class WeatherData
    {
        public MainData Main { get; set; }
        public Weather[] Weather { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Main.Temp} - {Main.Humidity}";
        }
    }

    public class MainData
    {
        public float Temp { get; set; }
        public int Humidity { get; set; }
    }

    public class Weather
    {
        public string Main { get; set; }
        public string Description { get; set; }
    }
}
