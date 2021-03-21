namespace DublinBikes.Models
{
    public class DublinBike
    {
        public int Number { get; set; }
        public string ContractName { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public bool Banking { get; set; }
        public int Available_bikes { get; set; }
        public int Available_stands { get; set; }
        public int Capacity { get; set; }
        public string Status { get; set; }
    }
}