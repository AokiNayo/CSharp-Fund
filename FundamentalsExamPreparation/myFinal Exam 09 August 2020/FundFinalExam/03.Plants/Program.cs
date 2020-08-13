using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Plants
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

            Dictionary<string, List<double>> averageDict = new Dictionary<string, List<double>>();

            foreach (var item in plants)
            {
                double average = 0.0;

                foreach (var test in item.Value.Rating)
                {
                    average += test;
                }
                
                if (average > 0)
                {
                    average = average / item.Value.Rating.Count;
                }

                averageDict.Add(item.Key, new List<double> { item.Value.Rarity, average });
            }

            var sorted = averageDict.OrderByDescending(x => x.Value[0]).ThenByDescending(x => x.Value[1]);
            Console.WriteLine("Plants for the exhibition:");

            foreach (var plant in sorted)
            {
                Console.WriteLine($"- {plant.Key}; Rarity: {plant.Value[0]}; Rating: {plant.Value[1]:f2}");
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
