using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;

namespace TwitchAPI
{
    public static class PaypalMe
    {
        [FunctionName("PaypalMe")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "tip/{account}/{amount}")] HttpRequest req, string account, int amount,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            var url = $"https://paypal.me/{account}/{amount}";
            
            string name = req.Query["name"];
            var res = new HttpResponseMessage();
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;
            HttpClient client = new HttpClient();
            await client.PostAsync(url, new StringContent(""));
            return url != null
                ? (ActionResult)new OkObjectResult($"Hello, {url}")
                : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }
    }
}

