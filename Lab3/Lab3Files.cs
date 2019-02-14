/*
 * Lab3
 * Файлы.
 *
 * Часть1. Разрабтать консольное приложение для вывода данных о файлах.
 * В результате должны выводиться данные в виде:
 * <имя файла>\t<дата создания>\t<длина файла>
 * 
 * Приложение должно принимать следующие ключи коммандной строки:
 *  -i "path": путь к анализируемому каталогу, обязательный параметр;
 *  -e "ext": расширение обрабатываемых файлов, необязательный параметр;
 *  -o "path": путь к выходному файлу, если задан этот ключ
 *             результат работы выводится в указанный файл, необязательный пааметр;
 *  -r: флаг указывающий на рекурсивную обработку всех подкаталогов по указанного пути,
 *      необязательный параметр;
 *  -?: вывод этой информации.
 *
 */
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
        // TODO: public static FileInfo[] GetFiles(DirectoryInfo dir, string ext, bool rec = false);

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
        // TODO: public static uint GetMemLength(FileInfo file, out MemUnits units);

        /// <summary>
        /// Выводит данные файла в заданный поток вывода
        /// </summary>
        /// <param name="output"> Поток вывода</param>
        /// <param name="file"> Файл данные которого нужно вывести</param>
        // TODO: public static void PrintFileData(TextWriter output, FileInfo file);

      }
}
