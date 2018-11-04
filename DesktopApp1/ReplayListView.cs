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

        private void listView1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1(user, index, listView1.SelectedIndices[0]);
            form.ShowDialog();
        }
    }
}
