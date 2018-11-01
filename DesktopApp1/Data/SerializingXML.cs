using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;

namespace Tic_Tac_Toe_25x25.Data
{
    static class SerializingXML
    {
        public static void Serializing(User user)
        {
            XmlSerializer xml = new XmlSerializer(typeof(User));
            using (FileStream fs = new FileStream(@"UserData/XmlData/Data.xml", FileMode.Create))
            {
                xml.Serialize(fs, user);
            }
        }

        public static void DeSerializing(ref User user)
        {
            try
            {
                using (var reader = new StreamReader(@"UserData/XmlData/Data.xml"))
                {
                    XmlSerializer deserializer = new XmlSerializer(typeof(User),
                        new XmlRootAttribute("User"));
                    user = (User)deserializer.Deserialize(reader);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
