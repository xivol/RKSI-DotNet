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

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            Student stud = new Student("Иван", "Иванов", "Иванович", Gender.Male, "ПОКС", 1 ,2);

            // ToString() вызывается автоматически при преобразовании к строке
            Console.WriteLine(stud);
            // ToString() - виртуальная функция: будет позднее связывание
            Console.WriteLine(stud as Person);

            // FullName - не виртуальное свойство: будет раннее связывание
            Console.WriteLine(stud.FullName);
            Console.WriteLine((stud as Person).FullName);

            Person pers = Person.Read(Console.In);
            Student stud2 = new Student(pers, "БТ", 3, 1);
            Console.WriteLine(stud2);
        }
    }
}
