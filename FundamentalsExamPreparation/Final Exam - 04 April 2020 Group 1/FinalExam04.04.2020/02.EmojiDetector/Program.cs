using System;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Regex emojiRegex = new Regex(@"(::|\*\*)(?<emoji>[A-Z][a-z]{2,})\1");
            Regex digitRegex = new Regex(@"\d");

            BigInteger coolThresholdSum = 1;

            var numbers = digitRegex.Matches(text);
            var emojies = emojiRegex.Matches(text);

            foreach (Match num in numbers)
            {
                coolThresholdSum *= int.Parse(num.Value);
            }

            Console.WriteLine($"Cool threshold: {coolThresholdSum}");
            Console.WriteLine($"{emojies.Count} emojis found in the text. The cool ones are:");

            foreach (Match emoji in emojies)
            {
                BigInteger coolness = 0;

                foreach (char item in emoji.Groups["emoji"].Value)
                {
                    coolness += (int)item;
                }

                if (coolness >= coolThresholdSum)
                {
                    Console.WriteLine(emoji);
                }
            }
        }
    }
}
