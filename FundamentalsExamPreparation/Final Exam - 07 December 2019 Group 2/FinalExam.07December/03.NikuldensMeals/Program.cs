using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.NikuldensMeals
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = String.Empty;

            Dictionary<string, Guests> guestList = new Dictionary<string, Guests>();
            int unlikedCount = 0;

            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] commandArgs = command.Split('-', StringSplitOptions.RemoveEmptyEntries);
                string cmdName = commandArgs[0];

                switch (cmdName)
                {
                    case "Like":
                        Guests.LikedMeal(commandArgs, guestList);
                        break;
                    case "Unlike":
                        unlikedCount = Guests.UnlikedMeal(commandArgs, guestList, unlikedCount);
                        break;
                }
            }
            foreach (var guest in guestList.OrderByDescending(x => x.Value.LikedMeals.Count).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{guest.Key}: {String.Join(", ", guest.Value.LikedMeals)}");
            }
            Console.WriteLine($"Unliked meals: {unlikedCount}");
        }

        public class Guests
        {
            public string Name { get; set; }
            public List<string> LikedMeals { get; set; }
            public List<string> UnlikedMeals { get; set; }

            public static void LikedMeal(string[] cmdArgs, Dictionary<string, Guests> guestList)
            {
                string name = cmdArgs[1];
                string likedMeal = cmdArgs[2];

                if (guestList.ContainsKey(name))
                {
                    if (!guestList[name].LikedMeals.Contains(likedMeal))
                    {
                        guestList[name].LikedMeals.Add(likedMeal);
                    }
                }
                else
                {
                    guestList.Add(name, new Guests() { Name = name, LikedMeals = new List<string>() { likedMeal } });
                }
            }
            public static int UnlikedMeal(string[] cmdArgs, Dictionary<string, Guests> guestList, int unlikedCount)
            {
                string name = cmdArgs[1];
                string unlikedMeal = cmdArgs[2];

                if (guestList.ContainsKey(name))
                {
                    if (guestList[name].LikedMeals.Contains(unlikedMeal))
                    {
                        if (guestList[name].UnlikedMeals == null)
                        {
                            guestList[name].UnlikedMeals = new List<string>();
                        }

                        guestList[name].UnlikedMeals.Add(unlikedMeal);
                        guestList[name].LikedMeals.Remove(unlikedMeal);
                        unlikedCount++;
                        Console.WriteLine($"{name} doesn't like the {unlikedMeal}.");
                    }
                    else
                    {
                        Console.WriteLine($"{name} doesn't have the {unlikedMeal} in his/her collection.");

                    }
                }
                else
                {
                    Console.WriteLine($"{name} is not at the party.");
                }
                return unlikedCount;
            }

        }
    }
}
