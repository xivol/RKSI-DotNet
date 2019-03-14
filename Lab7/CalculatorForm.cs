using System;
using System.Collections.Generic;
using System.Drawing;

using System.Windows.Forms;
using Lab6;

namespace Lab7
{
    public class CalculatorForm : Form
    {
        private Button[,] buttons = null;
        private TextBox output = null;

        private string[,] symbols = {
            { "7", "8", "9", "/" },
            { "4", "5", "6", "*" },
            { "1", "2", "3", "-" },
            { "0", ",", "=", "+"}
        };
        
        public CalculatorForm(ICalculator calc)
        {
            //
            int offset = 8;
            Point origin = new Point(offset, offset);
            ClientSize = new Size(480, 640);
            Text = "Calculator";
            AutoScaleMode = AutoScaleMode.Font;
            
            Size buttonSize = new Size(
                (ClientSize.Width - origin.X) / symbols.GetLength(1) - offset,
                (ClientSize.Height - origin.Y) / (symbols.GetLength(0) + 1) - offset
            );

            Font font = null;
            using (Graphics g = this.CreateGraphics())
            {
                font = new Font(FontFamily.GenericMonospace, buttonSize.Height / 2 / g.DpiY * 72);
            }

            int tabIndex = 0;
            SuspendLayout();

            //
            output = new TextBox();
            output.TabIndex = tabIndex++;
            output.Name = "output";
            output.TextAlign = HorizontalAlignment.Right;
            output.Font = font;
            output.ReadOnly = true;

            output.Location = origin;
            output.AutoSize = false;
            output.Size = new Size(ClientSize.Width - origin.X * 2, buttonSize.Height);

            origin = new Point(origin.X, origin.Y + output.Size.Height + offset);

            //
            buttons = new Button[symbols.GetLength(0), symbols.GetLength(1)];
            for (int i = 0; i < symbols.GetLength(0); ++i)
            {
                for (int j = 0; j < symbols.GetLength(1); ++j)
                {
                    Button b = new Button();
                    b.Name = "Button_" + symbols[i, j];
                    b.Text = symbols[i, j];
                    b.Font = font;
                    b.TabIndex = tabIndex++;

                    b.Location = new Point(
                        origin.X + (buttonSize.Width + offset) * j,
                        origin.Y + (buttonSize.Height + offset) * i);
                    b.Size = buttonSize;

                    b.Click += buttonOnClick;

                    buttons[i, j] = b;
                }
            }

            // 
            foreach (Button b in buttons)
                Controls.Add(b);
            Controls.Add(output);

            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            ResumeLayout(false);
            PerformLayout();
        }

        private void buttonOnClick(object sender, EventArgs e)
        {
            output.AppendText((sender as Button).Text);
        }
    }
}
