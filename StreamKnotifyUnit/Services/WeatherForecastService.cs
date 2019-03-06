using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace StreamKnotifyUnit.Services
{
    public class WeatherForecastService
    {
        HttpClient http = new HttpClient();
       

        public async Task<List<WeatherForecast>> GetForecastAsync()
        {        
            var forecast = await http.GetJsonAsync<IEnumerable<WeatherForecast>>("");
            return forecast.ToList();
        }
        
    }
}
