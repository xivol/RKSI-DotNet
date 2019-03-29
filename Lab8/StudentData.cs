using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Lab8
{

    public enum Gender { Male, Female, Other }

    public class StudentData
    {
        #region Личные данные

        /// <summary>
        /// Имя
        /// Ограничения:
        /// Не пустое
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Пол
        /// Ограничения:
        /// Не пустой
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Дата рождения
        /// Ограничения:
        /// Между 1900 и текущей датой
        /// </summary>
        public DateTime BirthDay { get; set; }

        /// <summary>
        /// Серия и номер пасспорта
        /// Ограничения:
        /// Должны быть в формате 0000 000000
        /// </summary>
        public string Passport { get; set; }
        #endregion

        #region Контактные данные

        /// <summary>
        /// Список городов
        /// </summary>
        public static string AllCities = Properties.Resources.Cities;

        /// <summary>
        /// Город проживания
        /// Ограничения:
        /// Один из городов в файле Cities.txt
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Адрес проживания 
        /// Ограничения:
        /// не может быть пустым
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Формат телефона
        /// </summary>
        public static string PhoneFormat = @"\+7\s\(\d\d\d\)\s\d\d\d-\d\d-\d\d";

        /// <summary>
        /// Контактный телефон
        /// Ограничения:
        /// Должен быть в формате +7 (000) 000-00-00
        /// </summary>
        public string Phone { get; set; }


        /// <summary>
        /// Адрес эл. почты
        /// Ограничения:
        /// Должен быть в формате ab@abc.ab
        /// </summary>
        public string Email { get; set; }
        #endregion

        #region Данные об обучении

        /// <summary>
        /// Список направлений обучения
        /// </summary>
        public static object AllTracks = Properties.Resources.Tracks;

        /// <summary>
        /// Направление обучения
        /// Ограничения:
        /// Должно быть одним из файла Tracks.txt
        /// </summary>
        public string Track { get; set; }

        /// <summary>
        /// Учебный курс
        /// Ограничения:
        /// 1-4
        /// </summary>
        public int Course { get; set; }

        /// <summary>
        /// Учебная группа
        /// Ограничения:
        /// 1-9
        /// </summary>
        public int Group { get; set; }

        #endregion
    }
}
