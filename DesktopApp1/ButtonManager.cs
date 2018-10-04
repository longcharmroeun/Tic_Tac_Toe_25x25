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
        public Button[,] button;
        public ButtonManager(Form1 form)
        {
            Random = new Random();
            int x = 0, y = 1, index = 0;
            button = new Button[Size,Size];
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    this.button[i,j] = new System.Windows.Forms.Button();
                    this.button[i,j].Location = new System.Drawing.Point(x, y);
                    this.button[i,j].Size = new System.Drawing.Size(30, 30);
                    this.button[i, j].TabIndex = index;
                    this.button[i,j].UseVisualStyleBackColor = true;
                    this.button[i, j].Click += ButtonManager_Click;
                    form.Controls.Add(button[i,j]);
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
            int x = Random.Next(0, 25);
            int y = Random.Next(0, 25);
            if (!(IsUsed(button[x, y].TabIndex)))
            {
                button[x, y].Image = Image.FromFile(@"..\..\Image\cross.png");
                EnermyClick(button[x, y].TabIndex);
                if (IsEnermyWin())
                {
                    MessageBox.Show("You lost");
                }
            }
        }
        
    }
}
