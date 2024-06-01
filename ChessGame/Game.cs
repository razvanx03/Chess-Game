using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ChessGame
{
    public abstract class Game
    {
        public abstract void Initialise(Board board);
        public abstract void Start();

        public abstract void LoadFromFile(JsonData fileData);
    }
}
