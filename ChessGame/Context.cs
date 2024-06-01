using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class Context
    {
        public Layout Layout { get; set; }
        public PieceColor CurrentPlayerColor { get; set; }

        public Context Clone()
        {
            Context clone = new Context();
            clone.Layout = Layout.Clone();
            clone.CurrentPlayerColor = CurrentPlayerColor;

            return clone;
        }
    }
}
