/*
 * Lab1
 * Отладка. Обработка массивов.
 * 
 * Часть1. Используя методы отладки по шагам найти ошибки в программе.
 * 
 * Часть2. Реализовать закоментированные методы из класса Lab1Array
 */


using System;

namespace Lab1
{
    class Program
    {

        static void Main(string[] args)
        {
            int[] a;
            Lab1Array.Read(out a);
            Lab1Array.Print(a);
            Lab1Array.ReverseBetweenTwoMins(a);
            Lab1Array.Print(a);

            Console.ReadKey();
        }
    }
}
