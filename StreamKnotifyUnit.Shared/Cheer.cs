﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StreamKnotifyUnit.Shared
{
    public class Cheer
    {
        public int Id { get; set; }
        public TwitchUser User { get; set; }
        public Double Amount { get; set; }
        public Message Message { get; set; }
    }
}