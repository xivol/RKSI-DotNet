/*
 * Lab0.cs
 * Ввод-вывод. Передача параметров
 */

using System;

namespace Lab0
{
    class Program
    {
        /// <summary>
        /// Нахождение вещественных корней уравнения a * x^2 + b * x + c = 0.
        /// </summary>
        /// <returns>Количество вещественных корней</returns>
        /// <param name="a">Коэффициент а</param>
        /// <param name="b">Коэффициент b</param>
        /// <param name="c">Коэффициент c</param>
        /// <param name="x1">Значение первого корня</param>
        /// <param name="x2">Значение второго корня</param>
        static int Roots(double a, double b, double c, out double x1, out double x2);

        /// <summary>
        /// Нахождение комплексных корней уравнения a * x^2 + b * x + c = 0,
        /// вида re +/- im * i (i == √-1)
        /// </summary>
        /// <param name="a">Коэффициент а</param>
        /// <param name="b">Коэффициент b</param>
        /// <param name="c">Коэффициент c</param>
        /// <param name="re">Вещественная часть корня</param>
        /// <param name="im">Мнимая часть корня</param>
        static void ComplexRoots(double a, double b, double c, out double re, out double im);

        /// <summary>
        /// Точка входа в программу
        /// </summary>
        /// <param name="args">Аргументы коммандной строки</param>
        static void Main(string[] args)
        {
            double a, b, c;
            Console.WriteLine("Введите коэффициенты квадратного уравнения:");


            double x1, x2;
            int count = Roots(a, b, c, out x1, out x2);

            switch (count)
            {
                case 0:
                    Console.WriteLine("Вещественных корней нет!");
                    Console.WriteLine("Комплексные корни:");
                    ComplexRoots(a, b, c, out x1, out x2);
                    Console.WriteLine("x1 = {0} + {1}i", x1, Math.Abs(x2));
                    Console.WriteLine("x2 = {0} - {1}i", x1, Math.Abs(x2));
                    break;

                case 1:
                    Console.WriteLine("Двойной корень:");
                    Console.WriteLine($"x1,2 = {x1}");
                    break;

                default:
                    Console.WriteLine("Два корня:");
                    Console.WriteLine($"x1 = {x1}\n x2 = {x2}");
                    break;
            }

            Console.ReadKey();
        }
    }
}
