using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreamKnotifyUnit.Services
{
    public class WeatherForecastService
    {
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public async Task<List<WeatherForecast>> GetForecastAsync(DateTime startDate)
        {
            var rng = new Random();
             IEnumerable<WeatherForecast>forecast =  await Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }).ToList());
            return forecast.ToList();
        }
        
    }
}
