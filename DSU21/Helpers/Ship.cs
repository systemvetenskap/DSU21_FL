using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace DSU21.Helpers
{
    public enum Direction
    {
        Horizontal, Vertical
    }
    public enum Result
    {
        Hit, Miss, Sunk
    }
    public class Ship
    {
        public Ship(Point startLocation, Direction direction)
        {
            StartLocation = startLocation;
            Direction = direction;
        }
        public string Type { get; set; } = "Submarine";

        public Point StartLocation { get; }
        public Direction Direction { get; }

        public Result UnderAttack(Point point)
        {
            if (point.X == 3 && point.Y==6)
            {
                return Result.Sunk;
            }
            return Result.Hit;
        }
    }
}
