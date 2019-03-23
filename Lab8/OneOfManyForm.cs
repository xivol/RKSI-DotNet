using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Lab8
{
    
    public partial class OneOfManyForm : Form, IOneOfMany<Form>
    {
        public event Action<Form> ShowNext;
        public event Action<Form> ShowPrevious;

        public void SetUID(uint uid)
        {
            labelID.Text = uid.ToString();
        }

        private StudentData student;

        public OneOfManyForm(StudentData student)
        {
            this.student = student;

            InitializeComponent();            
            SetupValidators();
        }

        private void buttonNextClick(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                ShowNext(this);
            }    
        }

        private void buttonPrevClick(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                ShowPrevious(this);
            }          
        }

        private void OneOfManyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !ValidateChildren(ValidationConstraints.Enabled);
        }

        private void OneOfManyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ShowNext(this);
        }




        public Dictionary<Control, Func<bool>> validator;
        public Dictionary<Control, Action<StudentData>> dataSet;
        public Dictionary<Control, string> error;

        void SetupValidators()
        {
            validator = new Dictionary<Control, Func<bool>>();
            dataSet = new Dictionary<Control, Action<StudentData>>();
            error = new Dictionary<Control, string>();

            validator[textBox1] = () => !String.IsNullOrEmpty(textBox1.Text);
            dataSet[textBox1] = (StudentData s) => s.Name = textBox1.Text;
            error[textBox1] = "Имя не может быть пустым";

            validator[maskedTextBox1] = () => Regex.IsMatch(maskedTextBox1.Text, StudentData.PhoneFormat);
            dataSet[maskedTextBox1] = (StudentData s) => s.Phone = maskedTextBox1.Text;
            error[maskedTextBox1] = "Телефон должен быть заполнен";
        }

        private void textBox_Validating(object sender, CancelEventArgs e)
        {
            Control ctrl = sender as Control;
            if (validator.ContainsKey(ctrl))
            {
                if (!validator[ctrl]())
                {
                    ctrl.BackColor = Color.LightPink;
                    errorProvider1.SetError(ctrl, error[ctrl]);
                    e.Cancel = true;
                }
                else
                {
                    ctrl.BackColor = Color.White;
                    errorProvider1.SetError(ctrl, "");
                    dataSet[ctrl](student);
                }
            }            
        }
    }
}
