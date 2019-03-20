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
        public event OneOfManyDelegate<Form> ShowNext;
        public event OneOfManyDelegate<Form> ShowPrev;

        public Dictionary<Control, Func<bool>> validator;
        public Dictionary<Control, string> error;

        static Random rnd = new Random();
        public static Color RandomColor()
        {
            Array colors = Enum.GetValues(typeof(KnownColor));
            return Color.FromKnownColor((KnownColor)colors.GetValue(rnd.Next(colors.Length)));
        }

        public OneOfManyForm()
        {
            InitializeComponent();

            // Назначим разные цвета для разных окон
            labelID.BackColor = RandomColor();

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
                ShowPrev(this);
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
                }
            }            
        }

        void SetupValidators()
        {
            validator = new Dictionary<Control, Func<bool>>();
            error = new Dictionary<Control, string>();

            validator[textBox1] = () => !String.IsNullOrEmpty(textBox1.Text);
            error[textBox1] = "Имя не может быть пустым";

            validator[maskedTextBox1] = () =>
                {
                    Regex phone = new Regex(@"\+7\s\(\d\d\d\)\s\d\d\d-\d\d-\d\d");
                    return phone.IsMatch(maskedTextBox1.Text);
                };
            error[maskedTextBox1] = "Телефон должен быть заполнен";
        }

    }
}
