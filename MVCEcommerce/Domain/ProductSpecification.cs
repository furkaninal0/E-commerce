using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCEcommerce.Domain;

public class ProductSpecification  // ürünlerin hususi özelliklerin yer aldığı entity - ürünlerin spesifikasyonları
{
    public Guid productId { get; set; }
    public Guid specificitionId { get; set; }
    public string Value { get; set; }
        

}
public class ProductSpecificationonfiguration : IEntityTypeConfiguration<ProductSpecification>
{
    public void Configure(EntityTypeBuilder<ProductSpecification> builder)
    {
        builder.ToTable("ProductSpecifications");

        builder.HasKey(p => new { p.productId, p.specificitionId });

        builder.Property(p => p.Value)
            .IsRequired();

    }
}
