using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            Properties.Settings settings = new Properties.Settings();
            Data.User user = new Data.User();
            Data.SerializingXML.DeSerializing(ref user);

            if (settings.Index < 0)
            {
                MessageBox.Show("Could Not Loging.");
                Application.Run(new LoginSignup.LoginForm(user));
                Application.Exit();
            }
            else if(user.DataList != null)
            {
                for (int i = 0; i < user.DataList.Count; i++)
                {
                    if (user.DataList.ElementAt(settings.Index).User == user.DataList.ElementAt(i).User && user.DataList.ElementAt(settings.Index).Password == user.DataList.ElementAt(i).Password)
                    {
                        Application.Run(new MainForm(user, settings.Index));
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
        }
    }
}
