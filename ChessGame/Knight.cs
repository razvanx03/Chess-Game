using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessGame
{
    public class Knight : APiece
    {
        public Knight(PieceColor color, PieceType type) : base(color, type)
        {

        }

        public override List<Coordinate> GetAvailableMoves(Context context, Coordinate CurrentCoordinate)
        {
            List<Coordinate> availableMoves = new List<Coordinate>();

            // L si ⅂
            // dreapta jos
            if (CurrentCoordinate.X + 2 < 8 && CurrentCoordinate.Y + 1 < 8 && !context.Layout.ContainsKey(Coordinate.GetInstance(CurrentCoordinate.X + 2, CurrentCoordinate.Y + 1)))
            {
                availableMoves.Add(Coordinate.GetInstance(CurrentCoordinate.X + 2, CurrentCoordinate.Y + 1));
            }
            else if (CurrentCoordinate.X + 2 < 8 && CurrentCoordinate.Y + 1 < 8
                && context.Layout[Coordinate.GetInstance(CurrentCoordinate.X + 2, CurrentCoordinate.Y + 1)].Color != context.Layout[Coordinate.GetInstance(CurrentCoordinate.X, CurrentCoordinate.Y)].Color)
            {
                availableMoves.Add(Coordinate.GetInstance(CurrentCoordinate.X + 2, CurrentCoordinate.Y + 1));
            }

            // dreapta sus
            if (CurrentCoordinate.X - 2 >= 0 && CurrentCoordinate.Y + 1 < 8 && !context.Layout.ContainsKey(Coordinate.GetInstance(CurrentCoordinate.X - 2, CurrentCoordinate.Y + 1)))
            {
                availableMoves.Add(Coordinate.GetInstance(CurrentCoordinate.X - 2, CurrentCoordinate.Y + 1));
            }
            else if (CurrentCoordinate.X - 2 >= 0 && CurrentCoordinate.Y + 1 < 8
                && context.Layout[Coordinate.GetInstance(CurrentCoordinate.X - 2, CurrentCoordinate.Y + 1)].Color != context.Layout[Coordinate.GetInstance(CurrentCoordinate.X, CurrentCoordinate.Y)].Color)
            {
                availableMoves.Add(Coordinate.GetInstance(CurrentCoordinate.X - 2, CurrentCoordinate.Y + 1));
            }

            // stanga jos
            if (CurrentCoordinate.X + 2 < 8 && CurrentCoordinate.Y - 1 >= 0 && !context.Layout.ContainsKey(Coordinate.GetInstance(CurrentCoordinate.X + 2, CurrentCoordinate.Y - 1)))
            {
                availableMoves.Add(Coordinate.GetInstance(CurrentCoordinate.X + 2, CurrentCoordinate.Y - 1));
            }
            else if (CurrentCoordinate.X + 2 < 8 && CurrentCoordinate.Y - 1 >= 0
                && context.Layout[Coordinate.GetInstance(CurrentCoordinate.X + 2, CurrentCoordinate.Y - 1)].Color != context.Layout[Coordinate.GetInstance(CurrentCoordinate.X, CurrentCoordinate.Y)].Color)
            {
                availableMoves.Add(Coordinate.GetInstance(CurrentCoordinate.X + 2, CurrentCoordinate.Y - 1));
            }

            // stanga sus
            if (CurrentCoordinate.X - 2 >= 0 && CurrentCoordinate.Y - 1 >= 0 && !context.Layout.ContainsKey(Coordinate.GetInstance(CurrentCoordinate.X - 2, CurrentCoordinate.Y - 1)))
            {
                availableMoves.Add(Coordinate.GetInstance(CurrentCoordinate.X - 2, CurrentCoordinate.Y - 1));
            }
            else if (CurrentCoordinate.X - 2 >= 0 && CurrentCoordinate.Y - 1 >= 0
                && context.Layout[Coordinate.GetInstance(CurrentCoordinate.X - 2, CurrentCoordinate.Y - 1)].Color != context.Layout[Coordinate.GetInstance(CurrentCoordinate.X, CurrentCoordinate.Y)].Color)
            {
                availableMoves.Add(Coordinate.GetInstance(CurrentCoordinate.X - 2, CurrentCoordinate.Y - 1));
            }

            // —┐ _|
            // stanga sus
            if (CurrentCoordinate.X - 1 >= 0 && CurrentCoordinate.Y - 2 >= 0 && !context.Layout.ContainsKey(Coordinate.GetInstance(CurrentCoordinate.X - 1, CurrentCoordinate.Y - 2)))
            {
                availableMoves.Add(Coordinate.GetInstance(CurrentCoordinate.X - 1, CurrentCoordinate.Y - 2));
            }
            else if (CurrentCoordinate.X - 1 >= 0 && CurrentCoordinate.Y - 2 >= 0
                && context.Layout[Coordinate.GetInstance(CurrentCoordinate.X - 1, CurrentCoordinate.Y - 2)].Color != context.Layout[Coordinate.GetInstance(CurrentCoordinate.X, CurrentCoordinate.Y)].Color)
            {
                availableMoves.Add(Coordinate.GetInstance(CurrentCoordinate.X - 1, CurrentCoordinate.Y - 2));
            }

            // dreapta sus
            if (CurrentCoordinate.X - 1 >= 0 && CurrentCoordinate.Y + 2 < 8 && !context.Layout.ContainsKey(Coordinate.GetInstance(CurrentCoordinate.X - 1, CurrentCoordinate.Y + 2)))
            {
                availableMoves.Add(Coordinate.GetInstance(CurrentCoordinate.X - 1, CurrentCoordinate.Y + 2));
            }
            else if (CurrentCoordinate.X - 1 >= 0 && CurrentCoordinate.Y + 2 < 8
                && context.Layout[Coordinate.GetInstance(CurrentCoordinate.X - 1, CurrentCoordinate.Y + 2)].Color != context.Layout[Coordinate.GetInstance(CurrentCoordinate.X, CurrentCoordinate.Y)].Color)
            {
                availableMoves.Add(Coordinate.GetInstance(CurrentCoordinate.X - 1, CurrentCoordinate.Y + 2));
            }

            // dreapta jos
            if (CurrentCoordinate.X + 1 < 8 && CurrentCoordinate.Y + 2 < 8 && !context.Layout.ContainsKey(Coordinate.GetInstance(CurrentCoordinate.X + 1, CurrentCoordinate.Y + 2)))
            {
                availableMoves.Add(Coordinate.GetInstance(CurrentCoordinate.X + 1, CurrentCoordinate.Y + 2));
            }
            else if (CurrentCoordinate.X + 1 < 8 && CurrentCoordinate.Y + 2 < 8
                && context.Layout[Coordinate.GetInstance(CurrentCoordinate.X + 1, CurrentCoordinate.Y + 2)].Color != context.Layout[Coordinate.GetInstance(CurrentCoordinate.X, CurrentCoordinate.Y)].Color)
            {
                availableMoves.Add(Coordinate.GetInstance(CurrentCoordinate.X + 1, CurrentCoordinate.Y + 2));
            }

            // stanga jos
            if (CurrentCoordinate.X + 1 < 8 && CurrentCoordinate.Y - 2 >= 0 && !context.Layout.ContainsKey(Coordinate.GetInstance(CurrentCoordinate.X + 1, CurrentCoordinate.Y - 2)))
            {
                availableMoves.Add(Coordinate.GetInstance(CurrentCoordinate.X + 1, CurrentCoordinate.Y - 2));
            }
            else if (CurrentCoordinate.X + 1 < 8 && CurrentCoordinate.Y - 2 >= 0
                && context.Layout[Coordinate.GetInstance(CurrentCoordinate.X + 1, CurrentCoordinate.Y - 2)].Color != context.Layout[Coordinate.GetInstance(CurrentCoordinate.X, CurrentCoordinate.Y)].Color)
            {
                availableMoves.Add(Coordinate.GetInstance(CurrentCoordinate.X + 1, CurrentCoordinate.Y - 2));
            }

            return availableMoves;
        }
    }
}
