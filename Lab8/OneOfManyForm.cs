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
    
    public partial class OneOfManyForm : Form, IOneOfMany<Form>
    {
        public event OneOfManyDelegate<Form> ShowNext;
        public event OneOfManyDelegate<Form> ShowPrev;


        static Random rnd = new Random();
        public static Color RandomColor()
        {

            Array colors = Enum.GetValues(typeof(KnownColor));
            return Color.FromKnownColor((KnownColor)colors.GetValue(rnd.Next(colors.Length)));
        }

        public OneOfManyForm()
        {
            InitializeComponent();

            labelID.BackColor = RandomColor();
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
            //WindowState = FormWindowState.Minimized;
            Hide();
        }

        private void OneOfManyFormOnClosed(object sender, FormClosedEventArgs e)
        {
            ShowNext(this);
        }

        private void textBox_Validating(object sender, CancelEventArgs e)
        {
            
            if (sender == textBox1)
            {
                TextBox box = sender as TextBox;
                if (String.IsNullOrEmpty(box.Text))
                {
                    errorProvider1.SetError(box, "Имя не может быть пустым");
                    e.Cancel = true;
                }
            }
            else if (sender == maskedTextBox1)
            {
                MaskedTextBox box = sender as MaskedTextBox;
                errorProvider1.SetError(box, "Телефон заполнен не верно");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.Clear();
                e.Cancel = false;
            }
        }

        private void OneOfManyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ValidateChildren(ValidationConstraints.Enabled))
            {
                e.Cancel = true;
            }
        }
    }
}
