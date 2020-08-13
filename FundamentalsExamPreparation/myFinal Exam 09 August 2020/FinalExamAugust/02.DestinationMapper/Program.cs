using System;
using System.Text.RegularExpressions;

namespace _02.DestinationMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Regex fullMatch = new Regex(@"(=|\/)(?<name>[A-Z][a-z]{2,})\1");
            Regex names = new Regex(@"[A-Z][a-z]+");

            var matches = fullMatch.Matches(text);
            int points = 0;
            string test = String.Empty;
            foreach (Match match in matches)
            {
                points += match.Groups["name"].Value.Length;
                test += match;
            }
            foreach (Match item in names.Matches(test))
            {
                Console.WriteLine(item.Value);
            }
        }
    }
}
