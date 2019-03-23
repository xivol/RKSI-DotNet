using System;
using System.Windows.Forms;

namespace Lab8
{ 
    public interface IOneOfMany<T> where T : Form
    {
        event Action<T> ShowNext;
        event Action<T> ShowPrevious;

        void SetUID(uint uid);
    }
}
