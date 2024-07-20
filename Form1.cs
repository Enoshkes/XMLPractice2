using System.Collections.Immutable;
using System.Xml.Linq;
using XMLPractice2.Model;
using static XMLPractice2.Service.ContactService;

namespace XMLPractice2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CreateXmlFileIfNotExistsParse();
            UpdateContacts();
        }

        private void UpdateContacts()
        {
            ContactGridView.DataSource = GetAllContacts();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void AddContactClickHandler(object sender, EventArgs e)
        {
            string name = NameTextBox.Text;
            string phone = PhoneTextBox.Text;
            ImmutableList<string> values = [name, phone];

            if (values.Any(string.IsNullOrWhiteSpace))
            {
                MessageBox.Show("All fields must be filled");
                return;
            }
            var contact = new Contact(name, phone);

            bool isContactExists = (from c in GetAllContacts() where c == contact select c)
                .Any();

            if (isContactExists)
            {
                MessageBox.Show("Contact already exists");
                return;
            }
            AddContact(contact);
            UpdateContacts();
        }
    }
}
