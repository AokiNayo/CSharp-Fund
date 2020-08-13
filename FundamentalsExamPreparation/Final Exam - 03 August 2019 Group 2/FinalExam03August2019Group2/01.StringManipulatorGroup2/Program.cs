using System;

namespace _01.StringManipulatorGroup2
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string cmd = String.Empty;

            while ((cmd = Console.ReadLine()) != "Done")
            {
                string[] cmdArgs = cmd.Split();
                string cmdName = cmdArgs[0];

                switch (cmdName)
                {
                    case "Change":
                        message = Change(message, cmdArgs);
                        break;
                    case "Includes":
                        Includes(message, cmdArgs);
                        break;
                    case "End":
                        End(message, cmdArgs);
                        break;
                    case "Uppercase":
                        message = Upper(message);
                        break;
                    case "FindIndex":
                        FindIndex(message, cmdArgs);
                        break;
                    case "Cut":
                        message = Cut(message, cmdArgs);
                        break;
                }
            }
        }

        static string Change(string message, string[] cmdArgs)
        {
            char currentChar = char.Parse(cmdArgs[1]);
            char toReplaceWith = char.Parse(cmdArgs[2]);

            message = message.Replace(currentChar, toReplaceWith);
            Console.WriteLine(message);
            return message;
        }
        static void Includes(string message, string[] cmdArgs)
        {
            string substring = cmdArgs[1];
            Console.WriteLine(message.Contains(substring));
        }
        static void End(string message, string[] cmdArgs)
        {
            string substring = cmdArgs[1];
            Console.WriteLine(message.EndsWith(substring));

            //int endIndex = message.LastIndexOf(substring);
            //string endSubstring = message.Substring(endIndex, substring.Length);
        }
        static string Upper(string message)
        {
            message = message.ToUpper();
            Console.WriteLine(message);
            return message;
        }
        static void FindIndex(string message, string[] cmdArgs)
        {
            char charToFind = char.Parse(cmdArgs[1]);
            int index = message.IndexOf(charToFind);
            Console.WriteLine(index);
        }
        static string Cut(string message, string[] cmdArgs)
        {
            int startIndex = int.Parse(cmdArgs[1]);
            int length = int.Parse(cmdArgs[2]);
            string substring = message.Substring(startIndex, length);
            message = substring;
            Console.WriteLine(message);
            return message;
        }
    }
}
