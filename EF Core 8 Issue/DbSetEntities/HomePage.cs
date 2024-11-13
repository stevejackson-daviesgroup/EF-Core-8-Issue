using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Core_8_Issue.DbSetEntities;

[Table("HomePage")]
public class HomePage
{
    public int? Id { get; set; }

    public string? Name { get; set; }

    public string? Code { get; set; }

    public int DisplayOrder { get; set; }

    public bool IsActive { get; set; }

    public bool IsDefault { get; set; }

    // Normally an ENUM - but for brevity converted directly to an INT.
    public int RedirectPage { get; set; }

    public bool OrganisationAdminOnly { get; set; }
}