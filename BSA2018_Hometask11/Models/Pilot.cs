using System;

namespace BSA2018_Hometask11.Models
{
    public class Pilot:Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public int Experience { get; set; }
    }
}
