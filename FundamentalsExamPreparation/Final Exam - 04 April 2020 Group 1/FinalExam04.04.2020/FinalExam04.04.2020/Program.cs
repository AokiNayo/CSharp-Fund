using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalExam04._04._2020
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = String.Empty;
            Dictionary<string, Cities> cities = new Dictionary<string, Cities>();

            while ((input = Console.ReadLine()) != "Sail")
            {
                string[] citiesArgs = input.Split("||");

                string cityName = citiesArgs[0];
                int population = int.Parse(citiesArgs[1]);
                int gold = int.Parse(citiesArgs[2]);

                if (cities.ContainsKey(cityName))
                {
                    cities[cityName].Population += population;
                    cities[cityName].Gold += gold;
                    continue;
                }
                cities.Add(cityName, new Cities() { Population = population, Gold = gold });
            }

            string action = String.Empty;
            while ((action = Console.ReadLine()) != "End")
            {
                string[] actionArgs = action.Split("=>");
                string actionName = actionArgs[0];

                switch (actionName)
                {
                    case "Plunder":
                        Cities.Plunder(actionArgs, cities);
                        break;
                    case "Prosper":
                        Cities.Prosper(actionArgs, cities);
                        break;
                }
            }
            Cities.PrintSettlements(cities);
        }
    }

    class Cities
    {
        public int Population { get; set; }
        public int Gold { get; set; }

        public static void Plunder(string[] actionArgs, Dictionary<string, Cities> citiesArgs)
        {
            string cityName = actionArgs[1];
            int citizensKilled = int.Parse(actionArgs[2]);
            int gold = int.Parse(actionArgs[3]);

            citiesArgs[cityName].Population -= citizensKilled;
            citiesArgs[cityName].Gold -= gold;

            Console.WriteLine($"{cityName} plundered! {gold} gold stolen, {citizensKilled} citizens killed.");
            if (citiesArgs[cityName].Population <= 0 || citiesArgs[cityName].Gold <= 0)
            {
                citiesArgs.Remove(cityName);
                Console.WriteLine($"{cityName} has been wiped off the map!");
            }

        }
        public static void Prosper(string[] actionArgs, Dictionary<string, Cities> citiesArgs)
        {
            string cityName = actionArgs[1];
            int gold = int.Parse(actionArgs[2]);

            if (gold > 0)
            {
                citiesArgs[cityName].Gold += gold;
                Console.WriteLine($"{gold} gold added to the city treasury. {cityName} now has {citiesArgs[cityName].Gold} gold.");
            }
            else
            {
                Console.WriteLine("Gold added cannot be a negative number!");
            }
        }
        public static void PrintSettlements(Dictionary<string, Cities> citiesArgs)
        {
            if (citiesArgs.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {citiesArgs.Count} wealthy settlements to go to:");
                foreach (var city in citiesArgs.OrderByDescending(x => x.Value.Gold).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value))
                {
                    Console.WriteLine($"{city.Key} -> Population: {city.Value.Population} citizens, Gold: {city.Value.Gold} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }

    }
}
