using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using StreamKnotifyUnit.API.Utils;

namespace StreamKnotifyUnit.API.Functions
{
    public static class GetKomponents
    {
        [FunctionName("GetKomponents")]
        public static async Task<List<string>> RunOrchestrator(
            [OrchestrationTrigger] IDurableOrchestrationContext context)
        {
            var outputs = new List<string>();

            // Replace "hello" with the name of your Durable Activity Function.
            outputs.Add(await context.CallActivityAsync<string>("GreetKomponent", "Rating"));
            outputs.Add(await context.CallActivityAsync<string>("GreetKomponent", "Twitch"));
            outputs.Add(await context.CallActivityAsync<string>("GreetKomponent", "Stream"));

            // returns ["Hello Tokyo!", "Hello Seattle!", "Hello London!"]
            return outputs;
        }

        [FunctionName(nameof(GreetKomponent))]
        public static string GreetKomponent([ActivityTrigger] string name, ILogger log)
        {
            log.LogInformation($"Saying hello to {name}.");
            return $"Hello {name}!";
        }
        [FunctionName("EditableKomponents")]
        public static async Task EditableKomponents([EntityTrigger]IDurableEntityContext context, ILogger logger)
        {
            int currentValue = context.GetState<int>();
            int operant = context.GetInput<int>();
            switch (context.OperationName)
            {
                case "add":
                    currentValue += operant;
                    break;
                case "remove":
                    currentValue -= operant;
                    break;
                case "reset":
                    await UtilMethods.SendKnotifyAsync();
                    currentValue = 0;
                    break;
            }
            context.SetState(currentValue);
        }

        //private static Task SendKnotifyAsync()
        //{
        //    throw new NotImplementedException();
        //}

        [FunctionName("GetKomponents_HttpStart")]
        public static async Task<HttpResponseMessage> HttpStart(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")]HttpRequestMessage req,
            [OrchestrationClient]IDurableOrchestrationClient starter,
            ILogger log)
        {
            // Function input comes from the request content.
            string instanceId = await starter.StartNewAsync("GetKomponents", null);

            log.LogInformation($"Started orchestration with ID = '{instanceId}'.");

            return starter.CreateCheckStatusResponse(req, instanceId);
        }
    }
}