using System;

namespace Lab1
{
    static class Array
    {
        /// <summary>
        /// Print the specified ar.
        /// </summary>
        /// <param name="ar">Ar.</param>
        public static void Print(int[] ar)
        {
            Console.Write("[ ");
            foreach (int x in ar)
                Console.Write($"{x:D}; ");
            Console.WriteLine("]");
        }

        /// <summary>
        /// Read the specified ar.
        /// </summary>
        /// <param name="ar">Ar.</param>
        public static void Read(out int[] ar)
        {
            Console.WriteLine("Введите длину массива:");
            uint len = uint.Parse(Console.ReadLine());
            ar = new int[len];
            
            Console.WriteLine("Введите {0} элементов:", len);
            int i = 0;
            while(i < len)
            {
                foreach( string value in Console.ReadLine().Split(' ') )
                {
                    // при наличии лишних пробелов будут пустые строки
                    if (value.Length == 0)
                        continue;

                    ar[i] = int.Parse(value);
                    i += 1;
                }
            }
        }

        /// <summary>
        /// Minimums the index.
        /// </summary>
        /// <returns>The index.</returns>
        /// <param name="ar">Ar.</param>
        public static int MinIndex(int[] ar)
        {
            int index = -1;
            for(int i =0; i<ar.Length; ++i)
                if (ar[i]<ar[index])
                {
                    index = i;
                }
            return index;
        }

        /// <summary>
        /// Minimum the specified ar.
        /// </summary>
        /// <returns>The minimum.</returns>
        /// <param name="ar">Ar.</param>
        public static int Min(int[] ar)
        {
            int min = int.MaxValue;
            for (int i = 0; i < ar.Length; ++i)
                if (ar[i] < min)
                {
                    min = ar[i];
                }

            return min;
        }

        public static void RemoveAfterLastMin(ref int[] ar)
        {
            
        }
    }
}
