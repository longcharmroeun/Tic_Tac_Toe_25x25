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
            bool IsMainForm = false;
            for (int i = 0; i < user.DataList.Count; i++)
            {
                if(firstData.User == user.DataList.ElementAt(i).User&&firstData.Password == user.DataList.ElementAt(i).Password)
                {
                    IsMainForm = true;
                    Application.Run(new MainForm(user,firstData));
                }
            }
            if (!IsMainForm)
            {
                MessageBox.Show("Could Not Loging.");
                Application.Run(new LoginSignup.LoginForm(user));
            }
        }
    }
}
