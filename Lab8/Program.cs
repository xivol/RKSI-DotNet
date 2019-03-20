//
//
// Часть 1. Реализовать

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab8
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var context = new MultiFormContext(new OneOfManyForm(), new OneOfManyForm(), new OneOfManyForm());
            Application.Run(context);
        }

    }
}
