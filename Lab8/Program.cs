//
//
// Часть 1. Реализовать пошаговую форму заполнения данных студента.
// Реализовать три формы для заполнения данных по частям:
//   Личные данные,
//   Контактные данные,
//   Данные об обучении.
// Данные должны проверяться на корректность.
//
// Часть 2.Реализовать главную форму с возможностью сохранения и загрузки данных
//

using System;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.IO;
using System.Text;

namespace Lab8
{
    static class Program
    {

        private static StudentData student = new StudentData();

        static void OnShutdown(object sender, EventArgs args)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(StudentData));
            var stream = new StreamWriter("test.xml");
            serializer.Serialize(stream, student);
            stream.Close();
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);         

            var context = new MultiFormContext(new OneOfManyForm(student), new OneOfManyForm(student), new OneOfManyForm(student));
            context.ThreadExit += OnShutdown;
            
            Application.Run(context);
        }

    }
}
