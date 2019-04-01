﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StreamKnotifyUnitLibrary
{
    public class Overlayout
    {
        public int OverlayoutId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public DateTime CreatedTime { get; set; }
        public List<OverlistItem> Overlays { get; set; }
    }
}