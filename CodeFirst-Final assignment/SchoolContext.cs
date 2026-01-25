using System.Data.Entity;

public class SchoolContext : DbContext
{
    public SchoolContext() : base("StudentDb")
    {
    }

    public DbSet<Student> Students { get; set; }
}
