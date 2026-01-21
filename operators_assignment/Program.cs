// Using namespace System to access Console and basic object types
using System;

// Employee class definition
public class Employee
{
    // Auto-implemented property for Id - integer unique identifier for employee
    public int Id { get; set; }

    // Auto-implemented property for FirstName - employee's first name as string
    public string FirstName { get; set; } = string.Empty;

    // Auto-implemented property for LastName - employee's last name as string
    public string LastName { get; set; } = string.Empty;

    // Constructor to initialize Employee with Id, FirstName, and LastName
    public Employee(int id, string firstName, string lastName)
    {
        // Assign parameters to properties
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }

    // Overload the equality operator (==) - compares two Employee objects by their Id property only
    // First parameter is 'this' (left side), second is right side Employee
    // Returns true if Id values match, false otherwise
    public static bool operator ==(Employee emp1, Employee emp2)
    {
        // Handle null cases: if either is null, they are not equal
        if (emp1 is null || emp2 is null)
            return false;

        // Compare Id properties - equality based solely on Id
        return emp1.Id == emp2.Id;
    }

    // Overload the inequality operator (!=) - must be paired with == overload
    // Returns true if Id values do not match (opposite of ==)
    public static bool operator !=(Employee emp1, Employee emp2)
    {
        // Delegate to == operator for consistency (negate its result)
        return !(emp1 == emp2);
    }

    // Override Equals method for consistency with operator overloads (optional but recommended)
    public override bool Equals(object obj)
    {
        // Check if obj is Employee and Id matches
        return obj is Employee other && Id == other.Id;
    }

    // Override GetHashCode for consistency with Equals (required when overriding Equals)
    public override int GetHashCode()
    {
        // Use Id for hash code since it's the equality key
        return Id.GetHashCode();
    }
}

// Program class - main entry point for console application
class Program
{
    // Main method - where program execution starts
    static void Main(string[] args)
    {
        // Instantiate first Employee object with Id 12345, name "John Doe"
        Employee emp1 = new Employee(12345, "John", "Doe");

        // Instantiate second Employee object with same Id 12345, different name "Jane Doe"
        Employee emp2 = new Employee(12345, "Jane", "Doe");

        // Instantiate third Employee with different Id for contrast
        Employee emp3 = new Employee(67890, "Bob", "Smith");

        // Compare emp1 and emp2 using overloaded == (should be true due to same Id)
        bool areEqual1 = emp1 == emp2;
        Console.WriteLine($"emp1 (Id: {emp1.Id}) == emp2 (Id: {emp2.Id}): {areEqual1}");

        // Compare emp1 and emp3 using overloaded != (should be true due to different Id)
        bool areNotEqual = emp1 != emp3;
        Console.WriteLine($"emp1 (Id: {emp1.Id}) != emp3 (Id: {emp3.Id}): {areNotEqual}");
    }
}
