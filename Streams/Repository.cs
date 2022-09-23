using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Streams
{
    class Repository
    {
        /// <summary>
        /// Массив работников
        /// </summary>
        private Worker [] workers;

        /// <summary>
        /// Индекс
        /// </summary>
        private int index;

        /// <summary>
        /// Путь к файлу
        /// </summary>
        private string path;

        /// <summary>
        /// Метод увеличения размера массива
        /// </summary>
        /// <param name="Flag"></param>
        private void Resize (bool Flag)
        {
            if (Flag)
            {
                Array.Resize(ref workers,  this.workers.Length * 2);
            }
        }

        /// <summary>
        /// Метод извлечения записей из файла
        /// </summary>
        /// <param name="lines"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public Worker ParseWorkersFromFile(string lines, char separator = '#')
        {
            string[] args = lines.Split(separator);
            return new Worker
            {
                ID = int.Parse(args[0]),
                DateOfRecord = DateTime.Parse(args[1]),
                FullName = args[3],
                Age = int.Parse(args[4]),
                Height = ulong.Parse(args[5]),
                DateOfBirth = DateTime.Parse(args[6]),
                PlaceOfBirth = args[7]
            };
        }

        /// <summary>
        /// Метод выгрузки работников
        /// </summary>
        public void LoadWorkers()
        {
            using (StreamReader sr = new StreamReader(new FileStream (path, FileMode.OpenOrCreate, FileAccess.Read)))
            {
                while (!sr.EndOfStream)
                {
                    this.Resize(this.index > workers.Length);
                    this.workers[index] = ParseWorkersFromFile(sr.ReadLine());
                    index++;
                }
            }
        }

        /// <summary>
        /// Метод получения записи по номеру ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Worker GetWorkerById(int id)
        {
            LoadWorkers();
            Worker[] newList = this.workers;
            for(int i = 0; i< newList.Length; i++)
            {
                if (this.index == id) return newList[i];
            }

            Worker workerById = this.workers[index];
            return workerById;
        }

        /// <summary>
        /// Метод удаления записи по номеру ID
        /// </summary>
        /// <param name="id"></param>
        public void DeleteWorkerById(int id)
        {
            LoadWorkers();
            Worker[] newWorkersList = new Worker [this.workers.Length - 1];
            for (int i = 0; i<id; i++)
            {
                newWorkersList[i] = this.workers[i];
            }

            for(int i = id +1; i<this.workers.Length; i++)
            {
                newWorkersList[i - 1] = this.workers[i];
            }

            this.workers = newWorkersList;
        }

        /// <summary>
        /// Добавление работника в массив
        /// </summary>
        /// <param name="NewWorker"></param>
        public void AddWorker(Worker NewWorker)
        {
            this.Resize(index > this.workers.Length * 2);
            this.workers[index] = NewWorker;
            index++;
        }

        /// <summary>
        /// Метод выгрузки записей работников за период
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <returns></returns>
        public Worker[] GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo)
        {
            Worker[] newWorkers = new Worker[this.workers.Length];
            
            int count = 0;
            foreach(Worker w in newWorkers)
            {
                if (w.DateOfRecord.Date >= dateFrom.Date && w.DateOfRecord <= dateTo.Date)
                    count++;
            }

            Worker[] result = new Worker[count];

            int index = 0; 
            for (int i=0; i<newWorkers.Length; i++)
            {
                if(newWorkers[i].DateOfRecord.Date >= dateFrom.Date && newWorkers[i].DateOfRecord.Date <= dateTo.Date)
                {
                    result[index] = newWorkers[i];
                    index++;
                }
            }

            return result;
        }
    }
}
