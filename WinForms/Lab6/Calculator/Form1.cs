using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        Calculator calc;
        public Form1()
        {
            InitializeComponent();
            calc = new Calculator();
            calc.DidUpdateValue += calc_DidUpdate;
            calc.InputError += calc_Error;
            calc.CalculationError += calc_Error;
        }

        private void calc_Error(object sender, string e)
        {
            MessageBox.Show(e, "Calculator Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void calc_DidUpdate(Calculator sender,double value, int precision)
        {
            if (precision > 0)
                label1.Text = String.Format("{0:F" + precision + "}", value);
            else
                label1.Text = $"{value}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string text = (sender as Button).Text;
            string name = (sender as Button).Name;
            object tag = (sender as Button).Tag;
            //MessageBox.Show($"{name} : {text}, {tag}");

            int digit;
            if (int.TryParse(text, out digit))
            {
                calc.AddDigit(digit);
            }
            else
            {
                switch (tag)
                {
                    case "decimal":
                        calc.AddDecimalPoint();
                        break;
                    case "evaluate":
                        calc.Compute();
                        break;
                    case "addition":
                        calc.AddOperation(Operation.Add);
                        break;
                    case "substraction":
                        calc.AddOperation(Operation.Sub);
                        break;
                    case "multiplication":
                        calc.AddOperation(Operation.Mul);
                        break;
                    case "division":
                        calc.AddOperation(Operation.Div);
                        break;
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //string code = e.KeyCode.ToString();
            //string data = e.KeyData.ToString();
            //string value = e.KeyValue.ToString();

            //MessageBox.Show($"{code} {data} {value}");

            switch (e.KeyCode)
            {
                case Keys.D1:
                case Keys.NumPad1:
                    calc.AddDigit(1);
                    break;
                case Keys.D2:
                case Keys.NumPad2:
                    calc.AddDigit(2);
                    break;
                case Keys.D3:
                case Keys.NumPad3:
                    calc.AddDigit(3);
                    break;
                /** и так далее**/
            }

        }

    }
}
