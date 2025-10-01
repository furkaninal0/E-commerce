using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Globalization;

namespace MVCEcommerce.Domain;

public class CarouselImage : _EntityBase // ana sayfa kaydırıcı resimleri
{
    public byte[] Image { get; set; }
    public String Url { get; set; }
    public Guid? CatalogId {  get; set; }

}

public class CarouselImageConfiguration : IEntityTypeConfiguration<CarouselImage>
{
    public void Configure(EntityTypeBuilder<CarouselImage> builder)
    {
        //tpt
        builder.ToTable("CarouselImages");

        builder.Property(p => p.Image)
            .IsRequired();
      
    }

}