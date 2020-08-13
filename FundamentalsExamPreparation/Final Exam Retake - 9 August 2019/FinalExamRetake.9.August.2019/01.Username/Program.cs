using System;
using System.Linq;

namespace _01.Username
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();

            string cmd = String.Empty;

            while ((cmd = Console.ReadLine()) != "Sign up")
            {
                string[] cmdArgs = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string cmdName = cmdArgs[0];
                switch (cmdName)
                {
                    case "Case":
                        username = Case(username, cmdArgs);
                        break;
                    case "Reverse":
                        Reverse(username, cmdArgs);
                        break;
                    case "Cut":
                        username = Cut(username, cmdArgs);
                        break;
                    case "Replace":
                        username = Replace(username, cmdArgs);
                        break;
                    case "Check": Check(username, cmdArgs);
                        break;
                }
            }
        }

        public static string Case(string username, string[] cmdArgs)
        {
            if (cmdArgs[1].Contains("lower"))
            {
                username = username.ToLower();
            }
            else if (cmdArgs[1].Contains("upper"))
            {
                username = username.ToUpper();
            }
            Console.WriteLine(username);
            return username;
        }
        public static void Reverse(string username, string[] cmdArgs)
        {
            int start = int.Parse(cmdArgs[1]);
            int end = int.Parse(cmdArgs[2]);

            if (start >= 0 && end >= 0 && start < username.Length && end < username.Length)
            {
                var reversedSubstring = username.Substring(start, end - start + 1).ToCharArray();
                Array.Reverse(reversedSubstring);
                Console.WriteLine(reversedSubstring);
            }
        }
        public static string Cut(string username, string[] cmdArgs)
        {
            string substring = cmdArgs[1];

            if (username.Contains(substring))
            {
                int toCut = username.IndexOf(substring);
                username = username.Remove(toCut, substring.Length);
                Console.WriteLine(username);
            }
            else
            {
                Console.WriteLine($"The word {username} doesn't contain {substring}.");
            }

            return username;
        }
        public static string Replace(string username, string[] cmdArgs)
        {
            char charToReplace = char.Parse(cmdArgs[1]);
            username = username.Replace(charToReplace, '*');
            Console.WriteLine(username);
            return username;
        }
        public static void Check(string username, string[] cmdArgs)
        {
            char toCheck = char.Parse(cmdArgs[1]);
            if (username.Contains(toCheck))
            {
                Console.WriteLine("Valid");
            }
            else
            {
                Console.WriteLine($"Your username must contain {toCheck}.");
            }
        }
    }
}
