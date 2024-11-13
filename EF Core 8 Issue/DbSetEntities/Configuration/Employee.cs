using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Core_8_Issue.DbSetEntities.Configuration;

public class Employee : IEntityTypeConfiguration<DbSetEntities.Employee>
{
    public void Configure(EntityTypeBuilder<DbSetEntities.Employee> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).UseIdentityColumn();
        builder.Property(e => e.TitleId).IsRequired(false);
        builder.Property(e => e.FirstName).IsRequired(false).HasMaxLength(32);
        builder.Property(e => e.LastName).IsRequired(false).HasMaxLength(32);
        builder.Property(e => e.DefaultHomePageId).IsRequired();

        builder.HasOne(e => e.Title).WithOne();
        builder.HasOne(e => e.DefaultHomePage).WithOne();

        builder.Navigation(e => e.Title).AutoInclude();
        builder.Navigation(e => e.DefaultHomePage).AutoInclude();
    }
}