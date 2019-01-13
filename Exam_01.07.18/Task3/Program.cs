using System;
using System.Text.RegularExpressions;
namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^([^|$%\.]*?%(?<name>[A-Z][a-z]+)%[^|$%.]*?<(?<product>\w+)>[^.|$%]*?\|(?<count>\d+)\|[^.|$%]*?(?<price>\d+(\.\d+)?)\$)$";
            string input;
            double income = 0.0;
            while ((input = Console.ReadLine()) != "end of shift")
            {
                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    string name = match.Groups["name"].Value;
                    string product = match.Groups["product"].Value;
                    int count = int.Parse(match.Groups["count"].Value);
                    double price = double.Parse(match.Groups["price"].Value);
                    double totalPrice = count * price;
                    Console.WriteLine($"{name}: {product} - {totalPrice:f2}");
                    income += totalPrice;

                }

            }
            Console.WriteLine($"Total income: {income:f2}");
        }
    }
}
