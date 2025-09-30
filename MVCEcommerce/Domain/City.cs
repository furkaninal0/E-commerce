using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCEcommerce.Domain;

public class City
{
    public int Id { get; set; }
    public Guid provinceId { get; set; }
    public string Name { get; set; }
    public Province? Province { get; set; }

    public ICollection<Address> Addresses { get; set; } = new List<Address>();
}
public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        //tpt
        builder.ToTable("Cities");

        builder.HasIndex(p => new { p.provinceId, p.Name })
            .IsUnique();

        builder.Property(c => c.Name)
            .IsRequired();
            
        builder.HasMany(c => c.Addresses)
            .WithOne(a => a.City!)
            .HasForeignKey(a => a.cityId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
