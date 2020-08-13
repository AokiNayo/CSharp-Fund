using System;
using System.Linq;
using System.Text;

namespace _01.EmailValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string userEmail = Console.ReadLine();
            string cmd = String.Empty;

            while ((cmd = Console.ReadLine()) != "Complete")
            {
                string[] cmdArgs = cmd.Split();
                string cmdName = cmdArgs[0];

                switch (cmdName)
                {
                    case "Make":
                        userEmail = UpperOrLower(userEmail, cmdArgs);
                        break;
                    case "GetDomain":
                        GetDomain(userEmail, cmdArgs);
                        break;
                    case "GetUsername":
                        GetUserName(userEmail);
                        break;
                    case "Replace":
                        userEmail = Replace(userEmail, cmdArgs);
                        break;
                    case "Encrypt":
                        Encrypt(userEmail);
                        break;
                }
            }
        }

        public static string UpperOrLower(string userEmail, string[] cmdArgs)
        {
            if (cmdArgs[1].Contains("Upper"))
            {
                userEmail = userEmail.ToUpper();
            }
            else if (cmdArgs[1].Contains("Lower"))
            {
                userEmail = userEmail.ToLower();
            }
            Console.WriteLine(userEmail);
            return userEmail;
        }
        public static void GetDomain(string userEmail, string[] cmdArgs)
        {
            int count = int.Parse(cmdArgs[1]);
            string substring = userEmail.Substring(userEmail.Length - count);
            Console.WriteLine(substring);
        }
        public static void GetUserName(string userEmail)
        {
            if (userEmail.Contains('@'))
            {
                int signIndex = userEmail.IndexOf('@');
                string username = userEmail.Substring(0, signIndex);
                Console.WriteLine(username);
            }
            else
            {
                Console.WriteLine($"The email {userEmail} doesn't contain the @ symbol.");
            }
        }
        public static string Replace(string userEmail, string[] cmdArgs)
        {
            char charToReplace = char.Parse(cmdArgs[1]);
            userEmail = userEmail.Replace(charToReplace, '-');
            Console.WriteLine(userEmail);
            return userEmail;

        }
        public static string Encrypt(string userEmail)
        {
            char[] charArray = userEmail.ToCharArray();
            StringBuilder encrypted = new StringBuilder();

            for (int i = 0; i < charArray.Length; i++)
            {
                encrypted.Append((int)charArray[i] + " ");
            }
            Console.WriteLine(encrypted);
            return userEmail;

        }
    }
}
