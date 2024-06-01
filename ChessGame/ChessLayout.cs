using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Media;
using System.Reflection;

namespace ChessGame
{
    public class ChessLayout : Layout
    {
        public override void Initialise()
        {
            Add(Coordinate.GetInstance(0, 0), PieceFactory.GetPiece(PieceType.Rook, PieceColor.Black));
            Add(Coordinate.GetInstance(0, 1), PieceFactory.GetPiece(PieceType.Knight, PieceColor.Black));
            Add(Coordinate.GetInstance(0, 2), PieceFactory.GetPiece(PieceType.Bishop, PieceColor.Black));
            Add(Coordinate.GetInstance(0, 3), PieceFactory.GetPiece(PieceType.Queen, PieceColor.Black));
            Add(Coordinate.GetInstance(0, 4), PieceFactory.GetPiece(PieceType.King, PieceColor.Black));
            Add(Coordinate.GetInstance(0, 5), PieceFactory.GetPiece(PieceType.Bishop, PieceColor.Black));
            Add(Coordinate.GetInstance(0, 6), PieceFactory.GetPiece(PieceType.Knight, PieceColor.Black));
            Add(Coordinate.GetInstance(0, 7), PieceFactory.GetPiece(PieceType.Rook, PieceColor.Black));
            Add(Coordinate.GetInstance(7, 0), PieceFactory.GetPiece(PieceType.Rook, PieceColor.White));
            Add(Coordinate.GetInstance(7, 1), PieceFactory.GetPiece(PieceType.Knight, PieceColor.White));
            Add(Coordinate.GetInstance(7, 2), PieceFactory.GetPiece(PieceType.Bishop, PieceColor.White));
            Add(Coordinate.GetInstance(7, 3), PieceFactory.GetPiece(PieceType.Queen, PieceColor.White));
            Add(Coordinate.GetInstance(7, 4), PieceFactory.GetPiece(PieceType.King, PieceColor.White));
            Add(Coordinate.GetInstance(7, 5), PieceFactory.GetPiece(PieceType.Bishop, PieceColor.White));
            Add(Coordinate.GetInstance(7, 6), PieceFactory.GetPiece(PieceType.Knight, PieceColor.White));
            Add(Coordinate.GetInstance(7, 7), PieceFactory.GetPiece(PieceType.Rook, PieceColor.White));

            for (int i = 0; i < 8; i++)
            {
                Add(Coordinate.GetInstance(1, i), PieceFactory.GetPiece(PieceType.Pawn, PieceColor.Black));
                Add(Coordinate.GetInstance(6, i), PieceFactory.GetPiece(PieceType.Pawn, PieceColor.White));
            }
        }

        public override void Move(Coordinate source, Coordinate destination)
        {
            // rocada
            if ((this[source] is King rocada) && !rocada.Moved) 
            {
                if (destination.Y == source.Y - 2) // rocada mare
                {
                    if (this[source].Color == PieceColor.Black) 
                    {
                        Add(Coordinate.GetInstance(0, 3), this[Coordinate.GetInstance(0,0)]);
                        Remove(Coordinate.GetInstance(0, 0));
                    } 
                    else
                    {
                        Add(Coordinate.GetInstance(7, 3), this[Coordinate.GetInstance(7, 0)]);
                        Remove(Coordinate.GetInstance(7, 0));
                    }
                } 
                else if (destination.Y == source.Y + 2) // rocada mica
                {
                    if (this[source].Color == PieceColor.Black)
                    {
                        Add(Coordinate.GetInstance(0, 5), this[Coordinate.GetInstance(0, 7)]);
                        Remove(Coordinate.GetInstance(0, 7));
                    }
                    else
                    {
                        Add(Coordinate.GetInstance(7, 5), this[Coordinate.GetInstance(7, 7)]);
                        Remove(Coordinate.GetInstance(7, 7));
                    }
                }   
            }

            if (this[source] is Rook rook) // pentru rocada marcam TURA ca s-a miscat deci nu se mai poate efectua
            {
                rook.Moved = true;
            }

            if (this[source] is King king) // pentru rocada marcam REGELE ca s-a miscat deci nu se mai poate efectua
            {
                king.Moved = true;
            }

            if (ContainsKey(destination))
            {
                Remove(destination);
                Add(Coordinate.GetInstance(destination.X, destination.Y), this[source]);
                Remove(source);

            } 
            else
            {
                Add(Coordinate.GetInstance(destination.X, destination.Y), this[source]);
                Remove(source);
            }
        }

        public override void TestMove(Coordinate source, Coordinate destination)
        {
            // rocada
            if ((this[source] is King rocada) && !rocada.Moved)
            {
                if (destination.Y == source.Y - 2) // rocada mare
                {
                    if (this[source].Color == PieceColor.Black)
                    {
                        Add(Coordinate.GetInstance(0, 3), this[Coordinate.GetInstance(0, 0)]);
                        Remove(Coordinate.GetInstance(0, 0));
                    }
                    else
                    {
                        Add(Coordinate.GetInstance(7, 3), this[Coordinate.GetInstance(7, 0)]);
                        Remove(Coordinate.GetInstance(7, 0));
                    }
                }
                else if (destination.Y == source.Y + 2) // rocada mica
                {
                    if (this[source].Color == PieceColor.Black)
                    {
                        Add(Coordinate.GetInstance(0, 5), this[Coordinate.GetInstance(0, 7)]);
                        Remove(Coordinate.GetInstance(0, 7));
                    }
                    else
                    {
                        Add(Coordinate.GetInstance(7, 5), this[Coordinate.GetInstance(7, 7)]);
                        Remove(Coordinate.GetInstance(7, 7));
                    }
                }

            }

            if (this.ContainsKey(destination))
            {
                Remove(destination);
                Add(Coordinate.GetInstance(destination.X, destination.Y), this[source]);
                Remove(source);
            }
            else
            {
                Add(Coordinate.GetInstance(destination.X, destination.Y), this[source]);
                Remove(source);
            }
        }

        public static bool IsKingInCheck(Context tempContext)
        {
            foreach (var piece in tempContext.Layout)
            {
                if (piece.Value.Color != tempContext.CurrentPlayerColor)
                {
                    List<Coordinate> currentPieceAvailableMoves = piece.Value.GetAvailableMoves(tempContext, piece.Key);

                    foreach (Coordinate availableMove in currentPieceAvailableMoves)
                    {
                        if (tempContext.Layout.ContainsKey(availableMove)
                            && tempContext.Layout[availableMove] is King tempKing
                            && tempKing.Color == tempContext.CurrentPlayerColor)
                        {
                            tempKing.IsInCheck = true;
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public static void ClearCheckMark(Context CurrentContext)
        {
            foreach (var piece in CurrentContext.Layout)
            {
                if (piece.Value is King king)
                {
                    king.IsInCheck = false;
                }
            }
        }

        public static void TransformPawn(Context CurrentContext, Coordinate pawnCoordinates)
        {
            CurrentContext.Layout.Remove(pawnCoordinates);

            if (pawnCoordinates.X == 0)
            {
                CurrentContext.Layout.Add(pawnCoordinates, PieceFactory.GetPiece(PieceType.Queen, PieceColor.White));
            }
            else if (pawnCoordinates.X == 7)
            {
                CurrentContext.Layout.Add(pawnCoordinates, PieceFactory.GetPiece(PieceType.Queen, PieceColor.Black));
            }
        }
        public override Layout Clone()
        {
            ChessLayout clonedLayout = new ChessLayout();

            foreach (var kvp in this)
            {
                Coordinate key = kvp.Key;
                APiece value = kvp.Value;
                clonedLayout.Add(key, value);
            }

            return clonedLayout;
        }
    }
}
