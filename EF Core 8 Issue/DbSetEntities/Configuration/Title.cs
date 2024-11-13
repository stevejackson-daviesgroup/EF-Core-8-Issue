using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Core_8_Issue.DbSetEntities.Configuration;

public class Title : IEntityTypeConfiguration<DbSetEntities.Title>
{
    public void Configure(EntityTypeBuilder<DbSetEntities.Title> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).UseIdentityColumn();
        builder.Property(e => e.Code).IsRequired().HasMaxLength(16);
        builder.Property(e => e.Name).IsRequired().HasMaxLength(150);
        builder.Property(e => e.DisplayOrder).IsRequired();
        builder.Property(e => e.IsActive).IsRequired();
        builder.Property(e => e.IsDefault).IsRequired();
    }
}