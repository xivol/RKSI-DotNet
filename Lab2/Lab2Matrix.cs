using System;
using System.IO;

namespace Lab2
{
    static class Matrix
    {
        /// <summary>
        /// Вывод марицы на консоль
        /// </summary>
        /// <param name="matr">Исходная матрица</param>
        public static void Print(double[,] matr)
        {
            for (int i = 0; i < matr.GetLength(0); ++i)
            {
                Console.Write("[ ");

                for (int j = 0; j < matr.GetLength(1); ++j)
                    Console.Write("{0,5:F2} ", matr[i,j]);

                Console.WriteLine("]");
            }
        }

        /// <summary>
        /// Чтение матрицы из текстового файла в формате:
        ///   3 4
        ///   1.0 2.0 3.0 4.0
        ///   4.0 5.0 6.0 7.0
        ///   7.0 8.0 9.0 10.0
        /// </summary>
        /// <returns>Считанная матрица</returns>
        /// <param name="source">Поток данных из файла</param>
        // TODO: public static double[,] Read(StreamReader source);

        /// <summary>
        /// Запись матрицы в текстовый файл в формате:
        ///   3 4
        ///   1.0 2.0 3.0 4.0
        ///   4.0 5.0 6.0 7.0
        ///   7.0 8.0 9.0 10.0
        /// </summary>
        /// <param name="matr"> Исходная матрица</param>
        /// <param name="file"> Выходной файл</param>
        // TODO: public static void Write(double[,] matr, StreamWriter file);

        /// <summary>
        /// Вычиление индекса строки с минимальной суммой элементов.
        /// </summary>
        /// <returns>Индекс строки с минимальной суммой элементов</returns>
        /// <param name="matr"> Исходная матрица</param>
        // TODO: public static int MinSumRow(double[,] matr);


        /// <summary>
        /// Транспонирование матрицы.
        /// </summary>
        /// <param name="matr"> Исходная матрица</param>
        // TODO: public static void Transpose(double[,] matr);

        /// <summary>
        /// Сложение матриц.
        /// </summary>
        /// <returns> Сумма матриц</returns>
        /// <param name="left"> Левая матрица</param>
        /// <param name="right"> Правая матрица</param>
        // TODO: public static double[,] Sum(double[,] left, double[,] right);

        /// <summary>
        /// Умножение матриц.
        /// </summary>
        /// <returns> Произведение матриц</returns>
        /// <param name="left"> Левая матрица</param>
        /// <param name="right"> Правая матрица</param>
        // TODO: public static double[,] Multiply(double[,] left, double[,] right);

    }
}

