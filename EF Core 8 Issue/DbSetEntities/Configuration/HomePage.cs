using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EF_Core_8_Issue.DbSetEntities.Configuration;

public class HomePage : IEntityTypeConfiguration<DbSetEntities.HomePage>
{
    public void Configure(EntityTypeBuilder<DbSetEntities.HomePage> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).UseIdentityColumn();
        builder.Property(e => e.Name).IsRequired().HasMaxLength(150);
        builder.Property(e => e.Code).IsRequired().HasMaxLength(16);
        builder.Property(e => e.DisplayOrder).IsRequired();
        builder.Property(e => e.IsActive).IsRequired();
        builder.Property(e => e.IsDefault).IsRequired();
        builder.Property(e => e.RedirectPage).IsRequired();
        builder.Property(e => e.OrganisationAdminOnly).IsRequired();
    }
}