using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace WindowsFormsApp3
{

    public partial class Form1 : Form
    {
        DataSet dataSet = new DataSet();
        List<Student> students;

        public Form1()
        {
            InitializeComponent();
            dataSet.ReadXml("student.xml");
            InitDataGridPages();

            DeserializeDataSet();
            students.Add(new Student
            {
                Name = "Студент 10",
                Group = new Group { Number =4, Course =3, Track = "ПОКС"},
                Marks = new List<byte> { 5,5,5,5}
                
            });
            dataSet.Clear();
            SerializeDataSet();

            exitToolStripMenuItem.Click += (s,e) => Close();
        }

        private void InitDataGridPages()
        {
            foreach (var table in dataSet.Tables)
            {
                this.tabControl1.TabPages.Add(table.ToString());
                var page = tabControl1.TabPages[tabControl1.TabPages.Count - 1];
                var dataGrid = new DataGridView();
                page.Controls.Add(dataGrid);
                dataGrid.Dock = DockStyle.Fill;
                dataGrid.DataSource = table;

                var t = table as DataTable;
                foreach (var c in t.Columns)
                {
                    var col = c as DataColumn;
                    if (col.ColumnMapping == MappingType.Hidden)
                        col.ColumnMapping = MappingType.Attribute;
                }

                dataGrid.RowValidating += RowValidating;
                dataGrid.DataError += DataError;
            }
        }

        private void DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            var dataGrid = sender as DataGridView;
            dataGrid.Rows[e.RowIndex].ErrorText = e.Exception.Message;
            MessageBox.Show(e.Exception.Message, "DataError",MessageBoxButtons.OK, MessageBoxIcon.Error);            
        }

        private void RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            Debug.WriteLine($"{e.RowIndex}:{e.ColumnIndex}");
            var dataGrid = sender as DataGridView;
            dataGrid.Rows[e.RowIndex].ErrorText = "";

            string headerText = dataGrid.Columns[e.ColumnIndex].HeaderText;
            if (headerText != "Name") return;

            string Name = dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            if (Name.Contains("@"))
            {
                e.Cancel = true;
                dataGrid.Rows[e.RowIndex].ErrorText = "Wrong Symbol";
            }
        }

        private void DeserializeDataSet()
        {
            XmlReader xml = XmlReader.Create(new StringReader(dataSet.GetXml()));
            var serializer = new XmlSerializer(typeof(List<Student>));
            students = serializer.Deserialize(xml) as List<Student>;
            foreach (var student in students as List<Student>)
            {
                Debug.WriteLine(student.Name);
            }
        }

        private void SerializeDataSet()
        {
            var serializer = new XmlSerializer(typeof(List<Student>));
            StringBuilder data = new StringBuilder();
            
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.Encoding = Encoding.Unicode;
            var xml = XmlWriter.Create(new StringWriter(data), settings);

            serializer.Serialize(xml, students);
            dataSet.ReadXml(XmlReader.Create(new StringReader(data.ToString())));
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            dataSet.WriteXml("new_student.xml");
            dataSet.WriteXmlSchema("student_scheme.xsd");
        }
    }
}
