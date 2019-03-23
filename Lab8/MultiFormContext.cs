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
            uint uid = 0;

            foreach (var form in forms)
            {
                this.forms.AddLast(form);

                form.FormClosed += OnFormClosed;
                if (form is IOneOfMany<Form>)
                {
                    IOneOfMany<Form>  oomf = form as IOneOfMany<Form>;
                    oomf.ShowNext += OnShowNext;
                    oomf.ShowPrevious += OnShowPrevious;

                    oomf.SetUID(uid++);
                }
            }

            this.forms.First.Value.Show();
        }

        private void OnFormClosed(object sender, EventArgs args)
        {
            forms.Remove(sender as Form);

            if (forms.Count == 0)
                ExitThread();
        }

        private void OnShowNext(Form form)
        {
            var node = forms.Find(form);
            var next = node == forms.Last ? forms.First : node.Next;

            form.Hide();
            next.Value.Show();
            next.Value.Focus();
        }

        private void OnShowPrevious(Form form)
        {
            var node = forms.Find(form);
            var prev = node == forms.First ? forms.Last : node.Previous;

            form.Hide();
            prev.Value.Show();
            prev.Value.Focus();
        }
    }
    
}
