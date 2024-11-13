using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Core_8_Issue.DbSetEntities;

[Table("Title")]
public class Title
{
    public int? Id { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public int DisplayOrder { get; set; }

    public bool IsActive { get; set; }

    public bool IsDefault { get; set; }
}