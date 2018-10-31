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
    static class FirstDataSerializingXML
    {
        public static void SerializingXML(FirstData data)
        {
            FileStream fs = null;
            XmlSerializer xs = new XmlSerializer(typeof(FirstData));

            using (fs = new FileStream("FirstData.xml", FileMode.Create))
            {
                xs.Serialize(fs, data);
            }
        }

        public static void DeSerializingXML(ref FirstData data)
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(FirstData));
                using (FileStream fs = new FileStream("FirstData.xml", FileMode.Open))
                {
                    data = xs.Deserialize(fs) as FirstData;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
