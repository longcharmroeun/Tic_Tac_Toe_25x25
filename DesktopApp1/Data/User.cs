using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Tic_Tac_Toe_25x25.Data
{
    public class User
    {
        [XmlArray("Security"), XmlArrayItem(typeof(Data), ElementName = "Data")]
        public List<Data> DataList { get; set; }
    }
}
