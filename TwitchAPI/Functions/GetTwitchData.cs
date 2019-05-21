using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using JT7SKU.Lib.Twitch;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace StreamKnotifyUnit.API.Functions
{
    public static class GetTwitchData
    {
        [FunctionName("GetTwitchData")]
        public static async Task<List<string>> RunOrchestrator(
            [OrchestrationTrigger] IDurableOrchestrationContext context)
        {
            var outputs = new List<string>();

            // Replace "hello" with the name of your Durable Activity Function.
            outputs.Add(await context.CallActivityAsync<string>("GetTwitchData_Hello", "TwitchDev"));
            outputs.Add(await context.CallActivityAsync<string>("GetTwitchData_Hello", "VisualStudio"));
            outputs.Add(await context.CallActivityAsync<string>("GetTwitchData_Hello", "Coder"));

            // returns ["Hello Tokyo!", "Hello Seattle!", "Hello London!"]
            return outputs;
        }

        [FunctionName("GetTwitchData_Hello")]
        public static string SayHello([ActivityTrigger] string name, ILogger log)
        {
            log.LogInformation($"Saying hello to {name}.");
            return $"Hello {name}!";
        }
        [FunctionName(nameof(GetSubs))]
        public static async Task GetSubs([EntityTrigger]IDurableEntityContext context, ILogger log)
        {
            log.LogInformation("Getting New subs ..");
            List<Subscriber> subscribers = context.GetState<List<Subscriber>>();
            context.SetState(subscribers);
        }
        [FunctionName("GetTwitchData_HttpStart")]
        public static async Task<HttpResponseMessage> HttpStart(
            [HttpTrigger(AuthorizationLevel.User, "get", Route ="StreamKnotify/{GetTwitchData}")]HttpRequestMessage req,
            [OrchestrationClient]IDurableOrchestrationClient starter,string getTwitchData,
            ILogger log)
        {
            // Function input comes from the request content.
            dynamic eventData = await req.Content.ReadAsAsync<object>();
            string instanceId = await starter.StartNewAsync(getTwitchData, null);

            log.LogInformation($"Started orchestration with ID = '{instanceId}'.");

            return starter.CreateCheckStatusResponse(req, instanceId);
        }
    }
}