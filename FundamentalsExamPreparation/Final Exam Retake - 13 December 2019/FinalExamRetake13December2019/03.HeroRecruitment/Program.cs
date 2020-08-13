using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.HeroRecruitment
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = String.Empty;

            Dictionary<string, List<string>> spellBook = new Dictionary<string, List<string>>();

            while ((input = Console.ReadLine()) != "End")
            {
                string[] actionArgs = input.Split();
                string action = actionArgs[0];
                string heroName = actionArgs[1];

                switch (action)
                {
                    case "Enroll":
                        Enroll(spellBook, actionArgs);
                        break;
                    case "Learn":
                        LearnSpell(spellBook, actionArgs);
                        break;
                    case "Unlearn":
                        UnlearnSpell(spellBook, actionArgs);
                        break;
                }
            }
            Console.WriteLine("Heroes:");
            foreach (var heroes in spellBook.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                Console.WriteLine($"== {heroes.Key}: {String.Join(", ", heroes.Value)}");
            }
        }

        public static void Enroll(Dictionary<string, List<string>> spellBook, string[] actionArgs)
        {
            if (spellBook.ContainsKey(actionArgs[1]))
            {
                Console.WriteLine($"{actionArgs[1]} is already enrolled.");
            }
            else
            {
                spellBook.Add(actionArgs[1], new List<string>());
            }
        }
        public static void LearnSpell(Dictionary<string, List<string>> spellBook, string[] actionArgs)
        {
            if (!spellBook.ContainsKey(actionArgs[1]))
            {
                Console.WriteLine($"{actionArgs[1]} doesn't exist.");
            }
            else
            {
                if (spellBook[actionArgs[1]].Contains(actionArgs[2]))
                {
                    Console.WriteLine($"{actionArgs[1]} has already learnt {actionArgs[2]}.");
                }
                else
                {
                    spellBook[actionArgs[1]].Add(actionArgs[2]);
                }
            }
        }
        public static void UnlearnSpell(Dictionary<string, List<string>> spellBook, string[] actionArgs)
        {
            if (!spellBook.ContainsKey(actionArgs[1]))
            {
                Console.WriteLine($"{actionArgs[1]} doesn't exist.");
            }
            else
            {
                if (!spellBook[actionArgs[1]].Contains(actionArgs[2]))
                {
                    Console.WriteLine($"{actionArgs[1]} doesn't know {actionArgs[2]}.");
                }
                else
                {
                    spellBook[actionArgs[1]].Remove(actionArgs[2]);
                }
            }
        }
    }

}
