using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCECommerceData;

public class CarouselImage : _EntityBase
{
    public byte[] Image { get; set; }
    public string? Url { get; set; }
    public Guid? CatalogId { get; set; }
}

public class CarouselImageConfiguration : IEntityTypeConfiguration<CarouselImage>
{
    public void Configure(EntityTypeBuilder<CarouselImage> builder)
    {
        builder
            .ToTable("CarouselImages");

        builder
            .Property(p => p.Image)
            .IsRequired();


    }
}