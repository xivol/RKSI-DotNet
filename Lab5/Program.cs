/*
 * Lab5 
 * Классы. Наследование
 * 
 * Часть 1. Реализовать наследника класса Person:
 *   - Сотрудник (Employee):
 *     - поле Отдел - название отдела, где работает сотрудник;
 *     - поле Должность - название должности, на которой работает сотрудник;
 *     - поле Зарплата - вещественное число;
 *     - метод ToString() - выводит должность, ФИО и отдел.
 *   Предусмотреть методы изменения данных сотрудника.
 * 
 * Часть 2. Заполнить массив Person[] случайными объектами (Person, Student, Employee). В этом массиве:
 *   - Найти сотрудника с минимальной зарплатой,
 *   - Вывести список студентов первого курса.
 */
using System;

namespace Lab5
{
    class Program
    {
        /// <summary>
        /// Gets the random person.
        /// </summary>
        /// <returns>The random person.</returns>
        /// <param name="names">Names.</param>
        /// <param name="uid">Uid.</param>
        // TODO: static Person GetRandomPerson(string[][] names, uint uid);

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

            // Вызов статического метода
            Person pers = Person.Read(Console.In);

            Student stud2 = new Student(pers, "БТ", 3, 1);
            Console.WriteLine(stud2);
        }
    }
}
