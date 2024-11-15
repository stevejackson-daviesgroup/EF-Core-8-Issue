using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;

namespace EF_Core_8_Issue;

internal class Program
{
    static void Main(string[] args)
    {
        IDbContextTransaction? _dbContextTransaction;

        using (DatabaseContext context = new())
        {
            // Truncate any existing data - just to make sure we have a clean slate.
            context.Database.ExecuteSqlRaw("DELETE FROM [Employee]");
            context.Database.ExecuteSqlRaw("DELETE FROM [HomePage]");
            context.Database.ExecuteSqlRaw("DELETE FROM [Title]");

            _dbContextTransaction = context.Database.BeginTransaction();

            #region Homepages

            // Enable Identity Insert for seed data
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [HomePage] ON");

            IList<DbSetEntities.HomePage> homePages = GetHomePages();

            //Console.WriteLine($"Inserting {homePages.Count} homepages into database");

            foreach (DbSetEntities.HomePage homePage in homePages)
            {
                context.Add(homePage);
            }

            context.SaveChanges();

            homePages = context.HomePages.ToList();

            //Console.WriteLine($"Read {homePages.Count} homepages from database");

            // Disable Identity Insert for seed data
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [HomePage] OFF");

            #endregion

            Console.WriteLine();

            #region Titles

            // Enable Identity Insert for seed data
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [Title] ON");

            IList<DbSetEntities.Title> titles = GetTitles();

            //Console.WriteLine($"Inserting {titles.Count} titles into database");

            foreach (DbSetEntities.Title title in titles)
            {
                context.Add(title);
            }

            context.SaveChanges();

            titles = context.Titles.ToList();

            //Console.WriteLine($"Read {titles.Count} titles from database");

            // Disable Identity Insert for seed data
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [Title] OFF");

            #endregion

            //Console.WriteLine();

            #region Employees

            // Enable Identity Insert for seed data
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [Employee] ON");

            IList<DbSetEntities.Employee> employees = GetEmployees();

            //Console.WriteLine($"Inserting {employees.Count} employees into database");

            foreach (DbSetEntities.Employee employee in employees)
            {
                context.Add(employee);
            }

            context.SaveChanges();

            employees = context.Employees.ToList();

            //Console.WriteLine($"Read {employees.Count} employees from database");

            // Disable Identity Insert for seed data
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [Employee] OFF");

            #endregion

            _dbContextTransaction.Commit();

            //Console.WriteLine();
            //Console.WriteLine();

            //ChangeTracker changeTracker = context.ChangeTracker;

            //Console.WriteLine(changeTracker.DebugView.LongView);

            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine();

            foreach (string executedCommand in context.ExecutedCommands)
            {
                Console.WriteLine(executedCommand);
            }
        }
    }

    #region Build seed data

    private static IList<DbSetEntities.HomePage> GetHomePages()
    {
        return
        [
            new() { Id = 1, Code = "1", RedirectPage = 1, Name = "1", DisplayOrder = 1, IsActive = true, IsDefault = false, OrganisationAdminOnly = false },
            new() { Id = 2, Code = "2", RedirectPage = 2, Name = "2", DisplayOrder = 2, IsActive = true, IsDefault = true, OrganisationAdminOnly = false },
            new() { Id = 4, Code = "3", RedirectPage = 3, Name = "3", DisplayOrder = 4, IsActive = true, IsDefault = false, OrganisationAdminOnly = false }

            // Others removed for brevity
        ];
    }

    private static IList<DbSetEntities.Title> GetTitles()
    {
        return
        [
            new()
            {
                Id = 1,
                Code = "MR",
                Name = "Mr",
                DisplayOrder = 0,
                IsActive = true,
                IsDefault = true,
            },
            new()
            {
                Id = 2,
                Code = "MRS",
                Name = "Mrs",
                DisplayOrder = 1,
                IsActive = true,
            }

            // Others removed for brevity
        ];
    }

    private static IList<DbSetEntities.Employee> GetEmployees()
    {
        return
        [
            new()
            {
                Id = 1,
                FirstName = "Stewart",
                LastName = "Reynolds",
                TitleId = 1,
                DefaultHomePageId = 1
            },
            new()
            {
                Id = 2,
                TitleId = 1,
                FirstName = "Lawrence",
                LastName = "Pilkington",
                DefaultHomePageId = 1,
            },

            new()
            {
                Id = 3,
                TitleId = 2,
                FirstName = "Sally",
                LastName = "Taylor",
                DefaultHomePageId = 1,
            },

            new()
            {
                Id = 4,
                TitleId = 2,
                FirstName = "Rachel",
                LastName = "Wilkes",
                DefaultHomePageId = 1,
            }
        ];
    }

    #endregion
}