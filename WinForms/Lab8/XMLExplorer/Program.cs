using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Text;

namespace WindowsFormsApp3
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
            Application.Run(new Form1());

            var students = new List<Student>();
            
            var group = new Group
            {
                Course = 3,
                Number = 4,
                Track = "ПОКС"
            };
            for (int i = 0; i < 10; ++i)
            {
                var student = new Student
                {
                    Name = $"Студент {i}",
                    Group = group,
                    Marks = new List<byte> { 0, 1, 2, 3 }
                };
                students.Add(student);
            }

            var serializer = new XmlSerializer(typeof(List<Student>));

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.Encoding = Encoding.Unicode;

            using (XmlWriter fs = XmlWriter.Create("student.xml", settings))
            {
                
                serializer.Serialize(fs, students);

                Debug.WriteLine("Объект сериализован");
            }

            using (FileStream fs = new FileStream("student.xml", FileMode.Open))
            {
                foreach(var student in serializer.Deserialize(fs) as List<Student>)
                {
                    Debug.WriteLine(student.Name);
                }
            }
        }
    }
}
