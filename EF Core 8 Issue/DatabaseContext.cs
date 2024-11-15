using EF_Core_8_Issue.DbSetEntities;
using Microsoft.EntityFrameworkCore;

namespace EF_Core_8_Issue;

public class DatabaseContext : DbContext
{
    public IList<string> ExecutedCommands { get; set; } = [];

    public DbSet<Employee> Employees { get; set; }

    public DbSet<HomePage> HomePages { get; set; }

    public DbSet<Title> Titles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Hard coded just for test, normally built from scoped details (Tenanted database)
        optionsBuilder.UseSqlServer("Server=.;Initial Catalog=EF8_Issue_Testing;Integrated Security=True;Encrypt=False;");
        optionsBuilder.EnableDetailedErrors();
        optionsBuilder.EnableSensitiveDataLogging(true);
        optionsBuilder.LogTo(Console.WriteLine);
        optionsBuilder.AddInterceptors(new QueryLogger());
    }
}