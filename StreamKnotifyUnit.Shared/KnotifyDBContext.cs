using Microsoft.EntityFrameworkCore;
using StreamKnotifyUnitLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace StreamKnotifyUnit.Library
{
    public class KnotifyDBContext : DbContext 
    {
        public KnotifyDBContext(DbContextOptions<KnotifyDBContext> options) : base(options)
        {
        }
        public DbSet<OverlayKomponent> OverlayKomponents { get; set; }
        public DbSet<Overlayout> Overlayouts { get; set; }
        public DbSet<OverlistItem> OverlistItems { get; set; }
    }
}
