/*
 * Lab4 Коллекции. Ассоциативные массивы
 * 
 * Часть 1. Дан CSV файл с данными журнала по предмету в формате:
 *     Иванов Иван Иванович; ; н; н; 2; н; н; н; н; 3
 *     Петров Петр Петрович; ; 5; ; 4; 4; ; 5; 5; 5
 * Считать информацию о посещениях и оценках в словарь студентов.
 * Выдавать информацию об ошибках формата файла.
 * 
 * Часть 2. По данным полученным из файла, получить:
 *     1. Список не аттестоваций студентов;
 *     2. Список результатов аттестованных студентов;
 *     4. Записать результаты всех студентов в новый файл в формате:
 *         Иванов Иван Иванович; н/а
 *         Петров Петр Петрович; 5
 */

using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace Lab4
{
    static class Lab4Collections
    {
        /// <summary>
        /// Генерация данных журнала
        /// </summary>
        /// <param name="students"> Путь к списку студентов</param>
        /// <param name="lessonsCount"> Количество занятий</param>
        public static void RandomJournal(string students, int lessonsCount)
        {
            StreamReader sr = new StreamReader(students);
            string journal = Path.GetFileNameWithoutExtension(students) + "Journal.csv";
            StreamWriter sw = new StreamWriter(journal);

            Random rnd = new Random();

            while (!sr.EndOfStream)
            {
                string studentName = sr.ReadLine();

                sw.Write(studentName);
                for (int i = 0; i < lessonsCount; ++i)
                {
                    int attest = rnd.Next(6);
                    
                    sw.Write("; {0}", attest == 0 ? "н" : 
                                      attest == 1 ? "" : 
                                      attest.ToString());
                }
                sw.WriteLine();

            }

            sr.Close();
            sw.Close();
        }
    }

    /// <summary>
    /// Считывание данных студентов из CSV файла.
    /// </summary>
    /// <returns> Данные о посещениях студентов</returns>
    /// <param name="journal"> Путь к файлу</param>
    // TODO: public static Dictionary<string, List<int>> ReadStudentsData(string journal);

    /// <summary>
    /// Построение списка не аттестованных студентов на основе данных о посещениях.
    /// </summary>
    /// <returns> Список не аттестованных студентов</returns>
    /// <param name="studentsData"> Данные о посещениях студентов</param>
    // TODO: public static List<string> FailedStudents(Dictionary<string, List<int>> studentsData);

    /// <summary>
    /// Построение списка оценок студентов получивших аттестацию.
    /// </summary>
    /// <returns> Оценки аттестованых студентов за курс</returns>
    /// <param name="studentsData"> Данные об оценках студентов</param>
    // TODO: public static Dictionary<string, int> Results(Dictionary<string, List<int>> studentsData);

    /// <summary>
    /// Вывод данных об аттестации студентов в новый файл.
    /// </summary>
    /// <param name="studentsData"> Данные об оценках студентов</param>
    /// <param name="output"> Путь к выходному файлу</param>
    // TODO: public static void ResultsFile(Dictionary<string, List<int>> studentsData, string output);
}
