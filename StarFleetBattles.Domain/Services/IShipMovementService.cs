using StarFleetBattles.Domain.Entities;

namespace StarFleetBattles.Domain.Services
{
    public interface IShipMovementService
    {
        void MoveShipNormal(Ship ship, int hexSize);
        void SideslipShipRight(Ship ship, int hexSize);
        void SideslipShipLeft(Ship ship, int hexSize);
        void TurnShipRight(Ship ship);
        void TurnShipLeft(Ship ship);
    }
}