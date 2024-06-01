using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class ContextChangedEventArgs : EventArgs
    {
        public Context NewContext { get; set;  }

        public ContextChangedEventArgs(Context newContext)
        {
            this.NewContext = newContext;
        }


    }
}
