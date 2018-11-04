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
    public partial class MainForm : Form
    {
        private Data.User user;
        private int Index;

        public MainForm(Data.User user, int Index)
        {
            InitializeComponent();
            this.user = user;
            this.Index = Index;
        }

        private void PvAI_Click(object sender, EventArgs e)
        {
            using (Form1 form = new Form1(user, Index)) 
            {
                this.Hide();
                form.ShowDialog();
                this.Close();
            }
        }

        private void signout_Click(object sender, EventArgs e)
        {
            Properties.Settings settings = new Properties.Settings();
            settings.Index = -1;
            settings.Save();
            LoginSignup.LoginForm sign = new LoginSignup.LoginForm(user);
            this.Hide();
            sign.ShowDialog();
            this.Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            playername.Text = user.DataList.ElementAt(Index).FullName;
            if (user.DataList.ElementAt(Index).Patch == null) 
            {
                if(user.DataList.ElementAt(Index).Sex == "Male") pictureBox1.Image = Image.FromFile(@"../../UserImage/MaleAvatar.jpg");
                else pictureBox1.Image = Image.FromFile(@"../../UserImage/FamleAvatar.jpg");
            }

            else pictureBox1.Image = Image.FromFile(user.DataList.ElementAt(Index).Patch);

            win.Text = user.DataList.ElementAt(Index).Win.ToString();
            lose.Text = user.DataList.ElementAt(Index).Lose.ToString();
            gold.Text = user.DataList.ElementAt(Index).Gold.ToString();
            money.Text = user.DataList.ElementAt(Index).Money.ToString();
        }

        private void Replaytdata_Click(object sender, EventArgs e)
        {
            ReplayListView replayList = new ReplayListView(user, Index);
            replayList.Show();
        }
    }
}
