using System;
using System.Linq;

namespace FinalExamRetake13December2019
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "Pesho";
            var reversed = text.Reverse();
            string text2 = String.Join("", reversed);
            Console.WriteLine(String.Join("",reversed));
            Console.WriteLine(reversed);
            Console.WriteLine(text2);
        }
    }
}
