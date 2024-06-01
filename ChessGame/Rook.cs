using System.Collections.Generic;

namespace ChessGame
{
    public class Rook : APiece
    {
        public bool Moved { get; set;  }
        public Rook(PieceColor color, PieceType type) : base(color, type)
        {
            Moved = false;
        }

        public override List<Coordinate> GetAvailableMoves(Context context, Coordinate CurrentCoordinate)
        {
            List<Coordinate> availableMoves = new List<Coordinate>();

            // dreapta
            for (int i = 1; i < 8; i++)
            {
                if (CurrentCoordinate.Y + i < 8 && !context.Layout.ContainsKey(Coordinate.GetInstance(CurrentCoordinate.X, CurrentCoordinate.Y + i)))
                {
                    availableMoves.Add(Coordinate.GetInstance(CurrentCoordinate.X, CurrentCoordinate.Y + i));
                }
                else if (CurrentCoordinate.Y + i < 8
                    && context.Layout.ContainsKey(Coordinate.GetInstance(CurrentCoordinate.X, CurrentCoordinate.Y + i))
                    && context.Layout[Coordinate.GetInstance(CurrentCoordinate.X, CurrentCoordinate.Y + i)].Color != context.Layout[Coordinate.GetInstance(CurrentCoordinate.X, CurrentCoordinate.Y)].Color)
                {
                    availableMoves.Add(Coordinate.GetInstance(CurrentCoordinate.X, CurrentCoordinate.Y + i));
                    break;
                }
                else break;
            }

            // stanga
            for (int i = 1; i < 8; i++)
            {
                if (CurrentCoordinate.Y - i >= 0 && !context.Layout.ContainsKey(Coordinate.GetInstance(CurrentCoordinate.X, CurrentCoordinate.Y - i)))
                {
                    availableMoves.Add(Coordinate.GetInstance(CurrentCoordinate.X, CurrentCoordinate.Y - i));
                }
                else if (CurrentCoordinate.Y - i >= 0
                    && context.Layout.ContainsKey(Coordinate.GetInstance(CurrentCoordinate.X, CurrentCoordinate.Y - i))
                    && context.Layout[Coordinate.GetInstance(CurrentCoordinate.X, CurrentCoordinate.Y - i)].Color != context.Layout[Coordinate.GetInstance(CurrentCoordinate.X, CurrentCoordinate.Y)].Color)
                {
                    availableMoves.Add(Coordinate.GetInstance(CurrentCoordinate.X, CurrentCoordinate.Y - i));
                    break;
                }
                else break;
            }

            // sus
            for (int i = 1; i < 8; i++)
            {
                if (CurrentCoordinate.X - i >= 0 && !context.Layout.ContainsKey(Coordinate.GetInstance(CurrentCoordinate.X - i, CurrentCoordinate.Y)))
                {
                    availableMoves.Add(Coordinate.GetInstance(CurrentCoordinate.X - i, CurrentCoordinate.Y));
                }
                else if (CurrentCoordinate.X - i >= 0
                    && context.Layout.ContainsKey(Coordinate.GetInstance(CurrentCoordinate.X - i, CurrentCoordinate.Y))
                    && context.Layout[Coordinate.GetInstance(CurrentCoordinate.X - i, CurrentCoordinate.Y)].Color != context.Layout[Coordinate.GetInstance(CurrentCoordinate.X, CurrentCoordinate.Y)].Color)
                {
                    availableMoves.Add(Coordinate.GetInstance(CurrentCoordinate.X - i, CurrentCoordinate.Y));
                    break;
                }
                else break;
            }

            // jos
            for (int i = 1; i < 8; i++)
            {
                if (CurrentCoordinate.X + i < 8 && !context.Layout.ContainsKey(Coordinate.GetInstance(CurrentCoordinate.X + i, CurrentCoordinate.Y)))
                {
                    availableMoves.Add(Coordinate.GetInstance(CurrentCoordinate.X + i, CurrentCoordinate.Y));
                }
                else if (CurrentCoordinate.X + i < 8
                    && context.Layout.ContainsKey(Coordinate.GetInstance(CurrentCoordinate.X + i, CurrentCoordinate.Y))
                    && context.Layout[Coordinate.GetInstance(CurrentCoordinate.X + i, CurrentCoordinate.Y)].Color != context.Layout[Coordinate.GetInstance(CurrentCoordinate.X, CurrentCoordinate.Y)].Color)
                {
                    availableMoves.Add(Coordinate.GetInstance(CurrentCoordinate.X + i, CurrentCoordinate.Y));
                    break;
                }
                else break;
            }

            return availableMoves;
        }
    }
}
