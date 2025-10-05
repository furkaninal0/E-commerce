using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCECommerceData;

public class Catalog : _EntityBase
{
    public string? NameTr { get; set; }
    public string? NameEn { get; set; }
    public ICollection<Product> Products { get; set; } = new List<Product>();
}

public class CatalogConfiguration : IEntityTypeConfiguration<Catalog>
{
    public void Configure(EntityTypeBuilder<Catalog> builder)
    {
        builder
            .ToTable("Catalogs");

        builder
            .HasIndex(p => new { p.NameTr });

        builder
            .HasIndex(p => new { p.NameEn });

        builder
            .Property(p => p.NameTr)
            .IsRequired();

        builder
            .Property(p => p.NameEn)
            .IsRequired();
    }
}