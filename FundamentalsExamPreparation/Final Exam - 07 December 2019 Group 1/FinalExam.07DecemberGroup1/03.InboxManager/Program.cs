using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.InboxManager
{
    class Program
    {
        static void Main(string[] args)
        {
            string cmd = String.Empty;

            Dictionary<string, Users> userSent = new Dictionary<string, Users>();

            while ((cmd = Console.ReadLine()) != "Statistics")
            {
                string[] cmdArgs = cmd.Split("->", StringSplitOptions.RemoveEmptyEntries);
                string cmdName = cmdArgs[0];

                switch (cmdName)
                {
                    case "Add":
                        Users.AddUsername(userSent, cmdArgs);
                        break;
                    case "Send":
                        Users.SendEmail(userSent, cmdArgs);
                        break;
                    case "Delete":
                        Users.DeleteUsername(userSent, cmdArgs);
                        break;
                }
            }

            Console.WriteLine($"Users count: {userSent.Count}");

            foreach (var user in userSent.OrderByDescending(x => x.Value.EmailCount).ThenBy(x => x.Key))
            {
                Console.WriteLine(user.Key);

                foreach (var message in user.Value.Email)
                {
                    Console.WriteLine($" - {message}");
                }
            }
        }

        class Users
        {
            public string Username { get; set; }
            public List<string> Email { get; set; }
            public int EmailCount { get; set; }

            public static void AddUsername(Dictionary<string, Users> userSent, string[] cmdArgs)
            {
                string username = cmdArgs[1];

                if (userSent.ContainsKey(username))
                {
                    Console.WriteLine($"{username} is already registered");
                }
                else
                {
                    userSent.Add(username, new Users() { Username = username, Email = new List<string>(), EmailCount = 0 });
                }
            }
            public static void SendEmail(Dictionary<string, Users> userSent, string[] cmdArgs)
            {
                string username = cmdArgs[1];
                string email = cmdArgs[2];

                if (userSent.ContainsKey(username))
                {
                    userSent[username].Email.Add(email);
                    userSent[username].EmailCount++;
                }
            }
            public static void DeleteUsername(Dictionary<string, Users> userSent, string[] cmdArgs)
            {
                string username = cmdArgs[1];

                if (userSent.ContainsKey(username))
                {
                    userSent.Remove(username);
                }
                else
                {
                    Console.WriteLine($"{username} not found!");
                }
            }
        }
    }
}
