using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Media;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ChessGame
{
    public class Board : Panel
    {
        private int CellSize { get; set; }

        private Context Context { get; set; }

        private Coordinate CurrentCoordinate { get; set; }

        public event EventHandler<MoveEventArgs> MoveProposed;

        private new Coordinate MouseDown { get; set; }

        private new Coordinate MouseUp { get; set; }

        private bool isMouseDown = false;

        private readonly SoundPlayer NormalSound = new SoundPlayer(Assembly.GetExecutingAssembly().GetManifestResourceStream("ChessGame.Resources.normal_move.wav"));

        private readonly SoundPlayer CaptureSound = new SoundPlayer(Assembly.GetExecutingAssembly().GetManifestResourceStream("ChessGame.Resources.capture.wav"));

        public void Initialise()
        {
            DoubleBuffered = true;
        }

        public Context GetContext()
        {
            return Context;
        }

        public void Rescale(int windowWidth, int windowHeight, int menuHeight)
        {
            int width = windowWidth - 16;
            int height = windowHeight - menuHeight - 39;

            CellSize = Math.Min(width, height) / 8;

            SetBounds((width < height) ? 0 : (width - height) / 2, (width < height) ? (height - width) / 2 + menuHeight : menuHeight, CellSize * 8, CellSize * 8);

            Refresh();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            int x = e.Y / CellSize;
            int y = e.X / CellSize;

            if ((CurrentCoordinate == null || CurrentCoordinate.X != x || CurrentCoordinate.Y != y) && (x <= 7 && x >= 0 && y <= 7 && y >= 0) && !isMouseDown)
            {
                CurrentCoordinate = Coordinate.GetInstance(x, y);
                Refresh();
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            isMouseDown = true;

            if (e.Button == MouseButtons.Left && Context.Layout.ContainsKey(CurrentCoordinate) && Context.Layout[CurrentCoordinate].Color == Context.CurrentPlayerColor)
            {
                MouseDown = CurrentCoordinate;
                Cursor = new Cursor(Icon.FromHandle((Context.Layout[MouseDown].GetImage() as Bitmap).GetHicon()).Handle);
                Refresh();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            isMouseDown = false;
            OnMouseMove(e);

            MouseUp = CurrentCoordinate;
            Cursor = Cursors.Default;

            if (e.Button == MouseButtons.Left && MouseUp != null && MouseDown != null)
            {
                Move move = new Move(MouseDown, MouseUp);

                MoveProposed?.Invoke(this, new MoveEventArgs(move));

                Refresh();
            }

            MouseUp = null;
            MouseDown = null;
        }

        public void OnContextChanged(object sender, ContextChangedEventArgs e)
        {
            if (Context != null && Context.Layout.Count != e.NewContext.Layout.Count)
            {
                CaptureSound.Play();
            } 
            else if (Context != null)
            {
                NormalSound.Play();
            }
            Context = e.NewContext;
            Refresh();
        }

        private void DrawSquares(Graphics g)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                    g.FillRectangle((j + i) % 2 == 0 ? Brushes.LightGoldenrodYellow : Brushes.Sienna, j * CellSize, i * CellSize, CellSize, CellSize);
            }
        }

        private void DrawPieces(Graphics g)
        {
            if (Context != null)
            {
                foreach (Coordinate c in Context.Layout.Keys)
                {
                    if (c == CurrentCoordinate && isMouseDown) // sa nu deseneze piesa din mana
                    {
                        continue;
                    }
                    g.DrawImage(Context.Layout[c].GetImage(), c.Y * CellSize, c.X * CellSize, CellSize, CellSize);
                }
            }
        }

        private void DrawAvailableMoves(Graphics g)
        {
            if (Context != null && CurrentCoordinate != null && Context.Layout.ContainsKey(CurrentCoordinate) && Context.Layout[CurrentCoordinate].Color == Context.CurrentPlayerColor)
            {

                List<Coordinate> availableMoves = Context.Layout[CurrentCoordinate].GetAvailableMoves(Context, CurrentCoordinate);

                // draw
                foreach (Coordinate c in availableMoves)
                {
                    g.DrawRectangle(new Pen(Color.Lime, 5), c.Y * CellSize, c.X * CellSize, CellSize, CellSize);
                }
            }
        }

        private void DrawCheckSquare(Graphics g)
        {
            if (Context != null)
            {
                foreach (var piece in Context.Layout)
                {
                    if (piece.Value is King king && king.IsInCheck == true)
                    {
                        g.DrawRectangle(new Pen(Color.Red, 5), piece.Key.Y * CellSize, piece.Key.X * CellSize, CellSize, CellSize);
                    }
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            DrawSquares(e.Graphics);
            DrawPieces(e.Graphics);
            DrawAvailableMoves(e.Graphics);
            DrawCheckSquare(e.Graphics);
        }
    }
}
