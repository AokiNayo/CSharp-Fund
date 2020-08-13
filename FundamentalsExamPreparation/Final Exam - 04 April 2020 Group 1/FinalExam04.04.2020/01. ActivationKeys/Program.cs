using System;
using System.Linq;

namespace _01._ActivationKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            string activationKey = Console.ReadLine();
            string action = String.Empty;

            while ((action = Console.ReadLine()) != "Generate")
            {
                string[] actionArgs = action.Split(">>>");
                string actionName = actionArgs[0];

                switch (actionName)
                {
                    case "Contains":
                        Contains(actionArgs, activationKey);
                        break;
                    case "Flip":
                        activationKey = Flip(actionArgs, activationKey);
                        break;
                    case "Slice":
                        activationKey = Slice(actionArgs, activationKey);
                        break;
                }
            }
            Console.WriteLine($"Your activation key is: {activationKey}");
        }

        public static void Contains(string[] actionArgs, string activationKey)
        {
            string substring = actionArgs[1];
            if (activationKey.Contains(substring))
            {
                Console.WriteLine($"{activationKey} contains {substring}");
            }
            else
            {
                Console.WriteLine("Substring not found!");
            }
        }

        public static string Flip(string[] actionArgs, string activationKey)
        {
            int start = int.Parse(actionArgs[2]);
            int end = int.Parse(actionArgs[3]);
            string substring = activationKey.Substring(start, end - start);

            if (actionArgs[1].Contains("Upper"))
            {
                //substring = substring.ToUpper();
                //activationKey = activationKey.Remove(start, end);
                //activationKey = activationKey.Insert(start, substring);
                activationKey = activationKey.Replace(substring, substring.ToUpper());
            }
            else
            {
                //substring = substring.ToLower();
                //activationKey = activationKey.Remove(start, end);
                //activationKey = activationKey.Insert(start, substring);
                activationKey = activationKey.Replace(substring, substring.ToLower());

            }
            Console.WriteLine(activationKey);
            return activationKey;
        }
        public static string Slice(string[] actionArgs, string activationKey)
        {
            int start = int.Parse(actionArgs[1]);
            int end = int.Parse(actionArgs[2]);

            activationKey = activationKey.Remove(start, end - start);
            Console.WriteLine(activationKey);
            return activationKey;
        }
    }
}
