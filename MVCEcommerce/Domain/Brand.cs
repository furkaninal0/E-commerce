using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCEcommerce.Domain;

public class Brand : _EntityBase   // marka
{
  
    public string? Name { get; set; }
    public byte[] logo { get; set; }
    
    public ICollection<Product> Products { get; set; } = new List<Product>();

}
public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        //tpt
        builder.ToTable("Brands");

        builder.Property(p => p.Name)
            .IsRequired();
        builder.HasMany(p=>p.Products)
                .WithOne(p=>p.Brand)
                .HasForeignKey(p=>p.brandId)
                .OnDelete(DeleteBehavior.Restrict);

    }

}