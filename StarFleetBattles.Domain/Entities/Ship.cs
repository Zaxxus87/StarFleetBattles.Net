using StarFleetBattles.Domain.ValueObjects;

namespace StarFleetBattles.Domain.Entities
{
    public class Ship
    {
        public Guid Id { get; private set; }
        public Position Position { get; private set; }
        public int Facing { get; private set; } // 0-5 for 6 directions
        public ShipType ShipType { get; private set; }
        public string Name { get; private set; }

        public Ship(Position position, ShipType shipType, string name, int facing = 0)
        {
            Id = Guid.NewGuid();
            Position = position;
            ShipType = shipType;
            Name = name;
            Facing = facing;
        }

        public void MoveTo(Position newPosition)
        {
            Position = newPosition;
        }

        public void TurnRight()
        {
            Facing = (Facing + 1) % 6;
        }

        public void TurnLeft()
        {
            Facing = Facing == 0 ? 5 : Facing - 1;
        }

        public void SetFacing(int facing)
        {
            if (facing < 0 || facing > 5)
                throw new ArgumentOutOfRangeException(nameof(facing), "Facing must be between 0 and 5");

            Facing = facing;
        }
    }
}