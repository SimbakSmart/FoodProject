using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(75);
            builder.Property(p => p.Detail).IsRequired().HasMaxLength(150);
            builder.Property(p => p.ImageUrl).HasColumnType("Text");
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)").IsRequired();
            builder.HasOne(c => c.Category).WithMany()
            .HasForeignKey(c => c.CategoryId).HasConstraintName("FK_Product_Categoeries_Id").OnDelete(DeleteBehavior.NoAction);

            //builder.HasMany(d=>d.OrderDetails).WithOne().OnDelete(DeleteBehavior.NoAction);
        }
    }
}
