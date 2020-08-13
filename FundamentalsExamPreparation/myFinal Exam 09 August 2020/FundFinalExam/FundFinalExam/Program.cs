using System;

namespace FundFinalExam
{
    class Program
    {
        static void Main(string[] args)
        {
            string allStops = Console.ReadLine();
            string input = String.Empty;

            while ((input = Console.ReadLine()) != "Travel")
            {
                string[] actionArgs = input.Split(':');
                string actionName = actionArgs[0];

                if (actionName.Contains("Add Stop"))
                {
                    int index = int.Parse(actionArgs[1]);
                    string stop = actionArgs[2];

                    if (index < allStops.Length && index >= 0)
                    {
                        allStops = allStops.Insert(index, stop);
                    }
                    Console.WriteLine(allStops);

                }
                else if (actionName.Contains("Remove Stop"))
                {
                    int start = int.Parse(actionArgs[1]);
                    int end = int.Parse(actionArgs[2]);
                    if (start >= 0 && start < allStops.Length && end < allStops.Length && end >= 0)
                    {
                        allStops = allStops.Remove(start, end - start + 1);

                    }
                    Console.WriteLine(allStops);

                }
                else if (actionName.Contains("Switch"))
                {
                    string oldString = actionArgs[1];
                    string newString = actionArgs[2];

                    if (allStops.Contains(oldString))
                    {
                        allStops = allStops.Replace(oldString, newString);
                    }
                    Console.WriteLine(allStops);

                }
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {allStops}");
        }
    }
}
