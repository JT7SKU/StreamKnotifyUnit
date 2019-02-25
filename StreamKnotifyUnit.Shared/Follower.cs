using System;
using System.Collections.Generic;
using System.Text;

namespace StreamKnotifyUnit.Shared
{
    public class Follower
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public TwitchUser User { get; set; } //User who follow the person
        public TwitchUser Follow { get; set; } // User who get a follower
    }
}
