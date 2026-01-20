// Using namespace System to access Console, object types, and other core functionality
using System;

// Define the IQuittable interface - this declares a contract that any implementing class must provide a Quit() method
public interface IQuittable
{
    // Quit() method signature: void means no return value; no parameters
    void Quit();
}

// Employee class inherits (implements) the IQuittable interface using the ':' syntax
public class Employee : IQuittable
{
    // Property for FirstName - auto-implemented property with private backing field
    public string FirstName { get; set; } = string.Empty;

    // Property for LastName - auto-implemented property with private backing field
    public string LastName { get; set; } = string.Empty;

    // Property for Id - auto-implemented property to store unique employee ID
    public int Id { get; set; }

    // Constructor to initialize Employee with name and ID values
    public Employee(string firstName, string lastName, int id)
    {
        // Assign parameter values to properties
        FirstName = firstName;
        LastName = lastName;
        Id = id;
    }

    // Implementation of the Quit() method required by IQuittable interface
    // This provides the concrete behavior for quitting (e.g., logging out an employee)
    public void Quit()
    {
        // Use Console.WriteLine to output a message simulating the quit action
        Console.WriteLine($"{FirstName} {LastName} has quit the program.");
    }
}

// Program class - entry point for the console application
class Program
{
    // Main method - entry point where execution begins; static means class-level, void means no return
    static void Main(string[] args)
    {
        // Create an Employee object using constructor
        Employee employee = new Employee("John", "Doe", 12345);

        // Demonstrate polymorphism: Declare variable as interface type IQuittable
        // But assign it an Employee object (possible because Employee implements IQuittable)
        IQuittable quittable = employee;

        // Call Quit() method through the interface reference - resolved polymorphically to Employee's implementation
        quittable.Quit();
    }
}
