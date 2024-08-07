using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ORM_PB303.Models;

namespace ORM_PB303.Configurations;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.Property(x => x.Fullname).IsRequired().HasMaxLength(100);

        builder.Property(x=>x.Fincode).IsRequired().HasMaxLength(7).IsFixedLength();
        builder.HasIndex(x => x.Fincode).IsUnique();
    }
}
