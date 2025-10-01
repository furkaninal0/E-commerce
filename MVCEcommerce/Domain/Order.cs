using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCEcommerce.Domain;

public class Order    //sipariş tablosu - kullanıcının verdiği siparişler
{

    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public Guid userId  { get; set; }
    public Guid ShippingAddressId{ get; set; }
    public User? User { get; set; }
    public ICollection <OrderItem > Items { get; set; } = new List<OrderItem> (); 

    }
public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        //tpt
        builder.ToTable("Orders");
        
        builder.HasMany(o => o.Items)
               .WithOne(oi => oi.Order)
               .HasForeignKey(oi => oi.orderId)
               .OnDelete(DeleteBehavior.Cascade );

    }

}