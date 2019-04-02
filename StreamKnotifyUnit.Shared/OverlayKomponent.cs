using System;
using System.Collections.Generic;
using System.Text;

namespace StreamKnotifyUnitLibrary
{
    public class OverlayKomponent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public OverlayKomponentType KomponentType { get; set; }
        public Location KomponentLocation { get; set; }
    }
}
