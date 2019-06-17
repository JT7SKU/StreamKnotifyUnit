using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using StreamKnotifyUnit.Library;

namespace ServicesKomponentUnit.WebbingR.KnotifyR.Entities
{
    public  class KomponentEntity
    {
        private readonly KorttiKomponenttiDbContext korttiContext;
        public KomponentEntity(KorttiKomponenttiDbContext context)
        {
            korttiContext = context;
        }

        [FunctionName(nameof(KorttiLaskuri))]
        public async Task KorttiLaskuri([EntityTrigger(EntityName ="KomponentEntity")]IDurableEntityContext entityContext, 
            [SignalR(HubName ="knotifyr")]IAsyncCollector<SignalRMessage> collector)
        {
            var pakka = entityContext.GetState<KorttiPakka>(); 
            var kortti = entityContext.GetInput<KorttiKomponentti>();
            switch (entityContext.OperationName)
            {
                case "new":
                    pakka.Kortit.Add(kortti);
                    await collector.AddAsync(UpdateKorttiPakka(pakka, kortti));
                    break;
                case "remove":
                    pakka.Kortit.Remove(kortti);
                    break;
                case "clear":
                    break;
            }

            entityContext.SetState(pakka);
        }

        private SignalRMessage UpdateKorttiPakka(KorttiPakka pakka, KorttiKomponentti kortti)
        {
            return new SignalRMessage
            {
                Target = "korttipakkaupdated",
                Arguments = new object[] { pakka, kortti }
            };
        }

        
    }
}