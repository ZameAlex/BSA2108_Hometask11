namespace BSA2018_Hometask11.Models
{
    public class Ticket:Entity
    {
        public Flight Flight { get; set; }
        public decimal Price { get; set; }
    }
}
