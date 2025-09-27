namespace StarFleetBattles.Domain.ValueObjects
{
    public record Position(double X, double Y)
    {
        public Position MoveNormal(int facing, double hexSize)
        {
            // Use same spacing as grid
            var hexWidth = hexSize * 2;
            var hexHeight = hexSize * Math.Sqrt(3);
            var colWidth = hexWidth * 0.75;
            var rowHeight = hexHeight;

            return facing switch
            {
                0 => this with { Y = Y - rowHeight },                        // North
                1 => this with { X = X + colWidth, Y = Y - rowHeight / 2 },    // Northeast  
                2 => this with { X = X + colWidth, Y = Y + rowHeight / 2 },    // Southeast
                3 => this with { Y = Y + rowHeight },                        // South
                4 => this with { X = X - colWidth, Y = Y + rowHeight / 2 },    // Southwest
                5 => this with { X = X - colWidth, Y = Y - rowHeight / 2 },    // Northwest
                _ => this
            };
        }

        public Position SideslipRight(int facing, double hexSize)
        {
            var hexWidth = hexSize * 2;
            var hexHeight = hexSize * Math.Sqrt(3);
            var colWidth = hexWidth * 0.75;
            var rowHeight = hexHeight;

            return facing switch
            {
                0 => this with { X = X + colWidth, Y = Y - rowHeight / 2 },    // Northeast
                1 => this with { X = X + colWidth, Y = Y + rowHeight / 2 },    // Southeast
                2 => this with { Y = Y + rowHeight },                        // South
                3 => this with { X = X - colWidth, Y = Y + rowHeight / 2 },    // Southwest
                4 => this with { X = X - colWidth, Y = Y - rowHeight / 2 },    // Northwest
                5 => this with { Y = Y - rowHeight },                        // North
                _ => this
            };
        }

        public Position SideslipLeft(int facing, double hexSize)
        {
            var hexWidth = hexSize * 2;
            var hexHeight = hexSize * Math.Sqrt(3);
            var colWidth = hexWidth * 0.75;
            var rowHeight = hexHeight;

            return facing switch
            {
                0 => this with { X = X - colWidth, Y = Y - rowHeight / 2 },    // Northwest
                1 => this with { Y = Y - rowHeight },                        // North
                2 => this with { X = X + colWidth, Y = Y - rowHeight / 2 },    // Northeast
                3 => this with { X = X + colWidth, Y = Y + rowHeight / 2 },    // Southeast
                4 => this with { Y = Y + rowHeight },                        // South
                5 => this with { X = X - colWidth, Y = Y + rowHeight / 2 },    // Southwest
                _ => this
            };
        }
    }
}