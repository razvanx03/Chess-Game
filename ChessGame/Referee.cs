using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class Referee
    {
        public event EventHandler<ContextChangedEventArgs> ContextChanged;
        
        private Context CurrentContext { get; set; }

        public Context CurrentContextProperty
        {
            get
            {
                return CurrentContext;
            }
        }

        public void Start(Context context)
        {
            CurrentContext = context;
            ContextChanged?.Invoke(this, new ContextChangedEventArgs(context.Clone()));
        }

        public void OnMoveProposed(object sender, MoveEventArgs e)
        {
            if (IsValid(e.Move.SourceCoordinate,e.Move.DestinationCoordinate))
            {
                CurrentContext.Layout.Move(e.Move.SourceCoordinate, e.Move.DestinationCoordinate);
                ChessLayout.ClearCheckMark(CurrentContext);

                // in caz ca a ajuns pionul in capatul opus
                if (CurrentContext.Layout[e.Move.DestinationCoordinate] is Pawn && (e.Move.DestinationCoordinate.X == 0 || e.Move.DestinationCoordinate.X == 7)) 
                {
                    ChessLayout.TransformPawn(CurrentContext, e.Move.DestinationCoordinate);
                }

                ChangePlayer();
                ChessLayout.IsKingInCheck(CurrentContext);
                ContextChanged?.Invoke(this, new ContextChangedEventArgs(CurrentContext.Clone()));
            }
        }

        private bool IsValid(Coordinate source, Coordinate destination)
        {
            if (!CurrentContext.Layout[source].GetAvailableMoves(CurrentContext, source).Contains(destination))
            {
                return false;
            }

            Context tempContext = CurrentContext.Clone();
            tempContext.Layout.TestMove(source, destination);

            if (ChessLayout.IsKingInCheck(tempContext))
                return false;

            return true;
        }

        // mutate in ChessLayout.cs

        //private bool IsKingInCheck(Context tempContext)
        //{
        //    foreach (var piece in tempContext.Layout)
        //    {
        //        if (piece.Value.Color != tempContext.CurrentPlayerColor)
        //        {
        //            List<Coordinate> currentPieceAvailableMoves = piece.Value.GetAvailableMoves(tempContext, piece.Key);

        //            foreach (Coordinate availableMove in currentPieceAvailableMoves)
        //            {
        //                if (tempContext.Layout.ContainsKey(availableMove)
        //                    && tempContext.Layout[availableMove] is King tempKing
        //                    && tempKing.Color == tempContext.CurrentPlayerColor)
        //                {
        //                    tempKing.IsInCheck = true;
        //                    return true;
        //                }
        //            }
        //        }
        //    }
        //    return false;
        //}

        //private void ClearCheckMark() 
        //{ 
        //    foreach(var piece in CurrentContext.Layout)
        //    {
        //        if (piece.Value is King king)
        //        {
        //            king.IsInCheck = false;
        //        }
        //    }
        //}

        //private void TransformPawn(Coordinate pawnCoordinates)
        //{
        //    CurrentContext.Layout.Remove(pawnCoordinates);

        //    if (pawnCoordinates.X == 0)
        //    {
        //        CurrentContext.Layout.Add(pawnCoordinates, PieceFactory.GetPiece(PieceType.Queen, PieceColor.White)); 
        //    } 
        //    else if (pawnCoordinates.X == 7) 
        //    {
        //        CurrentContext.Layout.Add(pawnCoordinates, PieceFactory.GetPiece(PieceType.Queen, PieceColor.Black));
        //    }
        //}

        private void ChangePlayer()
        {
            if (CurrentContext.CurrentPlayerColor == PieceColor.White)
            {
                CurrentContext.CurrentPlayerColor = PieceColor.Black;
            }
            else CurrentContext.CurrentPlayerColor = PieceColor.White;
        }
    }
}
