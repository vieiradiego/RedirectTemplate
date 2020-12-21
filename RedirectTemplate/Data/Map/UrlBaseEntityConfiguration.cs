using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RedirectTemplate.Data.Map
{
    public class UrlBaseEntityConfiguration : IEntityTypeConfiguration<UrlModel>
    {
        public void Configure(EntityTypeBuilder<UrlModel> builder)
        {
            builder.ToTable("URLs");
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                .ValueGeneratedOnAdd();

            builder.Property(b => b.Company)
                .IsRequired();

            builder.Property(b => b.Url)
                .HasMaxLength(4096)
                .IsRequired();
        }
    }
}
