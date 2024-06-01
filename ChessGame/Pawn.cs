using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessGame
{
    public class Pawn : APiece
    {
        public Pawn(PieceColor color, PieceType type) : base(color, type)
        {

        }
       
        public override List<Coordinate> GetAvailableMoves(Context context, Coordinate CurrentCoordinate)  // daca ajunge in capat se transforma in orice != king
        {
            List<Coordinate> availableMoves = new List<Coordinate>();

            // white
            if (context.Layout[CurrentCoordinate].Color == PieceColor.White) 
            {
                int length;
                if (CurrentCoordinate.X == 6)
                {
                    length = 2;
                }
                else length = 1;

                for (int i = 1; i <= length; i++)
                {
                    if (CurrentCoordinate.X - i >= 0 && !context.Layout.ContainsKey(Coordinate.GetInstance(CurrentCoordinate.X - i, CurrentCoordinate.Y)))
                    {
                        availableMoves.Add(Coordinate.GetInstance(CurrentCoordinate.X - i, CurrentCoordinate.Y));
                    }
                    else break;
                }

                // left
                if (CurrentCoordinate.X - 1 >= 0 && CurrentCoordinate.Y - 1 >= 0
                    && context.Layout.ContainsKey(Coordinate.GetInstance(CurrentCoordinate.X - 1, CurrentCoordinate.Y - 1))
                    && context.Layout[Coordinate.GetInstance(CurrentCoordinate.X - 1, CurrentCoordinate.Y - 1)].Color != context.Layout[Coordinate.GetInstance(CurrentCoordinate.X, CurrentCoordinate.Y)].Color)
                {
                    availableMoves.Add(Coordinate.GetInstance(CurrentCoordinate.X - 1, CurrentCoordinate.Y - 1));
                }

                // right
                if (CurrentCoordinate.X - 1 >= 0 && CurrentCoordinate.Y + 1 < 8
                    && context.Layout.ContainsKey(Coordinate.GetInstance(CurrentCoordinate.X - 1, CurrentCoordinate.Y + 1))
                    && context.Layout[Coordinate.GetInstance(CurrentCoordinate.X - 1, CurrentCoordinate.Y + 1)].Color != context.Layout[Coordinate.GetInstance(CurrentCoordinate.X, CurrentCoordinate.Y)].Color)
                {
                    availableMoves.Add(Coordinate.GetInstance(CurrentCoordinate.X - 1, CurrentCoordinate.Y + 1));
                }
            }

            // black context.CurrentPlayerColor == PieceColor.Black
            if (context.Layout[CurrentCoordinate].Color == PieceColor.Black)
            {
                int length;
                if (CurrentCoordinate.X == 1)
                {
                    length = 2;
                }
                else length = 1;

                for (int i = 1; i <= length; i++)
                {
                    if (CurrentCoordinate.X + i < 8 && !context.Layout.ContainsKey(Coordinate.GetInstance(CurrentCoordinate.X + i, CurrentCoordinate.Y)))
                    {
                        availableMoves.Add(Coordinate.GetInstance(CurrentCoordinate.X + i, CurrentCoordinate.Y));
                    }
                    else break;
                }

                // left
                if (CurrentCoordinate.X + 1 < 8 && CurrentCoordinate.Y - 1 >= 0
                    && context.Layout.ContainsKey(Coordinate.GetInstance(CurrentCoordinate.X + 1, CurrentCoordinate.Y - 1))
                    && context.Layout[Coordinate.GetInstance(CurrentCoordinate.X + 1, CurrentCoordinate.Y - 1)].Color != context.Layout[Coordinate.GetInstance(CurrentCoordinate.X, CurrentCoordinate.Y)].Color)
                {
                    availableMoves.Add(Coordinate.GetInstance(CurrentCoordinate.X + 1, CurrentCoordinate.Y - 1));
                }

                // right
                if (CurrentCoordinate.X + 1 < 8 && CurrentCoordinate.Y + 1 < 8
                    && context.Layout.ContainsKey(Coordinate.GetInstance(CurrentCoordinate.X + 1, CurrentCoordinate.Y + 1))
                    && context.Layout[Coordinate.GetInstance(CurrentCoordinate.X + 1, CurrentCoordinate.Y + 1)].Color != context.Layout[Coordinate.GetInstance(CurrentCoordinate.X, CurrentCoordinate.Y)].Color)
                {
                    availableMoves.Add(Coordinate.GetInstance(CurrentCoordinate.X + 1, CurrentCoordinate.Y + 1));
                }
            }

            return availableMoves;
        }
    }
}
