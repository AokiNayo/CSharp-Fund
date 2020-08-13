using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.HeroesOfCodeAndLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, int> nameHp = new Dictionary<string, int>();
            Dictionary<string, int> nameMp = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                string[] heroArgs = Console.ReadLine().Split();
                nameHp.Add(heroArgs[0], int.Parse(heroArgs[1]));
                nameMp.Add(heroArgs[0], int.Parse(heroArgs[2]));

            }
            string input = String.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] heroActions = input.Split(" - ");
                string action = heroActions[0];

                switch (action)
                {
                    case "CastSpell":
                        CastSpell(heroActions, nameMp);
                        break;
                    case "TakeDamage":
                        TakeDamage(heroActions, nameHp, nameMp);
                        break;
                    case "Recharge":
                        Recharge(heroActions, nameMp);
                        break;
                    case "Heal":
                        Heal(heroActions, nameHp);
                        break;
                }
            }
            foreach (var item in nameHp.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                int mana = nameMp[item.Key];
                Console.WriteLine(item.Key);
                Console.WriteLine($" HP: {item.Value}");
                Console.WriteLine($" MP: {mana}");

            }
        }

        public static void CastSpell(string[] heroArgs, Dictionary<string, int> nameMp)
        {
            string name = heroArgs[1];
            int mpCost = int.Parse(heroArgs[2]);
            string spellName = heroArgs[3];

            if (nameMp[name] >= mpCost)
            {
                nameMp[name] -= mpCost;
                Console.WriteLine($"{name} has successfully cast {spellName} and now has {nameMp[name]} MP!");
            }
            else
            {
                Console.WriteLine($"{name} does not have enough MP to cast {spellName}!");
            }
        }
        public static void TakeDamage(string[] heroArgs, Dictionary<string, int> nameHp, Dictionary<string, int> nameMp)
        {
            string name = heroArgs[1];
            int damage = int.Parse(heroArgs[2]);
            string attacker = heroArgs[3];

            nameHp[name] -= damage;
            if (nameHp[name] > 0)
            {
                Console.WriteLine($"{name} was hit for {damage} HP by {attacker} and now has {nameHp[name]} HP left!");
            }
            else
            {
                nameHp.Remove(name);
                nameMp.Remove(name);
                Console.WriteLine($"{name} has been killed by {attacker}!");

            }
        }
        public static void Recharge(string[] heroArgs, Dictionary<string, int> nameMp)
        {
            string name = heroArgs[1];
            int amount = int.Parse(heroArgs[2]);

            if (nameMp[name] + amount > 200)
            {
                int amountLacking = 200 - nameMp[name];
                nameMp[name] += amountLacking;
                Console.WriteLine($"{name} recharged for {amountLacking} MP!");
            }
            else
            {
                nameMp[name] += amount;
                Console.WriteLine($"{name} recharged for {amount} MP!");

            }
        }
        public static void Heal(string[] heroArgs, Dictionary<string, int> nameHp)
        {
            string name = heroArgs[1];
            int amount = int.Parse(heroArgs[2]);

            if (nameHp[name] + amount > 100)
            {
                int amountLacking = 100 - nameHp[name];
                nameHp[name] += amountLacking;
                Console.WriteLine($"{name} healed for {amountLacking} HP!");
            }
            else
            {
                nameHp[name] += amount;
                Console.WriteLine($"{name} healed for {amount} HP!");

            }
        }
    }
}
