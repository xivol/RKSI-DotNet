using System;
using System.IO;

namespace Lab3
{
    static class Lab3Files
    {
        /// <summary>
        /// Получает массив всех файлов в указанной директории.
        /// </summary>
        /// <returns> Данные файлов</returns>
        /// <param name="dir"> Директория поиска файлов</param>
        /// <param name="ext"> Маска расширения для файлов</param>
        /// <param name="rec"> Флаг рекурсивного поиска файлов</param>
        // TODO: public FileInfo[] GetFiles(DirectoryInfo dir, string ext, bool rec = false);

        /// <summary>
        /// Единицы измерения памяти
        /// </summary>
        public enum MemUnits{ Bytes = 0, KBytes = 1, MBytes = 2, GBytes = 3 }

        /// <summary>
        /// Получает количество единиц памяти в файле
        /// </summary>
        /// <returns> Количество единиц измерения в файле</returns>
        /// <param name="file"> Данные файла</param>
        /// <param name="units"> Единицы измерения памяти</param>
        // TODO: public uint GetMemLength(FileInfo file, out MemUnits units);

        /// <summary>
        /// Выводит данные файла в заданный поток вывода
        /// </summary>
        /// <param name="output"> Поток вывода</param>
        /// <param name="file"> Файл данные которого нужно вывести</param>
        // TODO: public void PrintFileData(TextWriter output, FileInfo file);

      }
}
