using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe_25x25.Event
{
    class EnermyEventArgs : EventArgs
    {
        public int[] Index { get; set; }
        internal void Size(int index = 8)
        {
            this.Index = new int[index];
        }
    }
}
