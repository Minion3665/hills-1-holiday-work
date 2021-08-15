using System;
using System.Globalization;

namespace task_1
{
    // ReSharper disable once ClassNeverInstantiated.Global
    internal class Program
    {
        private static void Main()
        {
            string firstname;
            while (true)
            {
                Console.Write("Enter your first name: ");
                firstname = Console.ReadLine();
                if (firstname == null)
                {
                    Console.WriteLine("No first name provided");
                    continue;
                }

                if (firstname == "quit")
                {
                    Console.WriteLine("Goodbye");
                    Environment.Exit(0);
                }
                break;
            }
            string lastname;
            while (true)
            {
                Console.Write("Enter your last name: ");
                lastname = Console.ReadLine();
                if (lastname == null)
                {
                    Console.WriteLine("No last name provided");
                    continue;
                }
                if (lastname == "quit")
                {
                    Console.WriteLine("Goodbye");
                    Environment.Exit(0);
                }
                if (lastname.Length >= 3) break;
                Console.WriteLine("Your last name is too short. It needs to be at least (3) characters long");
            }

            DateTime date;
            while (true)
            {
                Console.Write("Enter a date in the format DD/MM/YYYY: ");
                var input = Console.ReadLine();
                if (input == null)
                {
                    Console.WriteLine("No date provided");
                    continue;
                }
                if (input == "quit")
                {
                    Console.WriteLine("Goodbye");
                    Environment.Exit(0);
                }

                try
                {
                     date = DateTime.ParseExact(input, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid date provided");
                    continue;
                }
                break;
            }

            var lastnameChars = lastname[..3].ToUpper();
            var firstnameChars = firstname[..1].ToUpper();
            var firstnameLength = firstname.Length;
            
            Console.WriteLine($"ID: {date.Year}{date.Month}{date.Day}{lastnameChars}{firstnameChars}{firstnameLength}");
        }
    }
}