using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Tic_Tac_Toe_25x25.Data
{
    [XmlRoot("User")]
    public class Data
    {
        public string User { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public DateTime DateBirth { get; set; }
        public string Sex { get; set; }
        public string Patch { get; set; }
        public int Win { get; set; }
        public int Lose { get; set; }
        public int Money { get; set; }
        public int Gold { get; set; }
    }
}
