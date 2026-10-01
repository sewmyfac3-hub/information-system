using SeaObjectApp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace SeaObjectApp
{
    class Program
    {
        static List<Sea> objectsList = new List<Sea>();

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("\n=== МЕНЮ УПРАВЛЕНИЯ ===");
                Console.WriteLine("1. Ввести данные с клавиатуры");
                Console.WriteLine("2. Загрузить данные из файла");
                Console.WriteLine("3. Сохранить данные в файл");
                Console.WriteLine("4. Показать текущий список объектов");
                Console.WriteLine("5. Выйти из программы");
                Console.Write("Выберите действие (1-5): ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        InputFromConsole();
                        break;
                    case "2":
                        LoadFromFile();
                        break;
                    case "3":
                        SaveToFile();
                        break;
                    case "4":
                        DisplayObjects();
                        break;
                    case "5":
                        Console.WriteLine("Завершение работы программы.");
                        return;
                }
            }
        }

        static void InputFromConsole()
        {
            Console.WriteLine("Введите строку с описанием объекта:");
            string input = Console.ReadLine();
            Sea obj = ParseString(input);
            objectsList.Add(obj);
            Console.WriteLine("Объект успешно добавлен!");
        }

        static void LoadFromFile()
        {
            Console.Write("Введите имя файла для чтения: ");
            string filePath = Console.ReadLine();

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                Sea obj = ParseString(line);
                objectsList.Add(obj);
            }

            Console.WriteLine($"Загрузка завершена. Добавлено объектов: {lines.Length}");
        }

        static void SaveToFile()
        {
            Console.Write("Введите имя файла для сохранения: ");
            string filePath = Console.ReadLine();

            List<string> linesToSave = new List<string>();
            foreach (Sea obj in objectsList)
            {
                linesToSave.Add(obj.GetInfo());
            }

            File.WriteAllLines(filePath, linesToSave);
            Console.WriteLine($"Данные успешно сохранены в файл \"{filePath}\"!");
        }

        static void DisplayObjects()
        {
            Console.WriteLine("Текущий список объектов:");
            for (int i = 0; i < objectsList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {objectsList[i].GetInfo()}");
            }
        }

        static Sea ParseString(string text)
        {
            string[] parts = text.Split('"');
            string name = parts[1];
            string[] nums = parts[2].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            CultureInfo ci = CultureInfo.InvariantCulture;

            return new Sea
            {
                Name = name,
                Depth = Convert.ToDouble(nums[0], ci),
                Salinity = Convert.ToDouble(nums[1], ci)
            };
        }
    }
}