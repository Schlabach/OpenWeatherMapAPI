using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace OpenWeatherAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            Console.WriteLine($"Please enter your API Key:");
            var apiKey = Console.ReadLine();
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine($"Please enter the city name:");
                var cityName = Console.ReadLine();
                var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={apiKey}&units=imperial";

                var response = client.GetStringAsync(weatherURL).Result;
                var formattedResponse = JObject.Parse(response).GetValue("main").ToString();
                Console.WriteLine(formattedResponse);
                Console.WriteLine();
                Console.WriteLine($"Would you like to choose a different city?");
                var userInput = Console.ReadLine();
                Console.WriteLine();

                if (userInput.ToLower() == "no")
                { 
                    break; 
                }
            }
        }
    }
}
