using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.AdAstra
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            Regex regex = new Regex(@"(#|\|)(?<name>[A-Za-z ]+)\1(?<date>[0-9]{2}\/[0-9]{2}\/[0-9]{2})\1(?<calories>\d+)\1");

            var matches = regex.Matches(message);
            int calories = 0;

            foreach (Match match in matches)
            {
                calories += int.Parse(match.Groups["calories"].Value);
            }
            Console.WriteLine($"You have food to last you for: {calories / 2000} days!");
            foreach (Match kvp in matches)
            {
                Console.WriteLine($"Item: {kvp.Groups["name"].Value}, Best before: {kvp.Groups["date"].Value}, Nutrition: {kvp.Groups["calories"].Value}");
            }

        }
    }
}
