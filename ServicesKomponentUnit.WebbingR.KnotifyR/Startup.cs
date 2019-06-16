using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StreamKnotifyUnit.Library;
using System;
using System.Collections.Generic;
using System.Text;
[assembly: FunctionsStartup(typeof(ServicesKomponentUnit.WebbingR.KnotifyR.Startup))]
namespace ServicesKomponentUnit.WebbingR.KnotifyR
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            string SqlConnection = Environment.GetEnvironmentVariable("SqlConnectionString");
            builder.Services.AddDbContext<KnotifyDBContext>(
                options => options.UseSqlServer(SqlConnection));
            builder.Services.AddDbContext<KorttiKomponenttiDbContext>(
                options => options.UseSqlServer(SqlConnection));
        }
    }
}
