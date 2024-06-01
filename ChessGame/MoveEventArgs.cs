using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class MoveEventArgs : EventArgs
    {
        public Move Move { get; set; }

        public MoveEventArgs(Move move)
        {
            Move = move;
        }
    }

}
