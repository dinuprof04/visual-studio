using System;

namespace ConsoleAppClassMethod
{
    // Define a class named MathOperations to hold our method
    public class MathOperations
    {
        // Void method that takes two integers: firstNum and secondNum
        // Performs math operation (multiplication by 2) on firstNum
        // Displays the secondNum to the console
        public void PerformMathAndDisplay(int firstNum, int secondNum)
        {
            // Perform math operation: multiply firstNum by 2
            int result = firstNum * 2;

            // Display the secondNum to the screen (as per requirement)
            Console.WriteLine($"The second number is: {secondNum}");

            // Optional: Also display the math result for clarity (not required but helpful)
            Console.WriteLine($"Math result on first number ({firstNum} * 2): {result}");
        }
    }

    // Main program class
    class Program
    {
        // Entry point of the console application
        static void Main(string[] args)
        {
            // Instantiate the MathOperations class, creating a new object
            MathOperations mathOps = new MathOperations();

            // Call the method with positional parameters (order matters)
            mathOps.PerformMathAndDisplay(10, 25);

            Console.WriteLine(); // Add blank line for readability

            // Call the method specifying parameters by name (order doesn't matter)
            mathOps.PerformMathAndDisplay(firstNum: 15, secondNum: 42);

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(); // Pause to see output
        }
    }
}
