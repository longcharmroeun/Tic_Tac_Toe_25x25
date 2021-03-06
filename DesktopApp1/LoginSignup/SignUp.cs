﻿using System;
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
    public partial class SignUp : Form
    {
        private Data.User user;
        private Data.Data data = new Data.Data();
        public SignUp(Data.User user)
        {
            InitializeComponent();
            this.user = user;
            System.IO.Directory.CreateDirectory("UserData");
            System.IO.Directory.CreateDirectory(@"UserData/PlayerImage");
            System.IO.Directory.CreateDirectory(@"UserData/XmlData");
        }

        private bool IsUserUsed()
        {
            if (user.DataList != null)
            {
                for (int i = 0; i < user.DataList.Count; i++)
                {
                    if (User.Text == user.DataList.ElementAt(i).User)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IsUserUsed()) MessageBox.Show("This User already Used.");

            else if (Password.Text == RPassword.Text && Password.Text != string.Empty && RPassword.Text != string.Empty && FName.Text != string.Empty)
            {
                try
                {
                    if (user.DataList == null)
                    {
                        System.IO.File.Copy(data.Patch, $"UserData\\PlayerImage\\PlayerImage0");
                        data.Patch = $"UserData\\PlayerImage\\PlayerImage0";
                        pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                    }
                    else
                    {
                        System.IO.File.Copy(data.Patch, $"UserData\\PlayerImage\\PlayerImage{user.DataList.Count}");
                        data.Patch = $"UserData\\PlayerImage\\PlayerImage{user.DataList.Count}";
                        pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                data.FullName = FName.Text;
                data.DateBirth = Bdate.Value;
                data.User = User.Text;
                data.Password = Password.Text;
                data.Lose = 0;
                data.Win = 0;
                data.Money = 1000;
                data.Gold = 200;
                if (male.Checked)
                {
                    data.Sex = male.Text;
                }
                else if (famale.Checked)
                {
                    data.Sex = famale.Text;
                }
                else MessageBox.Show("Please choose a gender.");
                if (user.DataList == null)
                {
                    user.DataList = new List<Data.Data>();
                }
                user.DataList.Add(data);
                Data.SerializingXML.Serializing(user);
                LoginForm login = new LoginForm(user);
                this.Hide();
                login.ShowDialog();
                this.Close();
            }

            else MessageBox.Show("Password Not Match.");
        }

        private void FName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) Bdate.Focus();
        }

        private void Bdate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) User.Focus();
        }

        private void Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) RPassword.Focus();
        }

        private void RPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) male.Focus();
        }

        private void User_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) Password.Focus();
        }

        private void SignUp_Load(object sender, EventArgs e)
        {
            FName.Focus();
        }

        private void male_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) button1.PerformClick();
        }

        private void famale_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) button1.PerformClick();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm(user);
            this.Hide();
            login.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    data.Patch = openFileDialog1.FileName;
                    pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}
