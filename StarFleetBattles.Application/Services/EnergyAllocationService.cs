using StarFleetBattles.Domain.ValueObjects;

namespace StarFleetBattles.Application.Services
{
    public interface IEnergyAllocationService
    {
        int GetCurrentTurn();
        List<EnergyAllocationModel> GetAllTurns();
        EnergyAllocationModel GetTurn(int turnNumber);
        void UpdateTurn(int turnNumber, EnergyAllocationModel allocation);
        void AdvanceTurn();
        void ResetGame();
        bool ValidateTurn(int turnNumber, out string errorMessage);
    }

    public class EnergyAllocationService : IEnergyAllocationService
    {
        private readonly List<EnergyAllocationModel> _turns;
        private int _currentTurn;
        private const int MaxTurns = 10;

        public EnergyAllocationService()
        {
            _turns = new List<EnergyAllocationModel>();
            _currentTurn = 1;
            InitializeFirstTurn();
        }

        public int GetCurrentTurn()
        {
            return _currentTurn;
        }

        public List<EnergyAllocationModel> GetAllTurns()
        {
            return _turns;
        }

        public EnergyAllocationModel GetTurn(int turnNumber)
        {
            var turn = _turns.FirstOrDefault(t => t.TurnNumber == turnNumber);
            if (turn == null)
            {
                turn = new EnergyAllocationModel
                {
                    TurnNumber = turnNumber,
                    WarpEnginePower = 30,
                    ImpulseEnginePower = 4,
                    ReactorPower = 4,
                    BatteryPowerAvailable = 0
                };
                _turns.Add(turn);
            }
            return turn;
        }

        public void UpdateTurn(int turnNumber, EnergyAllocationModel allocation)
        {
            var existingTurn = _turns.FirstOrDefault(t => t.TurnNumber == turnNumber);
            if (existingTurn != null)
            {
                _turns.Remove(existingTurn);
            }
            _turns.Add(allocation);
        }

        public void AdvanceTurn()
        {
            if (_currentTurn < MaxTurns)
            {
                _currentTurn++;
                GetTurn(_currentTurn);
            }
        }

        public void ResetGame()
        {
            _turns.Clear();
            _currentTurn = 1;
            InitializeFirstTurn();
        }

        public bool ValidateTurn(int turnNumber, out string errorMessage)
        {
            var turn = _turns.FirstOrDefault(t => t.TurnNumber == turnNumber);
            if (turn == null)
            {
                errorMessage = "Turn not found";
                return false;
            }

            return turn.IsValid(out errorMessage);
        }

        private void InitializeFirstTurn()
        {
            var firstTurn = new EnergyAllocationModel
            {
                TurnNumber = 1,
                WarpEnginePower = 30,
                ImpulseEnginePower = 4,
                ReactorPower = 4,
                BatteryPowerAvailable = 0
            };
            _turns.Add(firstTurn);
        }
    }
}