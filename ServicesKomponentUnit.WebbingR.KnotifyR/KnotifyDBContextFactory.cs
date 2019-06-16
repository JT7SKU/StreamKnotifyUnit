using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using StreamKnotifyUnit.Library;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicesKomponentUnit.WebbingR.KnotifyR
{
    public class KnotifyDBContextFactory : IDesignTimeDbContextFactory<KnotifyDBContext>
    {
        public KnotifyDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<KnotifyDBContext>();
            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("SqlConnectionString"));

            return new KnotifyDBContext(optionsBuilder.Options);
        }
    }
    public class KorttiKomponenttiDbContextFactory : IDesignTimeDbContextFactory<KorttiKomponenttiDbContext>
    {
        public KorttiKomponenttiDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<KorttiKomponenttiDbContext>();
            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("SqlConnectionString"));
            return new KorttiKomponenttiDbContext(optionsBuilder.Options);
        }
    }
}
