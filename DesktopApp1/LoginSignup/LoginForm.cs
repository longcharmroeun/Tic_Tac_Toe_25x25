using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe_25x25.LoginSignup
{
    public partial class LoginForm : Form
    {
        private Data.User user;
        private Properties.Settings Settings;
        public LoginForm(Data.User user)
        {
            InitializeComponent();
            this.user = user;
            Settings = new Properties.Settings();
        }

        private bool IsLogin()
        {
            for (int i = 0; i < user.DataList.Count; i++)
            {
                if (textBox1.Text == user.DataList.ElementAt(i).User)
                {
                    if (textBox2.Text == user.DataList.ElementAt(i).Password)
                    {
                        Settings.Index = i;
                        Settings.User = user.DataList.ElementAt(i).User;
                        Settings.Password = user.DataList.ElementAt(i).Password;
                        Settings.Save();

                        using (MainForm form = new MainForm(user, i))
                        {
                            this.Hide();
                            form.ShowDialog();
                            this.Close();
                            return true;
                        }
                    }
                    else MessageBox.Show("Password not Match.");
                }
            }
            return false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUp sign = new SignUp(user);
            this.Hide();
            sign.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!IsLogin())
            {
                MessageBox.Show("User not found!");
            }        
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) textBox2.Focus();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) button1.PerformClick();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            Data.SerializingXML.DeSerializing(ref user);
        }
    }
}
