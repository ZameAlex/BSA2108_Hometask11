using System;

namespace BSA2018_Hometask11.Models
{
    public class Stewardess:Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public override string ToString()
        {
            return $"Name: {FirstName}, Last name: {LastName}";
        }
    }
}
