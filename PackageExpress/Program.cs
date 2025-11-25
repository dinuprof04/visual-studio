using System;

namespace PackageExpress
{
    class Program
    {
        static void Main(string[] args)
        {
            // Display the initial greeting and instructions.
            Console.WriteLine("Welcome to Package Express. Please follow the instructions below.");

            // Prompt user for package weight and parse input.
            Console.WriteLine("Please enter the package weight:");
            double weight = Convert.ToDouble(Console.ReadLine());

            // If weight exceeds 50, display an error and terminate the program.
            if (weight > 50)
            {
                Console.WriteLine("Package too heavy to be shipped via Package Express. Have a good day.");
                return; // End program execution.
            }

            // Prompt user for package width and parse input.
            Console.WriteLine("Please enter the package width:");
            double width = Convert.ToDouble(Console.ReadLine());

            // Prompt user for package height and parse input.
            Console.WriteLine("Please enter the package height:");
            double height = Convert.ToDouble(Console.ReadLine());

            // Prompt user for package length and parse input.
            Console.WriteLine("Please enter the package length:");
            double length = Convert.ToDouble(Console.ReadLine());

            // Check if the sum of dimensions exceeds 50.
            double dimensionTotal = width + height + length;
            if (dimensionTotal > 50)
            {
                Console.WriteLine("Package too big to be shipped via Package Express.");
                return; // End program execution.
            }

            // Calculate shipping quote: (width * height * length * weight) / 100.
            double quote = (width * height * length * weight) / 100.0;

            // Display the quote formatted as USD with two decimal places.
            Console.WriteLine("Your estimated total for shipping this package is: $" + quote.ToString("0.00"));
            Console.WriteLine("Thank you!");
        }
    }
}
