using Tic_Tac_Toe_25x25.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tic_Tac_Toe_25x25.Event;

namespace Tic_Tac_Toe_25x25
{
    class ButtonManager
    {
        private Array2D Array;
        private Random Random;
        private readonly Button[] button;
        private readonly Data.User user;
        private readonly int index;
        private readonly List<int> Replay;
        private readonly MessageBoxManager MessageBoxManager;
        private Form1 Form1;
        private readonly Timer timer;
        private int ReplaySum;
        private readonly int Replayindex;

        public ButtonManager(Form1 form, Data.User user, int Index)
        {
            Form1 = form;
            this.user = user;
            this.index = Index;
            Replay = new List<int>();
            MessageBoxManager = new MessageBoxManager();
            Array = new Array2D(25);

            Array.PeopleNearWinEvent += Array_PeopleNearWinEvent;
            Array.WinEvent += Array_WinEvent;
            Array.EnermyEvent += Array_EnermyEvent;
            Array.EnermyNearWinEvent += Array_EnermyNearWinEvent;

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

        public ButtonManager(Form1 form, Data.User user, int Index, int Replayindex)
        {
            this.user = user;
            this.index = Index;
            this.Replayindex = Replayindex;
            Array = new Array2D(25);

            ReplaySum = 0;
            timer = new Timer
            {
                Interval = 1000
            };
            timer.Tick += Timer_Tick;
            timer.Start();

            int x = 0, y = 1, index = 0;
            button = new Button[Array.Count];
            for (int i = 0; i < Array.Size; i++)
            {
                for (int j = 0; j < Array.Size; j++)
                {
                    this.button[index] = new System.Windows.Forms.Button
                    {
                        Location = new System.Drawing.Point(x, y),
                        Size = new System.Drawing.Size(30, 30),
                        TabIndex = index,
                        UseVisualStyleBackColor = true
                    };
                    form.Controls.Add(button[index]);
                    x += 30;
                    index++;
                }
                y += 30;
                x = 0;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (user.DataList[index].Replays.ElementAt(Replayindex).IsPeopleFirst)
            {
                if (ReplaySum % 2 == 0)
                {
                    button[user.DataList[index].Replays.ElementAt(Replayindex).ReplayData.ElementAt(ReplaySum)].Image = Properties.Resources.circle;
                }
                else if (ReplaySum % 2 == 1)
                {
                    button[user.DataList[index].Replays.ElementAt(Replayindex).ReplayData.ElementAt(ReplaySum)].Image = Properties.Resources.cross;
                }
                ReplaySum++;
                if (ReplaySum == user.DataList.ElementAt(index).Replays.ElementAt(Replayindex).ReplayData.Count) 
                {
                    timer.Stop();
                    for (int i = 0; i < user.DataList.ElementAt(index).Replays.ElementAt(Replayindex).WinData.Length; i++)
                    {
                        button[user.DataList.ElementAt(index).Replays.ElementAt(Replayindex).WinData[i]].BackColor = Color.Green;
                    }
                }
            }
        }

        private void Reset()
        {
            for (int i = 0; i < Array.Count; i++)
            {
                button[i].Image = null;
            }
            Array.Reset();
        }

        private void Array_EnermyNearWinEvent(object sender, EnermyNearWinEventArgs e)
        {
            if (!(Array.IsUsed(e.FirstIndex)) && !Array.IsOutBound(e.FirstIndex))
            {
                Replay.Add(e.FirstIndex);
                Replay.Add(e.FirstIndex);
                button[e.FirstIndex].Image = Properties.Resources.cross;
                Array.EnermyClick(e.FirstIndex);
            }
            else if (!(Array.IsUsed(e.LastIndex)) && !Array.IsOutBound(e.LastIndex))
            {
                Replay.Add(e.LastIndex);
                Replay.Add(e.LastIndex);
                button[e.LastIndex].Image = Properties.Resources.cross;
                Array.EnermyClick(e.LastIndex);
            }
        }

        private void Array_PeopleNearWinEvent(object sender, PeopleNearWinEventArgs e)
        {
            if (!(Array.IsUsed(e.FirstIndex)) && !Array.IsOutBound(e.FirstIndex))
            {
                Replay.Add(e.FirstIndex);
                button[e.FirstIndex].Image = Properties.Resources.cross;
                Array.EnermyClick(e.FirstIndex);
            }
            else if (!(Array.IsUsed(e.LastIndex)) && !Array.IsOutBound(e.LastIndex))
            {
                Replay.Add(e.LastIndex);
                button[e.LastIndex].Image = Properties.Resources.cross;
                Array.EnermyClick(e.LastIndex);
            }
        }

        private void Array_EnermyEvent(object sender, EnermyEventArgs e)
        {
            int s = 0;
            do
            {
                s++;
                int i = Random.Next(0, e.Index.Length);
                if (!(Array.IsUsed(e.Index[i]) && !Array.IsOutBound(e.Index[i])))
                {
                    Replay.Add(e.Index[i]);
                    button[e.Index[i]].Image = Properties.Resources.cross;
                    Array.EnermyClick(e.Index[i]);
                    break;
                }
            } while (s <= 20);
            if (s >= 20)
            {
                do
                {
                    int i = Random.Next(0, Array.Count);
                    if (!(Array.IsUsed(i)))
                    {
                        Replay.Add(i);
                        button[i].Image = Properties.Resources.cross;
                        Array.EnermyClick(i);
                        break;
                    }
                } while (true);
            }
        }

        private void ButtonManager_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (!Array.IsUsed(button.TabIndex))
            {
                Replay.Add(button.TabIndex);
                button.Image = Properties.Resources.circle;
                Array.PeopleClick(button.TabIndex);
            }
        }

        private void Array_WinEvent(object sender, WinEventArgs e)
        {
            user.DataList.ElementAt(index).Replays.Add(new Data.Data.Replay { ReplayData = Replay, ReplayDate = DateTime.Now, IsPeopleFirst = true, WinData = e.WinIndex });

            MessageBoxManager.Register();
            MessageBoxManager.Yes = "Play Again";
            MessageBoxManager.No = "Menu";
            MessageBoxManager.Cancel = "Replay";
            DialogResult Win;
            DialogResult Lose;
            
            if (e.IsPeoPleWin)
            {
                for (int i = 0; i < e.WinIndex.Length; i++)
                {
                    button[e.WinIndex[i]].BackColor = Color.Green;
                }
                Win = MessageBox.Show("You Win!", "Info", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                MessageBoxManager.Unregister();
                if (Win == DialogResult.Yes)
                {                   
                    Reset();
                    for (int i = 0; i < e.WinIndex.Length; i++)
                    {
                        button[e.WinIndex[i]].BackColor = Color.FromName("Contol");
                    }
                }
                else if (Win == DialogResult.No)
                {
                    using(MainForm main = new MainForm(user, index))
                    {
                        Form1.Hide();
                        main.ShowDialog();
                        Form1.Close();
                    }
                }
                else if(Win == DialogResult.Cancel)
                {
                    Form1.Hide();
                    Form1 = new Form1(user, index, user.DataList.ElementAt(index).Replays.Count - 1);
                    Form1.ShowDialog();
                }
            }
            else if (e.IsEnermyWin)
            {
                for (int i = 0; i < e.WinIndex.Length; i++)
                {
                    button[e.WinIndex[i]].BackColor = Color.Green;
                }
                Lose = MessageBox.Show("You Lose!", "Info", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                MessageBoxManager.Unregister();
                if (Lose == DialogResult.Yes)
                {
                    Reset();
                    for (int i = 0; i < e.WinIndex.Length; i++)
                    {
                        button[e.WinIndex[i]].BackColor = Color.FromName("Contol");
                    }
                }
                else if (Lose == DialogResult.No)
                {
                    using (MainForm main = new MainForm(user, index))
                    {
                        Form1.Hide();
                        main.ShowDialog();
                        Form1.Close();
                    }
                }
                else if (Lose == DialogResult.Cancel)
                {
                    Form1.Hide();
                    Form1 = new Form1(user, index, user.DataList.ElementAt(index).Replays.Count - 1);
                    Form1.ShowDialog();
                }
            }
        }
    }
}
