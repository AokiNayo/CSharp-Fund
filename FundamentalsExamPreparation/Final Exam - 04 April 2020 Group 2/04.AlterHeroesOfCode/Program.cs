using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.AlterHeroesOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, HeroArgs> heroes = new Dictionary<string, HeroArgs>();
            for (int i = 0; i < n; i++)
            {
                string[] heroArgs = Console.ReadLine().Split();
                HeroArgs currentHero = new HeroArgs() { HP = int.Parse(heroArgs[1]), MP = int.Parse(heroArgs[2]) };
                heroes.Add(heroArgs[0], currentHero);
            }
            string input = String.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] heroArgs = input.Split(" - ");
                string action = heroArgs[0];

                switch (action)
                {
                    case "CastSpell":
                        HeroArgs.CastSpell(heroArgs, heroes);
                        break;
                    case "TakeDamage":
                        HeroArgs.TakeDamage(heroArgs, heroes);
                        break;
                    case "Recharge":
                        HeroArgs.Recharge(heroArgs, heroes);
                        break;
                    case "Heal":
                        HeroArgs.Heal(heroArgs, heroes);
                        break;
                }
            }
            foreach (var item in heroes.OrderByDescending(x => x.Value.HP).ThenBy(x => x.Key))
            {
                Console.WriteLine(item.Key);
                Console.WriteLine($" HP: {item.Value.HP}");
                Console.WriteLine($" MP: {item.Value.MP}");
            }
        }
    }

    public class HeroArgs
    {
        public int HP { get; set; }
        public int MP { get; set; }

        public static void CastSpell(string[] heroArgs, Dictionary<string, HeroArgs> heroes)
        {
            string name = heroArgs[1];
            int mpCost = int.Parse(heroArgs[2]);
            string spellName = heroArgs[3];

            if (heroes[name].MP - mpCost >= 0)
            {
                heroes[name].MP -= mpCost;
                Console.WriteLine($"{name} has successfully cast {spellName} and now has {heroes[name].MP} MP!");
            }
            else
            {
                Console.WriteLine($"{name} does not have enough MP to cast {spellName}!");
            }
        }
        public static void TakeDamage(string[] heroArgs, Dictionary<string, HeroArgs> heroes)
        {
            string name = heroArgs[1];
            int damage = int.Parse(heroArgs[2]);
            string attacker = heroArgs[3];

            heroes[name].HP -= damage;
            if (heroes[name].HP > 0)
            {
                Console.WriteLine($"{name} was hit for {damage} HP by {attacker} and now has {heroes[name].HP} HP left!");
            }
            else
            {
                heroes.Remove(name);
                Console.WriteLine($"{name} has been killed by {attacker}!");
            }
        }
        public static void Recharge(string[] heroArgs, Dictionary<string, HeroArgs> heroes)
        {
            string name = heroArgs[1];
            int amount = int.Parse(heroArgs[2]);

            if (heroes[name].MP + amount > 200)
            {
                int amountLacking = 200 - heroes[name].MP;
                heroes[name].MP += amountLacking;
                Console.WriteLine($"{name} recharged for {amountLacking} MP!");
            }
            else
            {
                heroes[name].MP += amount;
                Console.WriteLine($"{name} recharged for {amount} MP!");

            }
        }
        public static void Heal(string[] heroArgs, Dictionary<string, HeroArgs> heroes)
        {
            string name = heroArgs[1];
            int amount = int.Parse(heroArgs[2]);

            if (heroes[name].HP + amount > 100)
            {
                int amountLacking = 100 - heroes[name].HP;
                heroes[name].HP += amountLacking;
                Console.WriteLine($"{name} healed for {amountLacking} HP!");
            }
            else
            {
                heroes[name].HP += amount;
                Console.WriteLine($"{name} healed for {amount} HP!");

            }
        }

    }
}
