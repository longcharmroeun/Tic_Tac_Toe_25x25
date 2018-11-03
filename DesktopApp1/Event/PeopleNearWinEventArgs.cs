using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe_25x25.Event
{
    class PeopleNearWinEventArgs : EventArgs
    {
        public int LastIndex { get; set; }
        public int FirstIndex { get; set; }
    }
}
