using System;

namespace BSA2018_Hometask11.Models
{
    public class Departure:Entity
    {
        public Flight Flight { get; set; }
        public DateTime Date { get; set; }
        public Crew Crew { get; set; }
        public Plane Plane { get; set; }
    }
}
