using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCEcommerce.Domain;

public class OrderItem
{
    public Guid Id { get; set; }
    public Guid productId { get; set; }
    public Guid orderId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public Order? Order { get; set; }
    public Product? Product { get; set; }




}
public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        //tpt
        builder.ToTable("OrderItems");

        builder.Property(p => p.Price)
            .HasPrecision(18, 4);

    }

}