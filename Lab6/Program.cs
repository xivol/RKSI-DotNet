/*
 * Lab6
 * Интерфейсы. События. Представители(делегаты).
 * 
 * Часть 1. Реализовать класс с интерфейсом ICalculator. Использовать инкапсуляцию.
 *   Продемонстрировать работу класса на разборе заданной пользователем строки.
 * 
 * Часть 2. Реализовать отдельный класс Logger, записывающий лог работы калькулятора в заданный поток.
 *  Продемонстрировать работу класса, записав на консоль и в файл.
 */
using System;

namespace Lab6
{
    class Program
    {
        static void Compute(ICalculator calc, string expression)
        {
            foreach(char c in expression)
            {
                if (Char.IsDigit(c))
                {
                    calc?.AddDigit(c - '0');
                    Console.WriteLine(c - '0');
                }
                else if (c == '=')
                {
                    Console.WriteLine(c);
                }
                else
                {
                    object op = Enum.ToObject(typeof(CalculatorOperation), c);

                    if (Enum.IsDefined(typeof(CalculatorOperation), op))
                    {
                        Console.WriteLine((char)(CalculatorOperation)op);
                    }
                    else
                    {
                        throw new ArgumentException("Invalid character: " + c);
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            ICalculator calc = null;

            try
            {
                Compute(calc, "12+34=");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Error: \"{e.Message}\"");
            }
        }
    }
}
