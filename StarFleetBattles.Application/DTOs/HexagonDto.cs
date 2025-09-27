namespace StarFleetBattles.Application.DTOs
{
    public class HexagonDto
    {
        public double X { get; set; }
        public double Y { get; set; }
        public List<PointDto> Points { get; set; } = new();
    }

    public class PointDto
    {
        public double X { get; set; }
        public double Y { get; set; }
    }
}