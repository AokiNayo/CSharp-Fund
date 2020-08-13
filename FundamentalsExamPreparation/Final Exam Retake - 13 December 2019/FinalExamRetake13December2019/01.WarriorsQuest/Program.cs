using System;

namespace _01.WarriorsQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            string skill = Console.ReadLine();
            string action = String.Empty;

            while ((action = Console.ReadLine()) != "For Azeroth")
            {
                string[] actionArgs = action.Split();
                switch (actionArgs[0])
                {
                    case "GladiatorStance":
                    case "DefensiveStance":
                        skill = Stance(skill, action);
                        break;
                    case "Dispel":
                        skill = Dispel(skill, actionArgs);
                        break;
                    case "Target":
                        skill = TargetCommand(skill, actionArgs);
                        break;
                    default:
                        Console.WriteLine("Command doesn't exist!");
                        break;
                }
            }
        }
        public static string Stance(string skill, string action)
        {
            if (action.Contains("DefensiveStance"))
            {
                skill = skill.ToLower();
            }
            else if (action.Contains("GladiatorStance"))
            {
                skill = skill.ToUpper();
            }
            Console.WriteLine(skill);
            return skill;
        }
        public static string Dispel(string skill, string[] actionArgs)
        {
            int index = int.Parse(actionArgs[1]);
            char letter = char.Parse(actionArgs[2]);

            if (index >= 0 && index < skill.Length)
            {
                char[] temp = skill.ToCharArray();
                temp[index] = letter;
                skill = new string(temp);

                Console.WriteLine("Success!");
            }
            else
            {
                Console.WriteLine("Dispel too weak.");
            }
            return skill;
        }
        public static string TargetCommand(string skill, string[] actionArgs)
        {
            string substring = actionArgs[2];

            if (actionArgs[1].Contains("Change"))
            {
                if (skill.Contains(substring))
                {
                    string changeSubstring = actionArgs[3];
                    skill = skill.Replace(substring, changeSubstring);
                    Console.WriteLine(skill);
                }
            }
            else if (actionArgs[1].Contains("Remove"))
            {
                if (skill.Contains(substring))
                {
                    int start = skill.IndexOf(substring);
                    skill = skill.Remove(start, substring.Length);
                    Console.WriteLine(skill);
                }
            }
            else
            {
                Console.WriteLine("Command doesn't exist!");
            }
            return skill;
        }
    }
}
