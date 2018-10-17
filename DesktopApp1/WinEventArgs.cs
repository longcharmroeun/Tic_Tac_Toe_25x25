using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe_25x25
{
    class WinEventArgs : EventArgs
    {
        public bool IsPeoPleWin { get; set; }
        public bool IsEnermyWin { get; set; }
    }

}
