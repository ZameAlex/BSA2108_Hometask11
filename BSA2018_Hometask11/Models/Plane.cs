using System;

namespace BSA2018_Hometask11.Models
{
    public class Plane:Entity
    {
        public string Name { get; set; }
        public PlaneType Type { get; set; }
        public DateTime Created { get; set; }
        public DateTime Expired { get; set; }
    }
}
