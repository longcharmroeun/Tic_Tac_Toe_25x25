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
    class ButtonManager:Array2D
    {
        private Random Random;
        public Button[] button;
        public ButtonManager(Form1 form)
        {
            Random = new Random();
            int x = 0, y = 1, index = 0;
            button = new Button[Count];
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    this.button[index] = new System.Windows.Forms.Button();
                    this.button[index].Location = new System.Drawing.Point(x, y);
                    this.button[index].Size = new System.Drawing.Size(30, 30);
                    this.button[index].TabIndex = index;
                    this.button[index].Text = index.ToString();
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

        private void ButtonManager_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (!IsUsed(button.TabIndex))
            {
                button.Image = Image.FromFile(@"..\..\Image\circle.png");
                PeopleClick(button.TabIndex);
                if (IsPeopleWin())
                {
                    MessageBox.Show("You Win");
                }
                EnermyClick();
            }
        }
        
        private void EnermyClick()
        {
            while (true)
            {
                int index = Random.Next(0, 625);
                if (!(IsUsed(index)))
                {
                    if (Is3Or4Used(out int First, out int Last))
                    {
                        if (!(IsUsed(First)))
                        {
                            button[First].Image = Image.FromFile(@"..\..\Image\cross.png");
                            EnermyClick(First);
                        }
                        else if (!(IsUsed(Last)))
                        {
                            button[Last].Image = Image.FromFile(@"..\..\Image\cross.png");
                            EnermyClick(Last);
                            break;
                        }
                    }
                    button[index].Image = Image.FromFile(@"..\..\Image\cross.png");
                    EnermyClick(index);
                    if (IsEnermyWin())
                    {
                        MessageBox.Show("You lost");
                    }
                    break;
                }
            }
        }
        
    }
}
