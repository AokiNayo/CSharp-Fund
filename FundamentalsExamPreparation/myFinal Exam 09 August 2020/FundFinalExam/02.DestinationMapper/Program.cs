using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02.DestinationMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Regex regex = new Regex(@"(=|\/)(?<name>[A-Z][A-Za-z]{2,})\1");

            var matches = regex.Matches(input);
            int totalPoints = 0;

            List<string> test = new List<string>();

            foreach (Match item in matches)
            {
                totalPoints += item.Groups["name"].Value.Length;
                test.Add(item.Groups["name"].Value);
            }

            Console.Write("Destinations: ");
            Console.WriteLine(String.Join(", ", test));
            Console.WriteLine($"Travel Points: {totalPoints}");
        }
    }
}
