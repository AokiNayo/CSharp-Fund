using System;
using System.Text.RegularExpressions;

namespace _02.FancyBarcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Regex regex = new Regex(@"@#+(?<barcode>[A-Z][A-Za-z0-9]{4,}[A-Z])@#+");
            Regex digitPattern = new Regex(@"[0-9]");

            for (int i = 0; i < n; i++)
            {
                string barcode = Console.ReadLine();

                if (regex.IsMatch(barcode))
                {
                    string currentBarcode = regex.Match(barcode).Groups["barcode"].Value;

                    if (digitPattern.IsMatch(currentBarcode))
                    {
                        var digits = digitPattern.Matches(currentBarcode);
                        string productGroup = String.Empty;

                        for (int j = 0; j < digits.Count; j++)
                        {
                            productGroup += digits[j];
                        }
                        Console.WriteLine($"Product group: {productGroup}");
                    }
                    else
                    {
                        Console.WriteLine("Product group: 00");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
