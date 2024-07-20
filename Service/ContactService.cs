using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using XMLPractice2.Model;
using static XMLPractice2.Configuration.AppConfiguration;

namespace XMLPractice2.Service
{
    internal static class ContactService
    {
        public static void CreateXmlFileIfNotExistsAppend()
        {
            if (!File.Exists(XmlFilePath))
            {
                XmlDocument document = new();
                XmlNode rootNode = document.CreateElement("Contacts");
                document.AppendChild(rootNode);
                document.Save(XmlFilePath);
            }
        }

        public static void CreateXmlFileIfNotExistsParse()
        {
            if (!File.Exists(XmlFilePath))
            {
                XDocument document = XDocument.Parse(@"
                    <Contacts>
                    </Contacts>
                ");
                document.Save(XmlFilePath);
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

        public static ImmutableList<Contact> GetAllContacts() =>
            XDocument.Load(XmlFilePath)
                .Descendants("Contact")
                .Select(node => new Contact(
                    name: node.Element("Name")?.Value ?? string.Empty,
                    phone: node.Element("Phone")?.Value ?? string.Empty
                ))
                .ToImmutableList() ?? [];

        public static ImmutableList<Contact> AddContactX(Contact newContact)
        {
            var document = XDocument.Load(XmlFilePath);

            document.Root?.Add(
                new XElement("Contact",
                    new XElement("Name", newContact.Name),
                    new XElement("Phone", newContact.Phone)
                )
            );

            document.Save(XmlFilePath);

            return GetAllContacts();
        }

        public static ImmutableList<Contact> AddContactY(Contact newContact)
        {
            var document = XDocument.Load(XmlFilePath);

            var root = document.Descendants("Contacts").FirstOrDefault();

            if (root == null)
            {
                return [];
            }

            root.Add(
                new XElement("Contact",
                    new XElement("Name", newContact.Name),
                    new XElement("Phone", newContact.Phone)
                )
            );

            document.Save(XmlFilePath);

            return GetAllContacts();
        }
    }
}
