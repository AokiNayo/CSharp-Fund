using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Followers
{
    class Program
    {
        static void Main(string[] args)
        {
            string cmd = String.Empty;

            Dictionary<string, Followers> socialMedia = new Dictionary<string, Followers>();

            while ((cmd = Console.ReadLine()) != "Log out")
            {
                string[] cmdArgs = cmd.Split(": ", StringSplitOptions.RemoveEmptyEntries);
                string cmdName = cmdArgs[0];

                switch (cmdName)
                {
                    case "New follower":
                        Followers.NewFollower(socialMedia, cmdArgs);
                        break;
                    case "Like":
                        Followers.Like(socialMedia, cmdArgs);
                        break;
                    case "Comment":
                        Followers.Comment(socialMedia, cmdArgs);
                        break;
                    case "Blocked":
                        Followers.Block(socialMedia, cmdArgs);
                        break;
                }
            }

            Console.WriteLine($"{socialMedia.Count} followers");

            foreach (var user in socialMedia.OrderByDescending(x => x.Value.Likes)
                .ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value))
            {
                Console.WriteLine($"{user.Key}: {user.Value.Likes + user.Value.Comments}");
            }
        }

        class Followers
        {
            public string Username { get; set; }
            public int Likes { get; set; }
            public int Comments { get; set; }

            public static void NewFollower(Dictionary<string, Followers> socialMedia, string[] cmdArgs)
            {
                if (!socialMedia.ContainsKey(cmdArgs[1]))
                {
                    socialMedia.Add(cmdArgs[1], new Followers() { Username = cmdArgs[1], Likes = 0, Comments = 0 });
                }
            }
            public static void Like(Dictionary<string, Followers> socialMedia, string[] cmdArgs)
            {
                if (socialMedia.ContainsKey(cmdArgs[1]))
                {
                    socialMedia[cmdArgs[1]].Likes += int.Parse(cmdArgs[2]);
                }
                else
                {
                    socialMedia.Add(cmdArgs[1], new Followers() { Username = cmdArgs[1], Likes = int.Parse(cmdArgs[2]), Comments = 0 });
                }
            }
            public static void Comment(Dictionary<string, Followers> socialMedia, string[] cmdArgs)
            {
                if (socialMedia.ContainsKey(cmdArgs[1]))
                {
                    socialMedia[cmdArgs[1]].Comments++;
                }
                else
                {
                    socialMedia.Add(cmdArgs[1], new Followers() { Username = cmdArgs[1], Likes = 0, Comments = 1 });
                }
            }
            public static void Block(Dictionary<string, Followers> socialMedia, string[] cmdArgs)
            {
                if (socialMedia.ContainsKey(cmdArgs[1]))
                {
                    socialMedia.Remove(cmdArgs[1]);
                }
                else
                {
                    Console.WriteLine($"{cmdArgs[1]} doesn't exist.");
                }
            }
        }
    }
}
