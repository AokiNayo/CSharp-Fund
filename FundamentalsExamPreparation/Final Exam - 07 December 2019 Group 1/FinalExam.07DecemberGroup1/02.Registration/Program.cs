using System;
using System.Text.RegularExpressions;

namespace _02.Registration
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Regex regex = new Regex(@"U\$(?<username>[A-Z][a-z]{2,})U\$P\@\$(?<password>[A-Za-z]{5,}\d+)P\@\$");
            int totalRegistrations = 0;

            for (int i = 0; i < n; i++)
            {
                string userArgs = Console.ReadLine();

                if (regex.IsMatch(userArgs))
                {
                    var validRegistration = regex.Match(userArgs);
                    string username = validRegistration.Groups["username"].Value;
                    string password = validRegistration.Groups["password"].Value;
                    totalRegistrations++;

                    Console.WriteLine("Registration was successful");
                    Console.WriteLine($"Username: {username}, Password: {password}");
                }
                else
                {
                    Console.WriteLine("Invalid username or password");
                }
            }
            Console.WriteLine($"Successful registrations: {totalRegistrations}");
        }
    }
}
