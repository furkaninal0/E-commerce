using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCEcommerce.Domain;

public class Address
{
    public Guid Id { get; set; }
    public Guid userId { get; set; }
    public string Name { get; set; }
    public string Text { get; set; }
    public string zipCode { get; set; }
    public int cityId { get; set; }
    public City? City { get; set; }
    public User? User { get; set; }


}
public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        //tpt
        builder.ToTable("Addresses");

        builder.Property(a => a.Name)
            .IsRequired();
                builder.Property(a => a.Text)
            .IsRequired();

    }
}
