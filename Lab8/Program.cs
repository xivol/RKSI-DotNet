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

            DataModel model = new DataModel();
            var context = new MultiFormContext(new OneOfManyForm(), new OneOfManyForm(), new OneOfManyForm());
            Application.Run(context);
        }

        static Random rnd = new Random();

        public static Color RandomColor()
        {
            
            Array colors = Enum.GetValues(typeof(KnownColor));
            return Color.FromKnownColor((KnownColor)colors.GetValue(rnd.Next(colors.Length)));
        }
    }
}
