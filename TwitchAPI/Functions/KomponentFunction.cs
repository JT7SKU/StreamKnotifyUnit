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

namespace StreamKnotifyUnit.API
{
    public static class KomponentFunction
    {
        [FunctionName(nameof(KomponentFunc))]
        public static async Task<IActionResult> KomponentFunc(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "komponents")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Getting Komponents have being requested.");
              
            string name = req.Query["name"];
            
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;
           
            return name != null
                ? (ActionResult)new OkObjectResult($"Hello, {name}")
                : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }
    }
}

