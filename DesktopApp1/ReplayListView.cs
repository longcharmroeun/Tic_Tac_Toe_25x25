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
    public partial class ReplayListView : Form
    {
        private Data.User user;
        private int index;
        public ReplayListView(Data.User user, int index)
        {
            InitializeComponent();

            this.user = user;
            this.index = index;

            for (int i = 0; i < user.DataList.ElementAt(index).Replays.Count; i++)
            {
                listView1.Items.Add(new ListViewItem(new[] { user.DataList.ElementAt(index).Replays.ElementAt(i).ReplayDate.ToShortDateString(), user.DataList.ElementAt(index).Replays.ElementAt(i).ReplayDate.ToLongTimeString() }));
            }
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Form1 form = new Form1(user, index, listView1.SelectedIndices[0]);
                this.Hide();
                form.ShowDialog();
                this.Show();
            }
            else if (e.Button == MouseButtons.Right && listView1.SelectedIndices[0] >= 0 && listView1.SelectedIndices[0] < user.DataList.ElementAt(index).Replays.Count) 
            {
                contextMenuStrip1.Show(listView1, e.Location);
            }
        }
        
        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            user.DataList[index].Replays.RemoveAt(listView1.SelectedIndices[0]);
            listView1.Items.RemoveAt(listView1.SelectedIndices[0]);
        }

        private void removeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Are you sure.", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(dialog == DialogResult.Yes)
            {
                user.DataList.ElementAt(index).Replays.RemoveRange(0, user.DataList.ElementAt(index).Replays.Count);
                listView1.Items.Clear();
            }
        }
    }
}
