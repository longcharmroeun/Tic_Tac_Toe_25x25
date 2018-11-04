using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace Tic_Tac_Toe_25x25
{
    public partial class Form1 : Form
    {
        ButtonManager manager;
        public Form1(Data.User user, int Index)
        {
            InitializeComponent();
            manager = new ButtonManager(this, user, Index);
        }

        public Form1(Data.User user, int Index,int Replayindex)
        {
            InitializeComponent();
            manager = new ButtonManager(this, user, Index, Replayindex);
        }
    }
}
