namespace StarFleetBattles.Application.DTOs
{
    public class GameBoardDto
    {
        public int HexSize { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public List<ShipDto> Ships { get; set; } = new();
        public List<HexagonDto> Hexagons { get; set; } = new();
    }
}