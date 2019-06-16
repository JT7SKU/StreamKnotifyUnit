using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace ServicesKomponentUnit.WebbingR.KnotifyR.Entities
{
    public static class KomponentEntity
    {
        [FunctionName("KomponentEntity")]
        public static async Task<List<string>> RunOrchestrator(
            [OrchestrationTrigger] IDurableOrchestrationContext context)
        {
            var outputs = new List<string>();

            // Replace "hello" with the name of your Durable Activity Function.
            outputs.Add(await context.CallActivityAsync<string>("KomponentEntity_Hello", "Tokyo"));
            outputs.Add(await context.CallActivityAsync<string>("KomponentEntity_Hello", "Seattle"));
            outputs.Add(await context.CallActivityAsync<string>("KomponentEntity_Hello", "London"));

            // returns ["Hello Tokyo!", "Hello Seattle!", "Hello London!"]
            return outputs;
        }

        [FunctionName("KomponentEntity_Hello")]
        public static string SayHello([ActivityTrigger] string name, ILogger log)
        {
            log.LogInformation($"Saying hello to {name}.");
            return $"Hello {name}!";
        }

        public Task KomponentEntity([EntityTrigger(EntityName ="KomponentEntity")]IDurableEntityContext entityContext, [SignalR(HubName =("knotifyr")]IAsyncCollector<SignalRMessage> collector)
        {
            return Task.CompletedTask;
        }

        [FunctionName("KomponentEntity_HttpStart")]
        public static async Task<HttpResponseMessage> HttpStart(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")]HttpRequestMessage req,
            [OrchestrationClient]IDurableOrchestrationClient starter,
            ILogger log)
        {
            // Function input comes from the request content.
            string instanceId = await starter.StartNewAsync("KomponentEntity", null);

            log.LogInformation($"Started orchestration with ID = '{instanceId}'.");

            return starter.CreateCheckStatusResponse(req, instanceId);
        }
    }
}