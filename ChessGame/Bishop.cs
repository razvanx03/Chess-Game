using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessGame
{
    public class Bishop : APiece
    {
        public Bishop(PieceColor color, PieceType type) : base(color, type)
        {

        }

        public override List<Coordinate> GetAvailableMoves(Context context, Coordinate CurrentCoordinate)
        {
            List<Coordinate> availableMoves = new List<Coordinate>();

            // diagonala dreapta jos
            for (int i = 1; i < 8; i++)
            {
                if (CurrentCoordinate.X + i < 8 && CurrentCoordinate.Y + i < 8 && !context.Layout.ContainsKey(Coordinate.GetInstance(CurrentCoordinate.X + i, CurrentCoordinate.Y + i)))
                {
                    availableMoves.Add(Coordinate.GetInstance(CurrentCoordinate.X + i, CurrentCoordinate.Y + i));
                }
                else if (CurrentCoordinate.X + i < 8 && CurrentCoordinate.Y + i < 8
                    && context.Layout.ContainsKey(Coordinate.GetInstance(CurrentCoordinate.X + i, CurrentCoordinate.Y + i))
                    && context.Layout[Coordinate.GetInstance(CurrentCoordinate.X + i, CurrentCoordinate.Y + i)].Color != context.Layout[Coordinate.GetInstance(CurrentCoordinate.X, CurrentCoordinate.Y)].Color)
                {
                    availableMoves.Add(Coordinate.GetInstance(CurrentCoordinate.X + i, CurrentCoordinate.Y + i));
                    break;
                }
                else break;
            }

            // diagonala dreapta sus
            for (int i = 1; i < 8; i++)
            {
                if (CurrentCoordinate.X - i >= 0 && CurrentCoordinate.Y + i < 8 && !context.Layout.ContainsKey(Coordinate.GetInstance(CurrentCoordinate.X - i, CurrentCoordinate.Y + i)))
                {
                    availableMoves.Add(Coordinate.GetInstance(CurrentCoordinate.X - i, CurrentCoordinate.Y + i));
                }
                else if (CurrentCoordinate.X - i >= 0 && CurrentCoordinate.Y + i < 8
                    && context.Layout.ContainsKey(Coordinate.GetInstance(CurrentCoordinate.X - i, CurrentCoordinate.Y + i))
                    && context.Layout[Coordinate.GetInstance(CurrentCoordinate.X - i, CurrentCoordinate.Y + i)].Color != context.Layout[Coordinate.GetInstance(CurrentCoordinate.X, CurrentCoordinate.Y)].Color)
                {
                    availableMoves.Add(Coordinate.GetInstance(CurrentCoordinate.X - i, CurrentCoordinate.Y + i));
                    break;
                }
                else break;
            }

            // diagonala stanga jos
            for (int i = 1; i < 8; i++)
            {
                if (CurrentCoordinate.X + i < 8 && CurrentCoordinate.Y - i >= 0 && !context.Layout.ContainsKey(Coordinate.GetInstance(CurrentCoordinate.X + i, CurrentCoordinate.Y - i)))
                {
                    availableMoves.Add(Coordinate.GetInstance(CurrentCoordinate.X + i, CurrentCoordinate.Y - i));
                }
                else if (CurrentCoordinate.X + i < 8 && CurrentCoordinate.Y - i >= 0
                    && context.Layout.ContainsKey(Coordinate.GetInstance(CurrentCoordinate.X + i, CurrentCoordinate.Y - i))
                    && context.Layout[Coordinate.GetInstance(CurrentCoordinate.X + i, CurrentCoordinate.Y - i)].Color != context.Layout[Coordinate.GetInstance(CurrentCoordinate.X, CurrentCoordinate.Y)].Color)
                {
                    availableMoves.Add(Coordinate.GetInstance(CurrentCoordinate.X + i, CurrentCoordinate.Y - i));
                    break;
                }
                else break;
            }

            // diagonala stanga sus
            for (int i = 1; i < 8; i++)
            {
                if (CurrentCoordinate.X - i >= 0 && CurrentCoordinate.Y - i >= 0 && !context.Layout.ContainsKey(Coordinate.GetInstance(CurrentCoordinate.X - i, CurrentCoordinate.Y - i)))
                {
                    availableMoves.Add(Coordinate.GetInstance(CurrentCoordinate.X - i, CurrentCoordinate.Y - i));
                }
                else if (CurrentCoordinate.X - i >= 0 && CurrentCoordinate.Y - i >= 0
                    && context.Layout.ContainsKey(Coordinate.GetInstance(CurrentCoordinate.X - i, CurrentCoordinate.Y - i))
                    && context.Layout[Coordinate.GetInstance(CurrentCoordinate.X - i, CurrentCoordinate.Y - i)].Color != context.Layout[Coordinate.GetInstance(CurrentCoordinate.X, CurrentCoordinate.Y)].Color)
                {
                    availableMoves.Add(Coordinate.GetInstance(CurrentCoordinate.X - i, CurrentCoordinate.Y - i));
                    break;
                }
                else break;
            }

            return availableMoves;
        }
    }
}
