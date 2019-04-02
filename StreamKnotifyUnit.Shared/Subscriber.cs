using System;
using System.Collections.Generic;
using System.Text;

namespace StreamKnotifyUnitLibrary
{
    public class Subscriber
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public TwitchUser User { get; set; }
        public SubscribeType SubscribeType { get; set; }
        public int CumulativeMonths { get; set; }
        public int StreakMonths { get; set; }
    }
}
