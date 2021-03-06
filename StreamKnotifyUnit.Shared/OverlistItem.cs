﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StreamKnotifyUnitLibrary
{
    public class OverlistItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string LinkTo { get; set; }
        public DateTime CreatedTime { get; set; }
        public List<OverlayKomponent> Komponents { get; set; }
    }
}
