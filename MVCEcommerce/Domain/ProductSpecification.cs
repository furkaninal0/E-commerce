using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCECommerceData;

public class ProductSpecification
{
    public Guid ProductId { get; set; }
    public Guid SpecificationId { get; set; }
    public string? Value { get; set; }

    public Product? Product { get; set; }
    public Specification? Specification { get; set; }
}

public class ProductSpecificationConfiguration : IEntityTypeConfiguration<ProductSpecification>
{
    public void Configure(EntityTypeBuilder<ProductSpecification> builder)
    {
        builder
            .ToTable("ProductSpecifications");

        builder
            .HasKey(p => new { p.ProductId, p.SpecificationId });

        builder
            .Property(p => p.Value)
            .IsRequired();
    }
}