using System;
using System.Linq;

namespace _01.NikuldensCharity
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string action = String.Empty;

            while ((action = Console.ReadLine()) != "Finish")
            {
                string[] actionArgs = action.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string actionName = actionArgs[0];
                switch (actionName)
                {
                    case "Replace":
                        text = Replace(text, actionArgs);
                        break;
                    case "Cut":
                        text = Cut(text, actionArgs);
                        break;
                    case "Make":
                        text = Make(text, actionArgs);
                        break;
                    case "Check":
                        text = Check(text, actionArgs);
                        break;
                    case "Sum":
                        Sum(text, actionArgs);
                        break;
                }


            }
        }

        public static string Replace(string text, string[] actionArgs)
        {
            char currentChar = char.Parse(actionArgs[1]);
            char newChar = char.Parse(actionArgs[2]);

            text = text.Replace(currentChar, newChar);
            Console.WriteLine(text);
            return text;

        }
        public static string Cut(string text, string[] actionArgs)
        {
            int start = int.Parse(actionArgs[1]);
            int end = int.Parse(actionArgs[2]);

            if (start >= 0 && start < text.Length && end >= 0 && end < text.Length)
            {
                text = text.Remove(start, end - start + 1);
                Console.WriteLine(text);
            }
            else
            {
                Console.WriteLine("Invalid indexes!");
            }
            return text;
        }
        public static string Make(string text, string[] actionArgs)
        {
            if (actionArgs[1].Contains("Upper"))
            {
                text = text.ToUpper();
            }
            else if (actionArgs[1].Contains("Lower"))
            {
                text = text.ToLower();
            }
            Console.WriteLine(text);
            return text;
        }
        public static string Check(string text, string[] actionArgs)
        {
            string toCheck = actionArgs[1];

            if (text.Contains(toCheck))
            {
                Console.WriteLine($"Message contains {toCheck}");
            }
            else
            {
                Console.WriteLine($"Message doesn't contain {toCheck}");
            }
            return text;
        }
        public static void Sum(string text, string[] actionArgs)
        {
            int start = int.Parse(actionArgs[1]);
            int end = int.Parse(actionArgs[2]);
            if (start >= 0 && start < text.Length && end >= 0 && end < text.Length)
            {
                string substring = text.Substring(start, end - start + 1);
                int sum = 0;

                for (int i = 0; i < substring.Length; i++)
                {
                    sum += substring[i];
                }

                Console.WriteLine(sum);
            }
            else
            {
                Console.WriteLine("Invalid indexes!");
            }
        }
    }
}
