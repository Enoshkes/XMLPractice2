using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XMLPractice2.Model
{
    internal record Contact
    {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("phone")]
        public string Phone { get; set; }

        public Contact(string name, string phone)
        {
            Name = name;
            Phone = phone;
        }
    }
}
