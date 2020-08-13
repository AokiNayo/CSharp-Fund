using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.Password
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Regex regex = new Regex(@"^(.+?)>(?<first>\d{3})\|(?<second>[a-z]{3})\|(?<third>[A-Z]{3})\|(?<fourth>[^<>]{3})<\1$");

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                if (regex.IsMatch(input))
                {
                    var match = regex.Match(input);

                    StringBuilder sb = new StringBuilder();

                    sb.Append(match.Groups["first"].Value);
                    sb.Append(match.Groups["second"].Value);
                    sb.Append(match.Groups["third"].Value);
                    sb.Append(match.Groups["fourth"].Value);

                    Console.WriteLine($"Password: {sb}");
                }
                else
                {
                    Console.WriteLine("Try another password!");
                }
            }

        }
    }
}
