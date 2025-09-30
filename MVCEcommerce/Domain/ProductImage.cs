using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCEcommerce.Domain;

public class ProductImage : _EntityBase
{

    public Guid productId { get; set; }
    public byte[] Image { get; set; }
    public Product? Product { get; set; }

}
public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
{
    public void Configure(EntityTypeBuilder<ProductImage> builder)
    {
        //tpt
        builder.ToTable("ProductImages");

        builder.Property(p => p.Image)
            .IsRequired();

    }

}