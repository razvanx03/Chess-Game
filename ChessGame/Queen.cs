using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;

namespace ChessGame
{
    public class Queen : APiece
    {
        public Queen(PieceColor color, PieceType type) : base(color,type) 
        { 
            
        }

        public override List<Coordinate> GetAvailableMoves(Context context, Coordinate CurrentCoordinate)
        {
            List <Coordinate> availableMoves = new List<Coordinate> ();

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
