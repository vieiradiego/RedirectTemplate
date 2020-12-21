using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RedirectTemplate.Data.Map
{
    public class ProductEntityConfiguration : IEntityTypeConfiguration<ProductModel>
    {
        public void Configure(EntityTypeBuilder<ProductModel> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                .ValueGeneratedOnAdd();

            builder.Property(b => b.Company)
                .IsRequired();

            builder.Property(b => b.Serie)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(b => b.ComercialName)
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(b => b.Brand)
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(b => b.SapIdClient)
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(b => b.SapClientAlpha_2Code)
                .HasMaxLength(2)
                .IsRequired();

            builder.Property(b => b.DateTimeSync)
                .IsRequired();
        }
    }
}
