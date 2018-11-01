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
            Data.FirstData firstData = new Data.FirstData();
            Data.FirstDataSerializingXML.DeSerializingXML(ref firstData);
            Data.User user = new Data.User();
            Data.SerializingXML.DeSerializing(ref user);
            if(user.DataList != null)
            {
                for (int i = 0; i < user.DataList.Count; i++)
                {
                    if (firstData.User == user.DataList.ElementAt(i).User && firstData.Password == user.DataList.ElementAt(i).Password)
                    {
                        Application.Run(new MainForm(user, firstData));
                        Application.Exit();
                    }
                }
            }
            else if(user.DataList == null)
            {
                MessageBox.Show("Could not found data.");
                Application.Run(new LoginSignup.LoginForm(user));
                Application.Exit();
            }
            if (firstData.User == null) 
            {
                MessageBox.Show("Could Not Loging.");
                Application.Run(new LoginSignup.LoginForm(user));
                Application.Exit();
            }           
        }
    }
}
