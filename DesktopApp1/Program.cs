using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tic_Tac_Toe_25x25.Properties;

namespace Tic_Tac_Toe_25x25
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SoundPlayer sound = new SoundPlayer(Properties.Resources.Charlie_Puth___How_Long__Official_Video_);
            sound.Play();

            Data.User user = new Data.User();
            Data.SerializingXML.DeSerializing(ref user);

            if (Settings.Default.User == string.Empty || Settings.Default.Password == string.Empty)
            {
                MessageBox.Show("Could Not Loging.");
                Application.Run(new LoginSignup.LoginForm(user));
                Application.Exit();
            }
            else if (user.DataList != null)
            {
                for (int i = 0; i < user.DataList.Count; i++)
                {
                    if (Settings.Default.User == user.DataList.ElementAt(i).User && Settings.Default.Password == user.DataList.ElementAt(i).Password)
                    {
                        Application.Run(new MainForm(user, i));
                        Application.Exit();
                    }
                }
            }
            else
            {
                MessageBox.Show("Could not found data.");
                Application.Run(new LoginSignup.LoginForm(user));
                Application.Exit();
            }
            Data.SerializingXML.Serializing(user);
        }
    }
}
