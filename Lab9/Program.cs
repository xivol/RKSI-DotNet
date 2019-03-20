using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab9
{
    static class Program
    {
        /// <summary>
        /// https://docs.microsoft.com/ru-ru/visualstudio/data-tools/read-xml-data-into-a-dataset?view=vs-2017
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
