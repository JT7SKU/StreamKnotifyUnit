using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using StreamKnotifyUnit.Library;

namespace ServicesKomponentUnit.WebbingR.KnotifyR
{
    public static class Operations
    {
        [FunctionName("Komponents")]
        public static IActionResult Komponents(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            IEnumerable<KomponentType> KomponentList;
            
            return new OkObjectResult(KomponentList);
        }
    }
}
