using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.SignalR;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;

namespace ServicesKomponentUnit.WebbingR.KnotifyR
{
    public static class NegotiateSignalR
    {
        [FunctionName(nameof(Negotiate))]
        public static IActionResult Negotiate(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "{userid}/negotiate")] HttpRequest req,
            [SignalRConnectionInfo(HubName = "KnotifyR", UserId = "{userid }")]SignalRConnectionInfo connectionInfo,
            ILogger log)
        {
            log.LogInformation("Signalling your Knotifications");
            return new OkObjectResult(connectionInfo);
        }
    }
}
