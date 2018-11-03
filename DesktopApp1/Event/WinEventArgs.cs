using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe_25x25.Event
{
    class WinEventArgs : EventArgs
    {
        public bool IsPeoPleWin { get; set; }
        public bool IsEnermyWin { get; set; }
        public int[] WinIndex { get; set; }
        public WinEventArgs()
        {
            WinIndex = new int[5];
            IsPeoPleWin = false;
            IsEnermyWin = false;
        }
    }

}
