using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCEcommerce.Domain;

public class Catalog : _EntityBase
{
   
    public string? NameTr { get; set; }
    public string? NameEn { get; set; }

    public ICollection <Product> Products { get; set; } = new List<Product>();
}

public class CatalogConfiguration : IEntityTypeConfiguration<Catalog>
{
    public void Configure(EntityTypeBuilder<Catalog> builder)
    {
        //tpt
        builder.ToTable("Catalogs");

        builder.Property(p => p.NameTr)
            .IsRequired();
        builder.Property(p => p.NameEn)
          .IsRequired();

    }

}