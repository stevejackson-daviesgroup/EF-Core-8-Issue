using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Core_8_Issue.DbSetEntities;

[Table("Employee")]
public class Employee
{
    public int? Id { get; set; }

    public int? TitleId { get; set; }

    public Title? Title { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int DefaultHomePageId { get; set; }

    public HomePage? DefaultHomePage { get; set; }
}