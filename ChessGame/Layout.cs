using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public abstract class Layout : Dictionary<Coordinate, APiece>
    {
        public abstract void Initialise();

        public abstract void Move(Coordinate source, Coordinate destination);

        public abstract void TestMove(Coordinate source, Coordinate destination);

        public abstract Layout Clone();

    }
}
