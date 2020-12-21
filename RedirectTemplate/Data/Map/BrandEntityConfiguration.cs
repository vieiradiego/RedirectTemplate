using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RedirectTemplate.Data.Map
{
    public class BrandEntityConfiguration : IEntityTypeConfiguration<BrandModel>
    {
        public void Configure(EntityTypeBuilder<BrandModel> builder)
        {
            builder.ToTable("Brands");
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                .ValueGeneratedOnAdd();

            builder.Property(b => b.Code)
                .HasMaxLength(8)
                .IsRequired();

            builder.Property(b => b.Description)
                .HasMaxLength(128)
                .IsRequired();
        }
    }
}
