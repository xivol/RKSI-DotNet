using System;
using System.Windows.Forms;

namespace Lab8
{
    public delegate void OneOfManyDelegate<T>(T sender);
    public interface IOneOfMany<T> where T : Form
    {
        event OneOfManyDelegate<T> ShowNext;
        event OneOfManyDelegate<T> ShowPrev;
    }
}
