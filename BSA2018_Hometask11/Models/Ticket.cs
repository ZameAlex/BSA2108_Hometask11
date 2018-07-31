using System;
using System.Collections.Generic;
using System.Text;

namespace BSA2018_Hometask11.Models
{
    public class Ticket:Entity
    {
        public Guid Number { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"Number:{this.Number} Price:{this.Price}";
        }
    }
}
