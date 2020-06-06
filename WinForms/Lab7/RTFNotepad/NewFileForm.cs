using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class NewFileForm : Form
    {
        public string FileName = "";

        public NewFileForm()
        {
            InitializeComponent();
        }

        private void NewFileForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FileName = textBox1.Text;
        }
    }
}
