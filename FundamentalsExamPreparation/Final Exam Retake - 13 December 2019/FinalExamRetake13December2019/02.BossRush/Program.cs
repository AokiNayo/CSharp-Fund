using System;
using System.Text.RegularExpressions;

namespace _02.BossRush
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Regex regex = new Regex(@"\|(?<bossName>[A-Z]{4,})\|:#(?<title>[A-Za-z]+ [A-Za-z]+)#");

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                if (regex.IsMatch(input))
                {
                    var match = regex.Match(input);
                    string bossName = match.Groups["bossName"].Value;
                    string bossTitle = match.Groups["title"].Value;

                    Console.WriteLine($"{bossName}, The {bossTitle}");
                    Console.WriteLine($">> Strength: {bossName.Length}");
                    Console.WriteLine($">> Armour: {bossTitle.Length}");
                }
                else
                {
                    Console.WriteLine("Access denied!");
                }
            }
        }
    }
}
