using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class JsonData
    {
        public List<UpdatedData> Table { get; set; }

        public PieceColor CurrentPlayerColor { get; set; }
    }
}
