using System.Collections.Generic;

namespace BSA2018_Hometask11.Models
{
    public class Crew:Entity
    {
        public Pilot Pilot { get; set; }
        public List<Stewardess> Stewardesses { get; set; }
    }
}
