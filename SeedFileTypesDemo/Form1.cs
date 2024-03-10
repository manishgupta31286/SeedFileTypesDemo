using System.Collections.Generic;

namespace SeedFileTypesDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty;
            string fileTypeSelected = cboFileTypes.SelectedItem.ToString();

            IWrite writer = null;

            switch (fileTypeSelected)
            {
                case "Text":
                    writer = new TextProcessor();
                    filePath = "employees.txt";
                    break;
                case "Json":
                    writer = new JsonProcessor();
                    filePath = "employees.json";
                    break;
                case "Xml":
                    writer = new XmlProcessor();
                    filePath = "employees.xml";
                    break;
                case "Csv":
                    writer = new CsvProcessor();
                    filePath = "employees.csv";
                    break;
                default:
                    break;
            }

            if (writer == null)
            {
                MessageBox.Show("File type not supported");
                return;
            }

            Employee employee = new Employee
            {
                Id = txtId.Text,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text
            };
            await writer.WriteAsync(filePath, employee);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboFileTypes.Items.Add("Text");
            cboFileTypes.Items.Add("Json");
            cboFileTypes.Items.Add("Xml");
            cboFileTypes.Items.Add("Csv");
            cboFileTypes.SelectedIndex = 0;
        }

        private async void btnFetch_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty;
            string fileTypeSelected = cboFileTypes.SelectedItem.ToString();
            IRead<List<Employee>> listReader=null;
            IRead<string> stringReader=null;

            switch (fileTypeSelected)
            {
                case "Text":
                    stringReader = new TextProcessor();
                    filePath = "employees.txt";
                    break;
                case "Json":
                    listReader = new JsonProcessor();
                    filePath = "employees.json";
                    break;
                case "Xml":
                    listReader = new XmlProcessor();
                    filePath = "employees.xml";
                    break;
                case "Csv":
                    listReader = new XmlProcessor();
                    filePath = "employees.csv";
                    break;
                default:
                    break;
            }
            if (stringReader != null)
            {
                string data = await stringReader.ReadAsync(filePath);
                listBox1.DataSource=data.Split('\n');
                return;
            }
            if (listReader != null)
            {
                var employees = await listReader.ReadAsync(filePath);

                listBox1.DataSource= employees;
            }
        }
    }
}