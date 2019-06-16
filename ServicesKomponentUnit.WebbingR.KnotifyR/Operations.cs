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
using System.Linq;

namespace ServicesKomponentUnit.WebbingR.KnotifyR
{
    public  class Operations
    {
        private readonly KorttiKomponenttiDbContext kortticontext;
        private readonly KnotifyDBContext knotifycontext;
        public Operations(KnotifyDBContext knotifyDBContext, KorttiKomponenttiDbContext korttiKomponenttiDbContext)
        {
            kortticontext = korttiKomponenttiDbContext;
            knotifycontext = knotifyDBContext;
        }
        #region OverlayKomponent Functions
        [FunctionName(nameof(OverlayKomponents))]
        public IActionResult OverlayKomponents([HttpTrigger(AuthorizationLevel.Function,"get", Route ="overlaykomponents")] HttpRequest req, ILogger logger)
        {
            logger.LogInformation("Overlay Komponents requested");
            var overlayKomponentArray = knotifycontext.OverlayKomponents.OrderBy(p => p.KomponentType).ToArray();

            return new OkObjectResult(overlayKomponentArray);
        }
        #endregion

        #region KnotifyKard Functions
        [FunctionName(nameof(Komponents))]
        public  IActionResult Komponents(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "kortit")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Komponentti kortit pyydetty!");
            var KomponentList = kortticontext.KorttiPakat.OrderBy(p => p.Nimi).ToArray();       
            return new OkObjectResult(KomponentList);
        }
        #endregion
    }
}
