using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLPractice2.Configuration
{
    internal static class AppConfiguration
    {
        public static string XmlFilePath => Path.Combine(
            Directory.GetCurrentDirectory(), 
            "contacts.xml"
        );
    }
}
