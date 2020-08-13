using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.BattleManager
{
    class Program
    {
        static void Main(string[] args)
        {
            string cmd = String.Empty;
            Dictionary<string, Champions> championsList = new Dictionary<string, Champions>();

            while ((cmd = Console.ReadLine()) != "Results")
            {
                string[] cmdArgs = cmd.Split(':', StringSplitOptions.RemoveEmptyEntries);
                string cmdName = cmdArgs[0];

                switch (cmdName)
                {
                    case "Add":
                        Champions.Add(championsList, cmdArgs);
                        break;
                    case "Attack":
                        Champions.Attack(championsList, cmdArgs);
                        break;
                    case "Delete":
                        Champions.Delete(championsList, cmdArgs);
                        break;
                }
            }

            Console.WriteLine($"People count: {championsList.Count}");

            foreach (var champion in championsList.OrderByDescending(x => x.Value.Health).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{champion.Key} - {champion.Value.Health} - {champion.Value.Energy}");
            }
        }

        class Champions
        {
            public string Name { get; set; }
            public int Health { get; set; }
            public int Energy { get; set; }

            public static void Add(Dictionary<string, Champions> championsList, string[] cmdArgs)
            {
                string name = cmdArgs[1];
                int health = int.Parse(cmdArgs[2]);
                int energy = int.Parse(cmdArgs[3]);

                if (championsList.ContainsKey(name))
                {
                    championsList[name].Health += health;
                }
                else
                {
                    championsList.Add(name, new Champions() { Name = name, Health = health, Energy = energy });
                }

            }
            public static void Attack(Dictionary<string, Champions> championsList, string[] cmdArgs)
            {
                string attackerName = cmdArgs[1];
                string defenderName = cmdArgs[2];
                int damage = int.Parse(cmdArgs[3]);

                if (championsList.ContainsKey(attackerName) && championsList.ContainsKey(defenderName))
                {
                    championsList[defenderName].Health -= damage;
                    championsList[attackerName].Energy -= 1;

                    if (championsList[defenderName].Health <= 0)
                    {
                        championsList.Remove(defenderName);
                        Console.WriteLine($"{defenderName} was disqualified!");
                    }
                    if (championsList[attackerName].Energy == 0)
                    {
                        championsList.Remove(attackerName);
                        Console.WriteLine($"{attackerName} was disqualified!");
                    }
                }

            }
            public static void Delete(Dictionary<string, Champions> championsList, string[] cmdArgs)
            {
                string name = cmdArgs[1];

                if (championsList.ContainsKey(name))
                {
                    championsList.Remove(name);
                }
                else if (name == "All")
                {
                    championsList.Clear();
                }
            }
        }
    }
}
