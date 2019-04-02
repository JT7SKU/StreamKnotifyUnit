using System;
using System.Collections.Generic;
using System.Text;

namespace StreamKnotifyUnitLibrary
{
    public class Message
    {
        public TwitchUser User { get; set; }
        public string Context { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
    }
}
