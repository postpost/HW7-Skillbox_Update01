using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Streams
{
    class Program
    {
        static void AddNewNote()
        {
            string path = "newStaff.txt";
            char key = 'д';
            int ID = 0;

            if (File.Exists(path))
            {
                ID = File.ReadAllLines(path).Length;
            }

            using (StreamWriter sw = new StreamWriter(path, true, Encoding.Unicode))
            {
                do
                {
                    string note = string.Empty;
                    note += $"{++ID}#";

                    string dateTime = DateTime.Now.ToShortDateString();
                    note += $"{dateTime}#";

                    Console.WriteLine("\nФ.И.О.");
                    string fullName = Console.ReadLine();
                    note += $"{fullName}#";

                    Console.WriteLine("Возраст");
                    string age = Convert.ToString(Console.ReadLine());
                    note += $"{age}#";

                    Console.WriteLine("Рост");
                    string height = Console.ReadLine();
                    note += $"{height}#";

                    Console.WriteLine("Дата рождения");
                    DateTime birthday;
                    while (!DateTime.TryParse(Console.ReadLine(), out birthday))
                    {
                        Console.WriteLine("Неверный формат даты. Введите в формате ДД.ММ.ГГГГ:");
                    }
                    note += $"{birthday.ToShortDateString()}#";

                    Console.WriteLine("Место рождения");
                    string placeOfBirthday = Console.ReadLine();
                    note += $"{placeOfBirthday}\t";

                    sw.WriteLine(note);
                    Console.Write("Продолжить н/д?");
                    key = Console.ReadKey(true).KeyChar;
                } while (char.ToLower(key) == 'д');
            }
        }

        static void ReadFile(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("Файла не существует. Нажмите 2 для создания файла и добавления новой заметки.");
            }
            else
            {
                using (StreamReader sr = new StreamReader(path, Encoding.Unicode))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] data = line.Split('#');
                        foreach (var item in data) Console.WriteLine(item);
                    };
                }
            }

        }
        static void Main(string[] args)
        {

        }
    }
}
