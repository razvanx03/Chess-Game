using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class DataAdaptor
    {
        public List<UpdatedData> Table { get; set; }

        public PieceColor CurrentPlayerColor { get; set; }

        public DataAdaptor(Context context) 
        {
            Table = new List<UpdatedData>();
            
            CurrentPlayerColor = context.CurrentPlayerColor;

            TransformData(context);
        }

        private void TransformData(Context context)
        {
            foreach (var piece in context.Layout) 
            {
                UpdatedData newData = new UpdatedData();

                newData.Coordinates.Add(new CoordinatesAdaptor(piece.Key.X, piece.Key.Y));

                newData.Pieces.Add(new APieceAdaptor(piece.Value.Type, piece.Value.Color));

                Table.Add(newData);
            }
        }
    }
}
