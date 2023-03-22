using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Config
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(75);
            builder.HasIndex(c => c.Name).IsUnique(true).HasDatabaseName("UK_Categorie_Name");
            builder.Property(c => c.ImageUrl).HasColumnType("Text");
        }
    }
}
