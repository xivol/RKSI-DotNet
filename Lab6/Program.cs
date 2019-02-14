/*
 * Lab6
 * Интерфейсы. События. Представители(делегаты).
 * 
 * 
 */
using System;

namespace Lab6
{
    class Program
    {
        static void Parse(ICalculator calc, string expression)
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
                    calc?.Compute();
                    Console.WriteLine(c);
                }
                else
                {
                    object op = Enum.ToObject(typeof(CalculatorOperation), c);
                    if (Enum.IsDefined(typeof(CalculatorOperation), op))
                    {
                        calc?.AddOperation((CalculatorOperation) op);
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
                Parse(calc, "12+34=");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("error");
            }
        }
    }
}
