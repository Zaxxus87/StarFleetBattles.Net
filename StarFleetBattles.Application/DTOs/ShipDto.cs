namespace StarFleetBattles.Application.DTOs
{
    public class ShipDto
    {
        public Guid Id { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public int Facing { get; set; }
        public string ShipType { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
    }
}