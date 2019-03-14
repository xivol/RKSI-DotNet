using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab8
{
    
    public partial class OneOfManyForm : Form
    {
        public delegate void FormDelegate(Form sender);

        public event FormDelegate ShowNext;
        public event FormDelegate ShowPrev;
       
        public OneOfManyForm()
        {
            InitializeComponent();

            //labelID.BackColor = Program.RandomColor();
        }

        private void buttonNextClick(object sender, EventArgs e)
        {
            ShowNext(this);            
        }

        private void buttonPrevClick(object sender, EventArgs e)
        {
            ShowPrev(this);            
        }

        private void OneOfManyFormOnDeactivate(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void OneOfManyFormOnClosed(object sender, FormClosedEventArgs e)
        {
            ShowNext(this);
        }
    }
}
