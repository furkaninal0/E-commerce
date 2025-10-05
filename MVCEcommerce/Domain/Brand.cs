using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCECommerceData;

public class Brand : _EntityBase
{
    [Display(Name = "Ad")]
    [Required(ErrorMessage = "{0} alanı boş bırakılamaz")]
    public string? Name { get; set; }

    [Display(Name = "Logo")]
    public byte[]? Logo { get; set; }

    [NotMapped]
    public IFormFile? LogoFile { get; set; }
    public ICollection<Product> Products { get; set; } = new List<Product>();
}
public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder
            .ToTable("Brands");

        builder
            .HasIndex(p => new { p.Name });

        builder
            .Property(p => p.Name)
            .IsRequired();

        builder
            .HasMany(p => p.Products)
            .WithOne(p => p.Brand)
            .HasForeignKey(p => p.BrandId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}