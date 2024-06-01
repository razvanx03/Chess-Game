using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ChessGame
{
    public class Coordinate
    {
        private static readonly Dictionary<(int, int), Coordinate> coordinates = new Dictionary<(int, int), Coordinate>();

        public int X { get; }
        public int Y { get; }

        private Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Coordinate GetInstance(int x, int y)
        {
            if (x > 7 || y > 7 || x < 0 || y < 0)
            {
                throw new Exception("Invalid arguments: x = " + x + " y = " + y);
            }

            if (!coordinates.ContainsKey((x, y)))
            {
                coordinates[(x, y)] = new Coordinate(x, y);
            }
            return coordinates[(x, y)];
        }
    }
}
