using System;
using System.Collections.Generic;
using System.Text;
using AdaptiveCards;
using AdaptiveCards.Rendering;
using AdaptiveCards.Rendering.Html;
namespace StreamKnotifyUnit.Library
{
    public class KnotifyKard : AdaptiveElement
    {
        public override string Type { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int KardId { get; set; }
        public string Nimi { get; set; }
        public string KartSijaintiUrl { get; set; }

        public int KorttiKomponenttiId { get; set; }
        public KorttiKomponentti KorttiKomponentti { get; set; }
    }
}
