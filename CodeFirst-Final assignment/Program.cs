using System;

class Program
{
    static void Main()
    {
        using (var context = new SchoolContext())
        {
            var student = new Student
            {
                Name = "John Doe"
            };

            context.Students.Add(student);
            context.SaveChanges();
        }

        Console.WriteLine("Student added successfully.");
        Console.ReadLine();
    }
}
