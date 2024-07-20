using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using XMLPractice2.Model;
using static XMLPractice2.Configuration.AppConfiguration;

namespace XMLPractice2.Service
{
    internal static class ContactService
    {
        public static void CreateXmlFileIfNotExists()
        {
            if (!File.Exists(XmlFilePath))
            {
                XmlDocument doc = new();
                XmlNode rootNode = doc.CreateElement("Contacts");
                doc.AppendChild(rootNode);
                doc.Save(XmlFilePath);
            }
        }

        public static void AddContact(Contact contact)
        {
            XmlDocument doc = new();

            doc.Load(XmlFilePath);

            XmlNode? rootNode = doc.SelectSingleNode("Contacts");
            if (rootNode == null)
            {
                return;
            }

            XmlNode contactNode = doc.CreateElement("Contact");

            XmlNode nameNode = doc.CreateElement("Name");
            nameNode.InnerText = contact.Name;
            contactNode.AppendChild(nameNode);

            XmlNode phoneNode = doc.CreateElement("Phone");
            phoneNode.InnerText = contact.Phone;
            contactNode.AppendChild(phoneNode);

            rootNode.AppendChild(contactNode);
            doc.Save(XmlFilePath);
        }

        public static ImmutableList<Contact> GetAllContacts()
        {
            XmlDocument doc = new();
            doc.Load(XmlFilePath);

            return doc.SelectNodes("//Contact")?
                .Cast<XmlNode>()
                .Select(node => new Contact(
                    name: node.SelectSingleNode("Name")?.InnerText ?? string.Empty,
                    phone: node.SelectSingleNode("Phone")?.InnerText ?? string.Empty
                ))
                .ToImmutableList() ?? ImmutableList<Contact>.Empty;
        }
    }
}
