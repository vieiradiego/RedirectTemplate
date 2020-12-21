using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RedirectTemplate.Data.Map
{
    public class CountryEntityConfiguration : IEntityTypeConfiguration<CountryModel>
    {
        public void Configure(EntityTypeBuilder<CountryModel> builder)
        {
            builder.ToTable("Contries");
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                .ValueGeneratedOnAdd();

            builder.Property(b => b.Name)
                .IsRequired();
            
            builder.Property(b => b.Alpha_2Code)
                .HasMaxLength(2)
                .IsRequired();
            
            builder.Property(b => b.Alpha_3Code)
                .HasMaxLength(3)
                .IsRequired();
            
            builder.Property(b => b.NumericCode)
                .IsRequired();
            
            builder.Property(b => b.Latitude)
                .IsRequired();
            
            builder.Property(b => b.Longitude)
                .IsRequired();
        }
    }
}
