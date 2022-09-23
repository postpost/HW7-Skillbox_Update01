using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streams
{
    struct Worker
    {
        #region Свойства
        /// <summary>
        /// Номер по порядку, присваивается автоматически
        /// </summary>
        public int ID { get {return this.id; } set { this.id = value; } }

        /// <summary>
        /// Дата и время добавления записи
        /// </summary>
        public DateTime DateOfRecord { get { return this.dateOfRecord; } set { this.dateOfRecord = value; } }

        /// <summary>
        /// Ф.И.О.
        /// </summary>
        public string FullName { get { return this.fullName; } set { this.fullName = value; } }

        /// <summary>
        ///Возраст
        /// </summary>
        public int Age { get { return this.age; } set { this.age = value; } }

        /// <summary>
        /// Рост
        /// </summary>
        public ulong Height { get { return this.height; } set { this.height = value; } }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime DateOfBirth { get { return this.dateOfBirth; } set { this.dateOfBirth = value; } }

        /// <summary>
        /// Место рождения
        /// </summary>
        public string PlaceOfBirth { get { return this.placeOfBirth; } set { this.placeOfBirth = value; } }
        #endregion

        #region Поля
        private int id;
        private DateTime dateOfRecord;
        private string fullName;
        private int age;
        private ulong height;
        private DateTime dateOfBirth;
        private string placeOfBirth;
        #endregion

        #region Конструкторы
        /// <summary>
        /// Конструктор с 7-ю параметрами
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="DateOfRecord"></param>
        /// <param name="FullName"></param>
        /// <param name="Age"></param>
        /// <param name="Height"></param>
        /// <param name="DateOfBirth"></param>
        /// <param name="PlaceOfBirth"></param>
        public Worker(string ID, string DateOfRecord, string FullName, string Age, string Height, string DateOfBirth, string PlaceOfBirth)
        {
            this.id = Convert.ToInt32(ID);
            this.dateOfRecord = Convert.ToDateTime(DateOfRecord);
            this.fullName = FullName;
            this.age = Convert.ToInt32(Age);
            this.height = Convert.ToUInt64(Height);
            this.dateOfBirth = Convert.ToDateTime(DateOfBirth);
            this.placeOfBirth = PlaceOfBirth;
        }

        /// <summary>
        /// Конструктор с 4-мя аргументами
        /// </summary>
        /// <param name="FullName"></param>
        /// <param name="Height"></param>
        /// <param name="DateOfBirth"></param>
        /// <param name="PlaceOfBirth"></param>
        public Worker(string FullName, ulong Height, DateTime DateOfBirth, string PlaceOfBirth):
            this ("0", DateTime.Now.ToString(), FullName, "0", Height.ToString(), DateOfBirth.ToShortDateString(), PlaceOfBirth)
            {
            int Age = DateTime.Today.Year - DateOfBirth.Year;
            if (DateOfBirth.AddYears(Age) > DateTime.Today) Age--;
            this.age = Age;
            }
        #endregion
    }
}
