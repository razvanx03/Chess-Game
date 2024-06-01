using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChessGame.Properties;
using Newtonsoft.Json;

namespace ChessGame
{
    public class Chess : Game
    {
        private Referee Referee { get; set; }  

        public override void Initialise(Board board)
        {
            board.Initialise();
            Referee = new Referee();

            Referee.ContextChanged += board.OnContextChanged;
            board.MoveProposed += Referee.OnMoveProposed;
        }

        public override void Start()
        {
            Context context = new Context();
            context.Layout = new ChessLayout();
            context.Layout.Initialise();
            context.CurrentPlayerColor = PieceColor.White;
            Referee.Start(context);
        }

        public override void LoadFromFile(JsonData fileData)
        {
            Context context = new Context();
            context.Layout = new ChessLayout();

           // adaugam datele in context.layout
            foreach (var updatedData in fileData.Table)
            {
                for (int i = 0; i < updatedData.Coordinates.Count; i++)
                {
                    CoordinatesAdaptor coordinate = updatedData.Coordinates[i];
                    APieceAdaptor piece = updatedData.Pieces[i];

                    context.Layout.Add(
                        Coordinate.GetInstance(coordinate.X, coordinate.Y),
                        PieceFactory.GetPiece(piece.Type, piece.Color)
                    );
                }
            }
            context.CurrentPlayerColor = fileData.CurrentPlayerColor;
            Referee.Start(context);
        }
    }
}
