/*
 * Lab5 
 * Классы. Наследование
 * 
 * Часть 1. Реализовать в классе Student метод считывания данных из потока ввода.
 *          Считать данные группы студентов из файла.
 *          Вычислить число лиц мужского, женского и других полов.
 * 
 * Часть 2. Реализовать
 */

using System;
using System.IO;
using System.Text;

namespace Lab5
{
    /// <summary>
    /// Класс студент
    /// </summary>
    public class Student : Person
    {
        protected uint course;
        protected uint group;
        protected string track;

        public Student(string firstname, string lastname, string patronim, Gender gender,
                       string track, uint course, uint group) : base(gender, firstname, lastname, patronim)
        {
            this.track = track;
            this.course = course;
            this.group = group;
        }

        public Student(Person p, string track, uint course, uint group) : 
            this(p.Firstname, p.Lastname, p.Patronim, p.Gender, track, course, group)
        {}

        /// <summary>
        /// Read the specified input.
        /// </summary>
        /// <returns>The read.</returns>
        /// <param name="input">Input.</param>
        // TODO: public static new Student Read(TextReader input);

        /// <summary>
        /// Курс
        /// </summary>
        /// <value> Номер курса</value>
        public uint Course
        {
            get { return this.course; }
        }

        // Номер группы
        public uint Group
        {
            get { return this.group; }
        }

        // Учебная программа
        public string Track
        {
            get { return this.track; }
        }

        // Название группы
        public string GetGroupName()
        {
            // Пример работы со StringBuilder
            StringBuilder result = new StringBuilder();

            result.Append(track).Append("-").Append(course).Append(group);

            return result.ToString();
        }


        public new string FullName // закрывает метод базового класса Person
        {
            get
            {
                return this.lastname + " " + this.firstname;
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()}; {GetGroupName()}";
        }
    }
}
