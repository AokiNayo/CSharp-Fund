using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02.MessageTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Regex regex = new Regex(@"!(?<command>[A-Z][a-z]{2,})!:\[(?<message>[A-Za-z]{8,})]");
            List<int> encryptedMessage = new List<int>();
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                if (regex.IsMatch(input))
                {
                    var match = regex.Match(input);
                    string message = match.Groups["message"].Value;
                    string command = match.Groups["command"].Value;

                    for (int j = 0; j < message.Length; j++)
                    {
                        encryptedMessage.Add(message[j]);
                    }
                    Console.Write($"{command}: ");
                    Console.WriteLine(String.Join(" ", encryptedMessage));
                }
                else
                {
                    Console.WriteLine("The message is invalid");
                }
            }

        }
    }
}
