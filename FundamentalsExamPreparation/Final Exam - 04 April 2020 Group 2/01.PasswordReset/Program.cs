using System;

namespace _01.PasswordReset
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            string newPassword = String.Empty;
            string command = String.Empty;

            while ((command = Console.ReadLine()) != "Done")
            {
                string[] commArr = command.Split();
                string commandName = commArr[0];

                if (commandName == "TakeOdd")
                {
                    for (int i = 1; i < password.Length; i += 2)
                    {
                        newPassword += password[i];
                    }
                    password = newPassword;
                    Console.WriteLine(password);
                }
                else if (commandName == "Cut")
                {
                    int index = int.Parse(commArr[1]);
                    int length = int.Parse(commArr[2]);

                    password = password.Remove(index, length);
                    Console.WriteLine(password);
                }
                else if (commandName == "Substitute")
                {
                    string substring = commArr[1];
                    string toReplace = commArr[2];

                    if (password.IndexOf(substring) >= 0)
                    {
                        password = password.Replace(substring, toReplace);
                        Console.WriteLine(password);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                }
            }
            Console.WriteLine($"Your password is: {password}");
        }
    }
}
