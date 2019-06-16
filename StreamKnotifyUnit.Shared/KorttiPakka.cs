using System;
using System.Collections.Generic;
using System.Text;

namespace StreamKnotifyUnit.Library
{
    public class KorttiPakka
    {
        public int PakkaId { get; set; }
        public string Nimi { get; set; }
        public string KuvaUrl { get; set; }

        public ICollection<KorttiKomponentti> Kortit { get; set; }
    }
}
