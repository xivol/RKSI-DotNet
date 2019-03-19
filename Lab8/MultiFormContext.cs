using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab8
{
    public class MultiFormContext : ApplicationContext
    {
        private LinkedList<Form> forms;

        public MultiFormContext(params Form[] forms)
        {
            this.forms = new LinkedList<Form>();

            foreach (var form in forms)
            {
                this.forms.AddLast(form);

                form.FormClosed += OnFormClosed;
                if (form is IOneOfMany<Form>)
                {
                    IOneOfMany<Form>  oomf = form as IOneOfMany<Form>;
                    oomf.ShowNext += OnShowNext;
                    oomf.ShowPrev += OnShowPrev;
                }

                form.Show();
            }

        }

        private void OnFormClosed(object sender, EventArgs args)
        {
            forms.Remove(sender as Form);

            if(forms.Count == 0)
                ExitThread();
        }

        private void OnShowNext(Form form)
        {
            var node = forms.Find(form);
            var next = node == forms.Last ? forms.First : node.Next;

            //form.WindowState = FormWindowState.Minimized;
            form.Hide();
            //next.Value.WindowState = FormWindowState.Normal;
            next.Value.Show();

            next.Value.Focus();
        }

        private void OnShowPrev(Form form)
        {
            var node = forms.Find(form);
            var prev = node == forms.First ? forms.Last : node.Previous;

            //form.WindowState = FormWindowState.Minimized;
            form.Hide();
            //prev.Value.WindowState = FormWindowState.Normal;
            prev.Value.Show();

            prev.Value.Focus();
        }
    }
    
}
