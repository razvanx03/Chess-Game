using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessGame
{
    public class King : APiece
    {
        public bool Moved { get; set; }
        public bool IsInCheck { get; set; }

        public King(PieceColor color, PieceType type) : base(color, type)
        {
            Moved = false;
            IsInCheck = false;
        }

        public override List<Coordinate> GetAvailableMoves(Context context, Coordinate CurrentCoordinate)
        {
            List<Coordinate> availableMoves = new List<Coordinate>();

            // dreapta
            if (CurrentCoordinate.Y + 1 < 8 && !context.Layout.ContainsKey(Coordinate.GetInstance(CurrentCoordinate.X, CurrentCoordinate.Y + 1)))
            {
                availableMoves.Add(Coordinate.GetInstance(CurrentCoordinate.X, CurrentCoordinate.Y + 1));
            }
            else if (CurrentCoordinate.Y + 1 < 8 
                && context.Layout[Coordinate.GetInstance(CurrentCoordinate.X, CurrentCoordinate.Y + 1)].Color != context.Layout[Coordinate.GetInstance(CurrentCoordinate.X, CurrentCoordinate.Y)].Color)
            {
                availableMoves.Add(Coordinate.GetInstance(CurrentCoordinate.X, CurrentCoordinate.Y + 1));
            }

            // stanga
            if (CurrentCoordinate.Y - 1 >= 0 && !context.Layout.ContainsKey(Coordinate.GetInstance(CurrentCoordinate.X, CurrentCoordinate.Y - 1)))
            {
                availableMoves.Add(Coordinate.GetInstance(CurrentCoordinate.X, CurrentCoordinate.Y - 1));
            }
            else if (CurrentCoordinate.Y - 1 >= 0
                && context.Layout[Coordinate.GetInstance(CurrentCoordinate.X, CurrentCoordinate.Y - 1)].Color != context.Layout[Coordinate.GetInstance(CurrentCoordinate.X, CurrentCoordinate.Y)].Color)
            {
                availableMoves.Add(Coordinate.GetInstance(CurrentCoordinate.X, CurrentCoordinate.Y - 1));
            }

            // sus
            if (CurrentCoordinate.X - 1 >= 0 && !context.Layout.ContainsKey(Coordinate.GetInstance(CurrentCoordinate.X - 1, CurrentCoordinate.Y)))
            {
                availableMoves.Add(Coordinate.GetInstance(CurrentCoordinate.X - 1, CurrentCoordinate.Y));
            }
            else if (CurrentCoordinate.X - 1 >= 0
                && context.Layout[Coordinate.GetInstance(CurrentCoordinate.X - 1, CurrentCoordinate.Y)].Color != context.Layout[Coordinate.GetInstance(CurrentCoordinate.X, CurrentCoordinate.Y)].Color)
            {
                availableMoves.Add(Coordinate.GetInstance(CurrentCoordinate.X - 1, CurrentCoordinate.Y));
            }

            // jos
            if (CurrentCoordinate.X + 1 < 8 && !context.Layout.ContainsKey(Coordinate.GetInstance(CurrentCoordinate.X + 1, CurrentCoordinate.Y)))
            {
                availableMoves.Add(Coordinate.GetInstance(CurrentCoordinate.X + 1, CurrentCoordinate.Y));
            }
            else if (CurrentCoordinate.X + 1 < 8
                && context.Layout[Coordinate.GetInstance(CurrentCoordinate.X + 1, CurrentCoordinate.Y)].Color != context.Layout[Coordinate.GetInstance(CurrentCoordinate.X, CurrentCoordinate.Y)].Color )
            {
                availableMoves.Add(Coordinate.GetInstance(CurrentCoordinate.X + 1, CurrentCoordinate.Y));
            }

            // diagonala dreapta jos
            if (CurrentCoordinate.X + 1 < 8 && CurrentCoordinate.Y + 1 < 8 && !context.Layout.ContainsKey(Coordinate.GetInstance(CurrentCoordinate.X + 1, CurrentCoordinate.Y + 1)))
            {
                availableMoves.Add(Coordinate.GetInstance(CurrentCoordinate.X + 1, CurrentCoordinate.Y + 1));
            }
            else if (CurrentCoordinate.X + 1 < 8
                && CurrentCoordinate.Y + 1 < 8 &&  context.Layout[Coordinate.GetInstance(CurrentCoordinate.X + 1, CurrentCoordinate.Y + 1)].Color != context.Layout[Coordinate.GetInstance(CurrentCoordinate.X, CurrentCoordinate.Y)].Color)
            {
                availableMoves.Add(Coordinate.GetInstance(CurrentCoordinate.X + 1, CurrentCoordinate.Y + 1));
            }

            // diagonala dreapta sus
            if (CurrentCoordinate.X - 1 >= 0 && CurrentCoordinate.Y + 1 < 8 && !context.Layout.ContainsKey(Coordinate.GetInstance(CurrentCoordinate.X - 1, CurrentCoordinate.Y + 1)))
            {
                availableMoves.Add(Coordinate.GetInstance(CurrentCoordinate.X - 1, CurrentCoordinate.Y + 1));
            }
            else if (CurrentCoordinate.X - 1 >= 0 && CurrentCoordinate.Y + 1 < 8
                && context.Layout[Coordinate.GetInstance(CurrentCoordinate.X - 1, CurrentCoordinate.Y + 1)].Color != context.Layout[Coordinate.GetInstance(CurrentCoordinate.X, CurrentCoordinate.Y)].Color)
            {
                availableMoves.Add(Coordinate.GetInstance(CurrentCoordinate.X - 1, CurrentCoordinate.Y + 1));
            }

            // diagonala stanga jos
            if (CurrentCoordinate.X + 1 < 8 && CurrentCoordinate.Y - 1 >= 0 && !context.Layout.ContainsKey(Coordinate.GetInstance(CurrentCoordinate.X + 1, CurrentCoordinate.Y - 1)))
            {
                availableMoves.Add(Coordinate.GetInstance(CurrentCoordinate.X + 1, CurrentCoordinate.Y - 1));
            }
            else if (CurrentCoordinate.X + 1 < 8 && CurrentCoordinate.Y - 1 >= 0
                && context.Layout[Coordinate.GetInstance(CurrentCoordinate.X + 1, CurrentCoordinate.Y - 1)].Color != context.Layout[Coordinate.GetInstance(CurrentCoordinate.X, CurrentCoordinate.Y)].Color)
            {
                availableMoves.Add(Coordinate.GetInstance(CurrentCoordinate.X + 1, CurrentCoordinate.Y - 1));
            }

            // diagonala stanga sus
            if (CurrentCoordinate.X - 1 >= 0 && CurrentCoordinate.Y - 1 >= 0 && !context.Layout.ContainsKey(Coordinate.GetInstance(CurrentCoordinate.X - 1, CurrentCoordinate.Y - 1)))
            {
                availableMoves.Add(Coordinate.GetInstance(CurrentCoordinate.X - 1, CurrentCoordinate.Y - 1));
            }
            else if (CurrentCoordinate.X - 1 >= 0 && CurrentCoordinate.Y - 1 >= 0
                && context.Layout[Coordinate.GetInstance(CurrentCoordinate.X - 1, CurrentCoordinate.Y - 1)].Color != context.Layout[Coordinate.GetInstance(CurrentCoordinate.X, CurrentCoordinate.Y)].Color)
            {
                availableMoves.Add(Coordinate.GetInstance(CurrentCoordinate.X - 1, CurrentCoordinate.Y - 1));
            }

            if (context.CurrentPlayerColor == PieceColor.White)
            {
                // rocada dreapta
                if (!Moved
                    && !context.Layout.ContainsKey(Coordinate.GetInstance(7, 5))
                    && !context.Layout.ContainsKey(Coordinate.GetInstance(7, 6))
                    && context.Layout.ContainsKey(Coordinate.GetInstance(7, 7))
                    && context.Layout[Coordinate.GetInstance(7, 7)] is Rook rightRook && !rightRook.Moved)
                {
                    availableMoves.Add(Coordinate.GetInstance(7, 6));
                }

                // rocada stanga
                if (!Moved
                    && !context.Layout.ContainsKey(Coordinate.GetInstance(7, 3))
                    && !context.Layout.ContainsKey(Coordinate.GetInstance(7, 2))
                    && !context.Layout.ContainsKey(Coordinate.GetInstance(7, 1))
                    && context.Layout.ContainsKey(Coordinate.GetInstance(7, 0))
                    && context.Layout[Coordinate.GetInstance(7, 0)] is Rook leftRook && !leftRook.Moved)
                {
                    availableMoves.Add(Coordinate.GetInstance(7, 2));
                }
            }

            if (context.CurrentPlayerColor == PieceColor.Black)
            {
                // rocada dreapta
                if (!Moved
                    && !context.Layout.ContainsKey(Coordinate.GetInstance(0, 5))
                    && !context.Layout.ContainsKey(Coordinate.GetInstance(0, 6))
                    && context.Layout.ContainsKey(Coordinate.GetInstance(0, 7))
                    && context.Layout[Coordinate.GetInstance(0, 7)] is Rook rightRook && !rightRook.Moved)
                {
                    availableMoves.Add(Coordinate.GetInstance(0, 6));
                }

                // rocada stanga
                if (!Moved
                    && !context.Layout.ContainsKey(Coordinate.GetInstance(0, 3))
                    && !context.Layout.ContainsKey(Coordinate.GetInstance(0, 2))
                    && !context.Layout.ContainsKey(Coordinate.GetInstance(0, 1))
                    && context.Layout.ContainsKey(Coordinate.GetInstance(0, 0))
                    && context.Layout[Coordinate.GetInstance(0, 0)] is Rook leftRook && !leftRook.Moved)
                {
                    availableMoves.Add(Coordinate.GetInstance(0, 2));
                }
            }

            return availableMoves;
        }
    }
}
