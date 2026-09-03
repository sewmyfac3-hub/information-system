using System;

namespace SeaObjectApp
{
    public class Sea
    {
        public string Name { get; set; }
        public double Depth { get; set; }
        public double Salinity { get; set; }

        public override string ToString()
        {
            return $"Море: {Name} | Глубина: {Depth} м | Соленость: {Salinity} ‰";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Программа учета морей ===");
            Console.WriteLine("Вводите данные строк за строкой. Например, Черное море 2845,5 12,4 " +
                "Для завершения нажмите Enter на пустой строке.\n");

            while (true)
            {
                Console.Write("Ввод: ");
                string input = Console.ReadLine();

                // Прерываем цикл, если введена пустая строка
                if (string.IsNullOrWhiteSpace(input))
                {
                    break;
                }

                // Извлекаем название между первыми и последними кавычками
                int firstQuote = input.IndexOf('"');
                int lastQuote = input.LastIndexOf('"');
                string name = input.Substring(firstQuote + 1, lastQuote - firstQuote - 1);

                // Извлекаем оставшиеся числа после кавычек
                string rest = input.Substring(lastQuote + 1).Trim();
                string[] numbers = rest.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                // Создаем объект без проверок
                Sea sea = new Sea
                {
                    Name = name,
                    Depth = double.Parse(numbers[0]),
                    Salinity = double.Parse(numbers[1])
                };

                Console.WriteLine($"Создан объект -> {sea}\n");
            }
        }
    }
}