using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;
using System.Linq;

namespace task_2
{
    // ReSharper disable once ClassNeverInstantiated.Global
    internal class Program
    {
        private static void Main()
        {
            List<Tuple<string, int>> items = new();

            while (true)
            {
                string name;
                while (true)
                {
                    Console.Write("Enter the item name: ");
                    name = Console.ReadLine();
                    if (name == null)
                    {
                        Console.WriteLine("No name provided");
                        continue;
                    }
                    break;
                }

                if (name == "none")
                {
                    break;
                }

                int price;
                while (true)
                {
                    Console.Write("Enter the item price: ");
                    var input = Console.ReadLine();
                    if (input == null)
                    {
                        Console.WriteLine("No price provided");
                        continue;
                    }

                    try
                    {
                        price = int.Parse(input);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid price provided");
                        continue;
                    }
                    break;
                }

                items.Add(new Tuple<string, int>(name, price));
            }
            
            items.Sort((item1, item2) => item2.Item2 - item1.Item2);
            Console.WriteLine($"Most expensive item: {items[0].Item1} for £{items[0].Item2}");
            items.Sort((item1, item2) => item1.Item2 - item2.Item2);
            Console.WriteLine($"Cheapest item: {items[0].Item1} for £{items[0].Item2}");

            var sumOfPrices = (double)items.Select(item => item.Item2).Sum();
            Console.WriteLine($"Average price: £{sumOfPrices / items.Count}");

            var totalCost = items.Select(item =>
            {
                double cost = item.Item2;
                if (cost > 50) cost *= 0.95;
                cost *= 1.2;
                return cost;
            }).Sum();
            Console.WriteLine($"Total item cost (after discounts and VAT): £{totalCost}");
        }
    }
}