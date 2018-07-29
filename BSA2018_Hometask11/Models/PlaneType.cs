namespace BSA2018_Hometask11.Models
{
    public class PlaneType:Entity
    {
        public string Model { get; set; }
        public int Places { get; set; }
        public int Speed { get; set; }
        public int FleightLength { get; set; }
        public int MaxMass { get; set; }
        public int MaxHeight { get; set; }
    }
}
