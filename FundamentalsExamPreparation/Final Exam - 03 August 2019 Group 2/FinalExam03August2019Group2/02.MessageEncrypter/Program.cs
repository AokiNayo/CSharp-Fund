using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.MessageEncrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Regex regex = new Regex(@"(\*|@)([A-Z][a-z]{2,})\1: \[([A-Za-z])\]\|\[([A-Za-z])\]\|\[([A-Za-z])\]\|$");

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                if (regex.IsMatch(input))
                {
                    var match = regex.Match(input);
                    StringBuilder sb = new StringBuilder();

                    int first = char.Parse(match.Groups[3].Value);
                    int second = char.Parse(match.Groups[4].Value);
                    int third = char.Parse(match.Groups[5].Value);

                    Console.WriteLine($"{match.Groups[2].Value}: {first} {second} {third}");
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
    }
}
