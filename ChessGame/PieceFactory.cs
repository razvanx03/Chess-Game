using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ChessGame
{
    public class PieceFactory
    {
        public static APiece GetPiece(PieceType type, PieceColor color)
        {
            return type switch
            {
                PieceType.Queen => new Queen(color, type),
                PieceType.King => new King(color, type),
                PieceType.Rook => new Rook(color, type),
                PieceType.Knight => new Knight(color, type),
                PieceType.Bishop => new Bishop(color, type),
                PieceType.Pawn => new Pawn(color, type),
                _ => throw new ArgumentException("Invalid piece type."),
            };
        }
    }
}
