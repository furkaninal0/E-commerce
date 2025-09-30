using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCEcommerce.Domain;

public enum Genders
{
    Male, Female
}

public class User : IdentityUser <Guid>
{
    public required string GivenName { get; set; }
    public required DateTime Date { get; set; }
    public required Genders Gender { get; set; }

    public ICollection<Address> Addresses { get; set; } = new List<Address>();
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    public ICollection<Order> Orders { get; set; } = new List<Order>();
    public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; } = new List<ShoppingCartItem>();

}

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasMany(p=>p.Addresses)
            .WithOne(p=>p.User)
            .HasForeignKey(p=>p.userId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(p => p.Comments)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.userId)
                .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(p => p.Orders)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.userId)
                .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasMany(p => p.ShoppingCartItems)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.userId)
                .OnDelete(DeleteBehavior.Cascade);
    }

}