using System;

namespace Lab1
{
    static class Array
    {
        public static void Print(int[] ar)
        {
            Console.Write("[ ");
            foreach (int x in ar)
                Console.Write($"{x:D}; ");
            Console.WriteLine("]");
        }

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
