using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe_25x25
{
    class ButtonManager
    {
        Array2D Array = new Array2D(25);
        private Random Random;
        public Button[] button;
        public ButtonManager(Form1 form)
        {
            Array.PeopleNearWinEvent += Array_PeopleNearWinEvent;
            Array.WinEvent += Array_WinEvent;
            Array.EnermyEvent += Array_EnermyEvent;
            Random = new Random();
            int x = 0, y = 1, index = 0;
            button = new Button[Array.Count];
            for (int i = 0; i < Array.Size; i++)
            {
                for (int j = 0; j < Array.Size; j++)
                {
                    this.button[index] = new System.Windows.Forms.Button();
                    this.button[index].Location = new System.Drawing.Point(x, y);
                    this.button[index].Size = new System.Drawing.Size(30, 30);
                    this.button[index].TabIndex = index;
                    //this.button[index].Text = index.ToString();
                    this.button[index].UseVisualStyleBackColor = true;
                    this.button[index].Click += ButtonManager_Click;
                    form.Controls.Add(button[index]);
                    x += 30;
                    index++;
                }
                y += 30;
                x = 0;
            }
        }

        private void Array_PeopleNearWinEvent(object sender, PeopleNearWinEventArgs e)
        {
            if (!(Array.IsUsed(e.FirstIndex)) && !Array.IsOutBound(e.FirstIndex))
            {
                button[e.FirstIndex].Image = Image.FromFile(@"..\..\Image\cross.png");
                Array.EnermyClick(e.FirstIndex);
            }
            else if (!(Array.IsUsed(e.LastIndex)) && !Array.IsOutBound(e.LastIndex))
            {
                button[e.LastIndex].Image = Image.FromFile(@"..\..\Image\cross.png");
                Array.EnermyClick(e.LastIndex);
            }
        }

        private void Array_EnermyEvent(object sender, EnermyEventArgs e)
        {
            while (true)
            {
                int index = Random.Next(0, Array.Count);
                if (!(Array.IsUsed(index)))
                {
                    button[index].Image = Image.FromFile(@"..\..\Image\cross.png");
                    Array.EnermyClick(index);
                    break;
                }
            }
        }

        private void ButtonManager_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (!Array.IsUsed(button.TabIndex))
            {
                button.Image = Image.FromFile(@"..\..\Image\circle.png");
                Array.PeopleClick(button.TabIndex);
            }
        }

        private void Array_WinEvent(object sender, WinEventArgs e)
        {
            if (e.IsPeoPleWin)
            {
                for (int i = 0; i < e.WinIndex.Length; i++)
                {
                    button[e.WinIndex[i]].BackColor = Color.Green;
                }
            }
            else if (e.IsEnermyWin)
            {
                for (int i = 0; i < e.WinIndex.Length; i++)
                {
                    button[e.WinIndex[i]].BackColor = Color.Green;
                }
            }
        }
        
    }
}
