using System;
using System.Windows.Forms;
namespace Lab8
{
    public class OOMF : Form
    {
        public event Action<Form> ShowNext;
        public event Action<Form> ShowPrevious;
         
        public OOMF()
        {
            this.FormClosing += OnFormClosing;
            this.FormClosed += OnFormClosed; 
        }

        protected void OnNextClick(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                ShowNext(this);
            }
        }

        protected void OnPrevClick(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                ShowPrevious(this);
            }
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !ValidateChildren(ValidationConstraints.Enabled);
        }

        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            ShowNext(this);
        }

    }
}
