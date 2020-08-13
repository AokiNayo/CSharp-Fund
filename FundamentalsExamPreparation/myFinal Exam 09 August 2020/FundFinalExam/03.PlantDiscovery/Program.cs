using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PlantDiscovery
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, int> rarity = new Dictionary<string, int>();
            Dictionary<string, List<double>> rating = new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                string[] currentPlant = Console.ReadLine().Split("<->");
                if (rarity.ContainsKey(currentPlant[0]))
                {
                    rarity[currentPlant[0]] = int.Parse(currentPlant[1]);
                }
                else
                {
                    rarity.Add(currentPlant[0], int.Parse(currentPlant[1]));
                }
            }
            string action = String.Empty;
            while ((action = Console.ReadLine()) != "Exhibition") // Rate: Woodii - 10
            {
                string[] actionArgs = action.Split(); // 4

                if (action.Contains("Rate"))
                {
                    if (rating.ContainsKey(actionArgs[1]))
                    {
                        rating[actionArgs[1]].Add(double.Parse(actionArgs[3]));
                    }
                    else
                    {
                        rating.Add(actionArgs[1], new List<double>());
                        rating[actionArgs[1]].Add(double.Parse(actionArgs[3]));
                    }
                }
                else if (action.Contains("Update"))
                {
                    if (rarity.ContainsKey(actionArgs[1]))
                    {
                        rarity[actionArgs[1]] = int.Parse(actionArgs[3]);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (action.Contains("Reset"))
                {
                    if (rating.ContainsKey(actionArgs[1]))
                    {
                        rating.Remove(actionArgs[1]);
                        rating.Add(actionArgs[1], new List<double>());
                        rating[actionArgs[1]].Add(0.0);
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

            Dictionary<string, List<double>> ratePlants = new Dictionary<string, List<double>>();
            foreach (var plant in rating)
            {
                if (plant.Value.Count > 0)
                {
                    ratePlants.Add(plant.Key, new List<double>());
                    double avrgRate = plant.Value.Average();
                    ratePlants[plant.Key].Add(avrgRate);

                }
                else
                {
                    ratePlants.Add(plant.Key, new List<double>());
                    ratePlants[plant.Key].Add(0.00);

                }
            }
            foreach (var kvp in rarity)
            {
                double test = (double)kvp.Value;
                ratePlants[kvp.Key].Add(test);
            }
            ratePlants = ratePlants.OrderByDescending(x => x.Value[1]).ThenByDescending(x => x.Value[0]).ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine("Plants for the exhibition:");

            foreach (var item in ratePlants)
            {
                Console.WriteLine($"- {item.Key}; Rarity: {item.Value[1]}; Rating: {item.Value[0]:f2}");
            }
        }
    }
}
