using System;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.IO;

namespace WeatherApp
{
    public class Program
    {
        public static void Main()
        {
            string APIKey = "e51c3d9d4adb6da9054ac55ac8328750";

            Console.WriteLine("Please enter your zipcode");
            var zipCode = Console.ReadLine();

            var apiCall = $"https://api.openweathermap.org/data/2.5/weather?zip={zipCode}&appid={APIKey}&units=imperial";

            Console.WriteLine();

            Console.WriteLine($"It is currently {WeatherMap.GetTemp(apiCall)} degrees Fahrenheit.");
        }
    }

    public class WeatherMap
    {
        public static string GetTemp(string apiCall)
        {
            var client = new HttpClient();

            var response = client.GetStringAsync(apiCall).Result;

            var temp = JObject.Parse(response)["main"]["temp"].ToString();

            return temp;
        }
    }
}