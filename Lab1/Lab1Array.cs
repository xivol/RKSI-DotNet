/*
 * Lab1
 * Отладка. Обработка массивов.
 * 
 * Часть1. Используя методы отладки по шагам найти ошибки в программе.
 * https://docs.microsoft.com/ru-ru/visualstudio/debugger/debugger-feature-tour?view=vs-2017
 * 
 * Часть2. Реализовать закоментированные методы из класса Lab1Array
 */
using System;

namespace Lab1
{
    static class Lab1Array
    {
        /// <summary>
        /// Вывод массива в формате [ a0, a1, a2, a3 ]
        /// </summary>
        /// <param name="ar">Массив данных</param>
        public static void Print(int[] ar)
        {
            Console.Write("[ ");
            foreach (int x in ar)
                Console.Write($"{x:D}; ");
            Console.WriteLine("]");
        }

        /// <summary>
        /// Чтение массива с консоли.
        /// </summary>
        /// <param name="ar">Выходной массив данных</param>
        public static void Read(out int[] ar)
        {
            Console.WriteLine("Введите длину массива:");
            uint len = uint.Parse(Console.ReadLine());
            ar = new int[len];
            
            Console.WriteLine("Введите {0} элементов:", len);
            int i = 0;
            while(i < len)
            {
                foreach (string value in Console.ReadLine().Split(' ') )
                {
                    // при наличии лишних пробелов будут пустые строки
                    if (value.Length == 0)
                        continue;
                    // если значений в строке слишком много, то пропускаем лишние
                    if (i >= len)
                        break;

                    ar[i] = int.Parse(value);
                    i += 1;

                }
            }
        }

        /// <summary>
        /// Нахождение номера первого минимального элемента, начиная с элемента с номером start.
        /// </summary>
        /// <returns>Индекс первого минимального элемента в массиве после start</returns>
        /// <param name="ar">Массив данных</param>
        /// <param name="start">Смещение в массиве, по умолчанию - 0</param>
        public static int MinIndex(int[] ar, int start = 0)
        {
            int index = ar[start];

            for(int i = start + 1; i < ar.Length - 1; ++i)
                if (ar[i] < ar[index])
                {
                    index = i;
                }
            return index - 1;
        }

        /// <summary>
        /// Обращение порядка элементов массива между двумя минимальными элементами
        /// </summary>
        /// <param name="ar">Массив данных</param>
        public static void ReverseBetweenTwoMins(int[] ar)
        {
            int firstMin = MinIndex(ar);
            int secondMin = MinIndex(ar, firstMin);

            Array.Reverse(ar, firstMin + 1, secondMin - 1);
        }

        /// <summary>
        /// Отсортировать элементы массива таким образом, 
        /// чтобы сначала шли все положительные элементы, а затем все отрицательные.
        /// Исходный порядок следования элементов не должен быть нарушен.
        /// </summary>
        /// <param name="ar">Массив данных</param>
        // TODO: public static void SortPositive(int[] ar);

        /// <summary>
        /// Вставить дубликаты значений после каждого элемента в массиве.
        /// </summary>
        /// <param name="ar">Массив данных</param>
        // TODO: public static void InsertDuplicates(ref int[] ar);

        /// <summary>
        /// Удалить повторяющиеся значения из массива, не нарушая порядок его элементов.
        /// </summary>
        /// <param name="ar">Массив данных</param>
        // TODO: public static void RemoveDuplicates(ref int[] ar);
    }
}
