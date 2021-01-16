using System;

namespace FinalExam15August
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string cmd = String.Empty;

            while ((cmd = Console.ReadLine()) != "Decode")
            {
                string[] cmdArgs = cmd.Split('|', StringSplitOptions.RemoveEmptyEntries);
                string cmdName = cmdArgs[0];

                switch (cmdName)
                {
                    case "Move":
                        message = Move(message, cmdArgs);
                        break;
                    case "Insert":
                        message = Insert(message, cmdArgs);
                        break;
                    case "ChangeAll":
                        message = ChangeAll(message, cmdArgs);
                        break;
                }
            }
            Console.WriteLine($"The decrypted message is: {message}");
        }

        public static string Move(string message, string[] cmdArgs)
        {
            int n = int.Parse(cmdArgs[1]); // Finish here

            string temp = message.Substring(0, n);
            message = message.Remove(0, n);
            message = message + temp;

            return message;
        }
        public static string Insert(string message, string[] cmdArgs)
        {
            int index = int.Parse(cmdArgs[1]);
            string value = cmdArgs[2];

            message = message.Insert(index, value);
            return message;
        }
        public static string ChangeAll(string message, string[] cmdArgs)
        {
            string substring = cmdArgs[1];
            string replacement = cmdArgs[2];

            if (message.Contains(substring))
            {
                message = message.Replace(substring, replacement);
            }
            return message;
        }
    }
}
