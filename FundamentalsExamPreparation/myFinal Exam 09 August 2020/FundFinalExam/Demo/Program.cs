using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Plants> plants = new Dictionary<string, Plants>();

            for (int i = 0; i < n; i++)
            {
                string[] plantsArgs = Console.ReadLine().Split("<->");
                string plantName = plantsArgs[0];
                int rarity = int.Parse(plantsArgs[1]);

                if (plants.ContainsKey(plantName))
                {
                    plants[plantName].Rarity = rarity;
                }
                else
                {
                    plants.Add(plantName, new Plants() { Name = plantName, Rarity = rarity, Rating = new List<double>() });
                }
            }
            string action = String.Empty;
            while ((action = Console.ReadLine()) != "Exhibition")
            {
                string[] actionArgs = action.Split();
                string plantName = actionArgs[1];

                if (action.Contains("Rate"))
                {
                    if (plants.ContainsKey(plantName))
                    {
                        double rating = double.Parse(actionArgs[3]);
                        plants[plantName].Rating.Add(rating);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (action.Contains("Update"))
                {
                    if (plants.ContainsKey(plantName))
                    {
                        int newRarity = int.Parse(actionArgs[3]);
                        plants[plantName].Rarity = newRarity;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (action.Contains("Reset"))
                {
                    if (plants.ContainsKey(plantName))
                    {
                        plants[plantName].Rating.Clear();
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else
                {
                    Console.WriteLine("error");
                }
            }

            foreach (var item in plants.Values)
            {
                if (item.Rating.Count == 0)
                {
                    item.Rating.Add(0.00);
                }
            }

            Console.WriteLine("Plants for the exhibition:");

            foreach (var plant in plants.OrderByDescending(x => x.Value.Rarity).ThenByDescending(x => x.Value.Rating.Average()).ToDictionary(x => x.Key, x => x.Value))
            {
                var average = plant.Value.Rating.Average();
                Console.WriteLine($"- {plant.Key}; Rarity: {plant.Value.Rarity}; Rating: {average:f2}");
            }
        }
    }
    class Plants
    {
        public string Name { get; set; }
        public int Rarity { get; set; }
        public List<double> Rating { get; set; }

    }
}
