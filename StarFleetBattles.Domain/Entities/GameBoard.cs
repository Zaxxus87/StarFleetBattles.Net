using StarFleetBattles.Domain.ValueObjects;

namespace StarFleetBattles.Domain.Entities
{
    public class GameBoard
    {
        public int HexSize { get; private set; }
        public int Rows { get; private set; } = 33;
        public int Columns { get; private set; } = 18;
        public List<Ship> Ships { get; private set; }

        public GameBoard(int hexSize)
        {
            HexSize = hexSize;
            Ships = new List<Ship>();
        }

        public void AddShip(Ship ship)
        {
            Ships.Add(ship);
        }

        public void RemoveShip(Guid shipId)
        {
            Ships.RemoveAll(s => s.Id == shipId);
        }

        public Ship? GetShip(Guid shipId)
        {
            return Ships.FirstOrDefault(s => s.Id == shipId);
        }

        public IEnumerable<Position> GetHexagonPoints(double x, double y)
        {
            var points = new List<Position>();
            var size = HexSize / 2.0;
            var height = size * Math.Sqrt(3);

            points.Add(new Position(x, y));
            points.Add(new Position(x + size, y - height));
            points.Add(new Position(x + 3 * size, y - height));
            points.Add(new Position(x + 4 * size, y));
            points.Add(new Position(x + 3 * size, y + height));
            points.Add(new Position(x + size, y + height));

            return points;
        }
    }
}