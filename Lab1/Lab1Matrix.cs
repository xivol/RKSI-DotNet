using System;
using System.IO;

namespace Lab1
{
    public class Matrix
    {
        //public static void Print(double[,] data);

        public static double[,] Read(TextReader source)
        {
            string line = source.ReadLine();
            string[] argLine = line.Split(' ');

            int m = int.Parse(argLine[0]);
            int n = int.Parse(argLine[1]);

            double[,] matr = new double[m, n];

            int i = 0, j = 0;
            while ((line = source.ReadLine())!= null)
            {
                j = 0;
                argLine = line.Split(' ');
                foreach(string arg in argLine)
                {
                    matr[i, j] = double.Parse(arg);
                    j += 1;
                }
                i += 1;

            }

            return matr;
        }

        public static void Main()
        {
            double[,] m = Read(Console.In);
        }


        //public static void Transpose(double[,] matr);

        //public static int MinSumLine(double[,] matr);

        //public static double[,] Multiply(double[,] left, double[,] right);

        //public static double[] Solve(double[,] a, double[] b);
    }
}

