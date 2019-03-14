/*
 * Lab7
 * Основы работы с формами.
 * 
 * Часть 1. Подключить реализацию калькулятора из лаюораторной 6. 
 * Реализовать обработку нажатия кнопок формы и запись результатов в поле вывода.
 * В случае ошибки, выдавать сообщение в MessageBox.
 * 
 * Часть 2. Добавить в калькулятор методы работы с числами с плавающей точкой.
 * Ограничить максимальное число знаков после запятой которое может выводиться в поле вывода.
 */
using System;
using System.Windows.Forms;

namespace Lab7
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Lab6.ICalculator calc = null;

            Application.Run(new CalculatorForm(calc));
        }
    }
}
