using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class APieceAdaptor
    {
        public PieceType Type { get; set; }
        public PieceColor Color { get; set; }
        public APieceAdaptor(PieceType type, PieceColor color) 
        {
            Type = type;
            Color = color;
        }
    }
}
