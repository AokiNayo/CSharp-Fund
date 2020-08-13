using System;
using System.Text;

namespace FinalExamAugust
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder text = new StringBuilder(Console.ReadLine());

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "Travel")
            {
                string[] actionArgs = input.Split(":", StringSplitOptions.RemoveEmptyEntries);
                string actionName = actionArgs[0];

                if (actionName == "Add Stop")
                {
                    int index = int.Parse(actionArgs[1]);
                    string toAdd = actionArgs[2];

                    if (index < text.Length && index >= 0)
                    {
                        text.Insert(index, toAdd);
                        Console.WriteLine(text);
                    }
                    else
                    {
                        Console.WriteLine(text);
                    }
                }
                else if (actionName == "Remove Stop")
                {
                    int start = int.Parse(actionArgs[1]);
                    int end = int.Parse(actionArgs[2]);
                    int length = end - start;

                    if (start >= 0 && start < text.Length && end < text.Length && end >= 0)
                    {
                        text.Remove(start, length + 1);
                        Console.WriteLine(text);
                    }
                        Console.WriteLine(text);
                }
                else if (actionName == "Switch")
                {
                    string old = actionArgs[1];
                    string newStr = actionArgs[2];

                    if (text.ToString().Contains(old))
                    {
                        text.Replace(old, newStr);

                        Console.WriteLine(text);
                    }
                        Console.WriteLine(text);
                }
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {text}");
        }
    }
}
