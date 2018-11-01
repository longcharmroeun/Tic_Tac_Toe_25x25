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
        private Data.FirstData FirstData;

        public MainForm(Data.User user,Data.FirstData firstData)
        {
            InitializeComponent();
            this.user = user;
            this.FirstData = firstData;
        }

        private void PvAI_Click(object sender, EventArgs e)
        {
            using(Form1 form = new Form1())
            {
                this.Hide();
                form.ShowDialog();
                this.Close();
            }
        }

        private void signout_Click(object sender, EventArgs e)
        {
            Data.FirstData firstData = new Data.FirstData();
            firstData.User = null;
            firstData.Password = null;
            Data.FirstDataSerializingXML.SerializingXML(firstData);
            LoginSignup.LoginForm sign = new LoginSignup.LoginForm(user);
            this.Hide();
            sign.ShowDialog();
            this.Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            playername.Text = FirstData.FullName;
            if (FirstData.Patch == null) MessageBox.Show("Could Finde Image.");
            else pictureBox1.Image = Image.FromFile(FirstData.Patch);
            win.Text = FirstData.Win.ToString();
            lose.Text = FirstData.Lose.ToString();
            gold.Text = FirstData.Gold.ToString();
            money.Text = FirstData.Money.ToString();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
