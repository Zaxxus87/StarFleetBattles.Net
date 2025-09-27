using StarFleetBattles.Application.DTOs;
using StarFleetBattles.Domain.Entities;
using StarFleetBattles.Domain.Services;
using StarFleetBattles.Domain.ValueObjects;

namespace StarFleetBattles.Application.Services
{
    public interface IGameService
    {
        Task<GameBoardDto> GetGameBoardAsync();
        Task<ShipDto?> GetPlayerShipAsync();
        Task MovePlayerShipNormalAsync();
        Task SideslipPlayerShipRightAsync();
        Task SideslipPlayerShipLeftAsync();
        Task TurnPlayerShipRightAsync();
        Task TurnPlayerShipLeftAsync();
        Task InitializeGameAsync();
    }

    public class GameService : IGameService
    {
        private readonly IShipMovementService _shipMovementService;
        private GameBoard _gameBoard;
        private Ship? _playerShip;

        public GameService(IShipMovementService shipMovementService)
        {
            _shipMovementService = shipMovementService;
            _gameBoard = new GameBoard(30);
        }

        public async Task InitializeGameAsync()
        {
            try
            {
                // Use EXACT same calculations as Home.razor
                var hexSize = 30;
                var hexWidth = hexSize * 2;
                var hexHeight = hexSize * Math.Sqrt(3);
                var colWidth = hexWidth * 0.75;
                var rowHeight = hexHeight;

                // Start ship at specific hex coordinates
                var startRow = 4;
                var startCol = 6;

                var startX = 50 + startCol * colWidth;
                var startY = 50 + startRow * rowHeight;

                // Apply column offset if odd column
                if (startCol % 2 == 1)
                {
                    startY += rowHeight / 2;
                }

                var startPosition = new Position(startX, startY);
                _playerShip = new Ship(startPosition, ShipType.Federation, "Player Ship", 0);
                _gameBoard.AddShip(_playerShip);

                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to initialize game: {ex.Message}", ex);
            }
        }

        public async Task<GameBoardDto> GetGameBoardAsync()
        {
            var hexagons = GenerateHexagons();

            var boardDto = new GameBoardDto
            {
                HexSize = _gameBoard.HexSize,
                Rows = _gameBoard.Rows,
                Columns = _gameBoard.Columns,
                Ships = _gameBoard.Ships.Select(MapShipToDto).ToList(),
                Hexagons = hexagons
            };

            return await Task.FromResult(boardDto);
        }

        public async Task<ShipDto?> GetPlayerShipAsync()
        {
            if (_playerShip == null)
                return null;

            return await Task.FromResult(MapShipToDto(_playerShip));
        }

        public async Task MovePlayerShipNormalAsync()
        {
            if (_playerShip != null)
            {
                _shipMovementService.MoveShipNormal(_playerShip, _gameBoard.HexSize);
            }
            await Task.CompletedTask;
        }

        public async Task SideslipPlayerShipRightAsync()
        {
            if (_playerShip != null)
            {
                _shipMovementService.SideslipShipRight(_playerShip, _gameBoard.HexSize);
            }
            await Task.CompletedTask;
        }

        public async Task SideslipPlayerShipLeftAsync()
        {
            if (_playerShip != null)
            {
                _shipMovementService.SideslipShipLeft(_playerShip, _gameBoard.HexSize);
            }
            await Task.CompletedTask;
        }

        public async Task TurnPlayerShipRightAsync()
        {
            if (_playerShip != null)
            {
                _shipMovementService.TurnShipRight(_playerShip);
            }
            await Task.CompletedTask;
        }

        public async Task TurnPlayerShipLeftAsync()
        {
            if (_playerShip != null)
            {
                _shipMovementService.TurnShipLeft(_playerShip);
            }
            await Task.CompletedTask;
        }

        private ShipDto MapShipToDto(Ship ship)
        {
            return new ShipDto
            {
                Id = ship.Id,
                X = ship.Position.X,
                Y = ship.Position.Y,
                Facing = ship.Facing,
                ShipType = ship.ShipType.ToString(),
                Name = ship.Name,
                ImagePath = $"/images/{ship.ShipType.ToString().ToLower()}{ship.Facing + 1}.jpg"
            };
        }

        private List<HexagonDto> GenerateHexagons()
        {
            var hexagons = new List<HexagonDto>();
            var hexSize = _gameBoard.HexSize;
            var x = 0.0;
            var y = (hexSize / 2.0) * Math.Sqrt(3);

            for (int row = 0; row < _gameBoard.Rows; row++)
            {
                var currentY = y;
                for (int col = 0; col < _gameBoard.Columns; col++)
                {
                    var points = _gameBoard.GetHexagonPoints(x, currentY);
                    var hexagon = new HexagonDto
                    {
                        X = x,
                        Y = currentY,
                        Points = points.Select(p => new PointDto { X = p.X, Y = p.Y }).ToList()
                    };
                    hexagons.Add(hexagon);
                    currentY += hexSize * Math.Sqrt(3);
                }

                x += hexSize * 1.5;
                if (row % 2 == 0)
                {
                    y = y + ((hexSize / 2.0) * Math.Sqrt(3));
                }
                else
                {
                    y = (hexSize / 2.0) * Math.Sqrt(3);
                }
            }

            return hexagons;
        }
    }
}