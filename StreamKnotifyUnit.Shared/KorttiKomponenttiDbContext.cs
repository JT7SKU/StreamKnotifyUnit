using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace StreamKnotifyUnit.Library
{
    public class KorttiKomponenttiDbContext : DbContext
    {
        public KorttiKomponenttiDbContext(DbContextOptions<KorttiKomponenttiDbContext> options) : base(options)
        {
        }
        public DbSet<KorttiPakka> KorttiPakat { get; set; }
        public DbSet<KorttiKomponentti> KorttiKomponentit { get; set; }
        public DbSet<KnotifyKard> KnotifyKards { get; set; }
    }
}
