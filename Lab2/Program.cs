/*
 * Lab2
 * Матрицы. Работа с файлами.
 * 
 * Часть 1. Реализовать чтение и запись матрицы в файл.
 * 
 * Часть 2. Рализовать методы обработки матриц.
 */
using System;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] matr = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            Matrix.Print(matr);
            Console.ReadKey();
        }
    }
}
