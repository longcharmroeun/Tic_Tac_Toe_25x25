using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using Tic_Tac_Toe_25x25.Properties;

namespace Tic_Tac_Toe_25x25
{
    public partial class MainForm : Form
    {
        private Data.User user;
        private int Index;
        private ReplayListView ReplayList;

        public MainForm(Data.User user, int Index)
        {
            InitializeComponent();
            this.user = user;
            this.Index = Index;
            ReplayList = new ReplayListView(user, Index);
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

        private void Signout_Click(object sender, EventArgs e)
        {
            Settings.Default.User = null;
            Settings.Default.Password = null;
            Settings.Default.Save();
            LoginSignup.LoginForm sign = new LoginSignup.LoginForm(user);
            this.Hide();
            sign.ShowDialog();
            this.Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SoundPlayer sound = new SoundPlayer(Properties.Resources.Charlie_Puth___How_Long__Official_Video_);
            sound.Play();
            playername.Text = user.DataList.ElementAt(Index).FullName;
            if (user.DataList.ElementAt(Index).Patch == null) 
            {
                if (user.DataList.ElementAt(Index).Sex == "Male") pictureBox1.Image = Properties.Resources.MaleAvatar;
                else pictureBox1.Image = Properties.Resources.FamleAvatar;
            }

            else pictureBox1.Image = Image.FromFile(user.DataList.ElementAt(Index).Patch);

            win.Text = user.DataList.ElementAt(Index).Win.ToString();
            lose.Text = user.DataList.ElementAt(Index).Lose.ToString();
            gold.Text = user.DataList.ElementAt(Index).Gold.ToString();
            money.Text = user.DataList.ElementAt(Index).Money.ToString();
        }

        private void Replaytdata_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms[ReplayList.Name] == null)
            {
                ReplayList.Show();
                ReplayList.Disposed += ReplayList_Disposed;
            }
            else
            {
                SystemSounds.Beep.Play();
                Application.OpenForms[ReplayList.Name].Focus();
            }
        }

        private void ReplayList_Disposed(object sender, EventArgs e)
        {
            ReplayList = new ReplayListView(user, Index);
        }
    }
}
