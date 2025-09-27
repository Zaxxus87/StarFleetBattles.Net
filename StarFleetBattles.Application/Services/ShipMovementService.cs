using StarFleetBattles.Domain.Entities;
using StarFleetBattles.Domain.Services;

namespace StarFleetBattles.Application.Services
{
    public class ShipMovementService : IShipMovementService
    {
        public void MoveShipNormal(Ship ship, int hexSize)
        {
            var newPosition = ship.Position.MoveNormal(ship.Facing, hexSize);
            ship.MoveTo(newPosition);
        }

        public void SideslipShipRight(Ship ship, int hexSize)
        {
            var newPosition = ship.Position.SideslipRight(ship.Facing, hexSize);
            ship.MoveTo(newPosition);
        }

        public void SideslipShipLeft(Ship ship, int hexSize)
        {
            var newPosition = ship.Position.SideslipLeft(ship.Facing, hexSize);
            ship.MoveTo(newPosition);
        }

        public void TurnShipRight(Ship ship)
        {
            ship.TurnRight();
        }

        public void TurnShipLeft(Ship ship)
        {
            ship.TurnLeft();
        }
    }
}