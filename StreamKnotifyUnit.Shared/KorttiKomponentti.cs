using System;
using System.Collections.Generic;
using System.Text;

namespace StreamKnotifyUnit.Library
{
    public class KorttiKomponentti
    {
        public int Id { get; set; }
        public string Nimi { get; set; }
        public string KuvaUrli { get; set; }
        public KomponentType KomponenttiTyyppi { get; set; }
        public int KardId { get; set; }
        public KnotifyKard KnotifyKard { get; set; }
        public int PakkaId { get; set; }
        public KorttiPakka KorttiPakka { get; set; }
    }
}
