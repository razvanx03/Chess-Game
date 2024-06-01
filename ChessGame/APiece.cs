using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace ChessGame
{
    public abstract class APiece
    {
        public PieceType Type { get; private set; }
        public PieceColor Color { get; private set; }

        protected Bitmap PieceImages = new Bitmap(Assembly.GetExecutingAssembly().GetManifestResourceStream("ChessGame.Resources.ChessPiecesArray.png"));

        protected static Dictionary<(PieceType, PieceColor), Image> images = new Dictionary<(PieceType, PieceColor), Image>();

        public APiece(PieceColor color, PieceType type)
        {
            Color = color;
            Type = type;
        }

        public abstract List<Coordinate> GetAvailableMoves(Context context, Coordinate CurrentCoordinate);

        public Image GetImage()
        {
            if (!images.ContainsKey((Type, Color))) 
            {
                images.Add((Type, Color), PieceImages.Clone(new Rectangle(PieceImages.Width / 6 * (int)Type, (int)Color * PieceImages.Height / 2, PieceImages.Width / 6, PieceImages.Height / 2), PieceImages.PixelFormat));
            }

            return images[(Type, Color)];
        }

        public override string ToString()
        {
            return $"{Type} ({Color})";
        }
    }
}
