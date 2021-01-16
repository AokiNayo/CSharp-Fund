using System;

namespace _01.ImitationGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string cmd = String.Empty;

            while ((cmd = Console.ReadLine()) != "Decode")
            {
                string[] cmdArgs = cmd.Split('|');
                string cmdName = cmdArgs[0];

                if (cmdName == "Move")
                {
                    int n = int.Parse(cmdArgs[1]);

                    string temp = message.Substring(0, n);
                    message = message.Remove(0, n);
                    message = message + temp;
                }
                else if (cmdName == "Insert")
                {
                    int index = int.Parse(cmdArgs[1]);
                    string value = cmdArgs[2];

                    message = message.Insert(index, value);
                }
                else if (cmdName == "ChangeAll")
                {
                    string substring = cmdArgs[1];
                    string replacement = cmdArgs[2];

                    if (message.Contains(substring))
                    {
                        message = message.Replace(substring, replacement);
                    }
                }
            }
            Console.WriteLine($"The decrypted message is: {message}");
        }
    }
}
