using System;
using System.Collections.Generic;
using System.Linq;

namespace HexagonalRealEstate.Views.Helpers
{
    public static class View
    {
        public static void DoAChoice(string title, Dictionary<string, Action> choices)
        {
            do
            {
                Console.WriteLine(title);

                var mapping = new Dictionary<int, string>();
                var selectionNumber = 0;
                foreach (var choice in choices)
                {
                    var text = choice.Key;
                    selectionNumber++;
                    mapping.Add(selectionNumber, choice.Key);
                    Console.WriteLine($"{selectionNumber} : {text}");
                }
                Console.WriteLine("10 : Go Back");

                Console.Write("Your choice : ");
                var selection = Console.ReadLine() ?? string.Empty;
                if (!selection.All(char.IsDigit))
                {
                    Console.WriteLine("Select a number");
                    continue;
                }

                var index = Int16.Parse(selection);

                if ((index < 1 || index > selectionNumber) && index != 10)
                {
                    Console.WriteLine("Select a number in the list");
                    continue;
                }

                if (index == 10)
                {
                    break;
                }

                var key = mapping[index];
                choices[key]();
            } while (true);
        }

        public static TSource DoAChoice<TSource>(string title, IEnumerable<TSource> choices)
        {
            do
            {
                Console.WriteLine(title);

                var mapping = new Dictionary<int, TSource>();
                var selectionNumber = 0;
                foreach (var choice in choices)
                {
                    selectionNumber++;
                    mapping.Add(selectionNumber, choice);
                    Console.WriteLine($"{selectionNumber} : {choice}");
                }

                Console.Write("Your choice : ");
                var selection = Console.ReadLine() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(selection))
                {
                    Console.WriteLine("The choice can't be empty");
                    continue;
                }

                if (!selection.All(char.IsDigit))
                {
                    Console.WriteLine("Select a number");
                    continue;
                }

                var index = int.Parse(selection);

                if ((index < 1 || index > selectionNumber) && index != 10)
                {
                    Console.WriteLine("Select a number in the list");
                    continue;
                }

                return mapping[index];
            } while (true);
        }

        public static bool YesNoChoice(string title)
        {
            do
            {
                Console.WriteLine(title);
                Console.WriteLine("1 : Yes");
                Console.WriteLine("2 : No");
                var selection = Console.ReadLine() ?? string.Empty;
                if (selection == "1")
                {
                    return true;
                }

                if (selection == "2")
                {
                    return false;
                }

                Console.WriteLine("Select a number in the list");
            } while (true);
        }

        public static int GetInt(string title)
        {
            string result;
            do
            {
                Console.Write($"{title} : ");
                result = Console.ReadLine();
                var selection = Console.ReadLine() ?? string.Empty;
                if (!selection.All(char.IsDigit))
                {
                    Console.WriteLine("Select a number");
                }
                else
                {
                    break;
                }
            } while (true);

            return int.Parse(result);
        }

        public static string GetString(string title)
        {
            Console.Write($"{title} : ");
            var line = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(line))
            {
                return null;
            }

            return line;
        }
    }
}
