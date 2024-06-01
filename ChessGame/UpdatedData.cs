using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class UpdatedData
    {
        public List<CoordinatesAdaptor> Coordinates { get; set; }
        public List<APieceAdaptor> Pieces { get; set; }

        public UpdatedData()
        {
            Coordinates = new List<CoordinatesAdaptor>();
            Pieces = new List<APieceAdaptor> ();
        }
    }

}
