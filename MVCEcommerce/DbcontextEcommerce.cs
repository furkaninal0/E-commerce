using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCECommerceData;

namespace MVCEcommerce
{
    public class DbcontextEcommerce (DbContextOptions options): IdentityDbContext<
        User, 
        Role, 
        Guid,
        IdentityUserClaim<Guid>,
        UserRole,
        IdentityUserLogin<Guid>,    
        IdentityRoleClaim<Guid>,
        IdentityUserToken<Guid>>(options)

    {
        override protected void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                if (typeof(_EntityBase).IsAssignableFrom(entityType.ClrType))
                {
                    builder.Entity(entityType.ClrType).Ignore("_userId");
                    builder.Entity(entityType.ClrType).Ignore("_user");
                }
            }
            builder.ApplyConfigurationsFromAssembly(typeof(DbcontextEcommerce).Assembly);
        }


        public required DbSet<Address> Addresses { get; set; }
        public required DbSet<Brand> Brands { get; set; }
        public required DbSet<Catalog> Catalogs { get; set; }
        public required DbSet<Category> Categories{ get; set; }
        public required DbSet<CarouselImage> CarouselImages{ get; set; }
        public required DbSet<City> Cities{ get; set; }
        public required DbSet<Comment> Comments{ get; set; }
        public required DbSet<Order> Orders{ get; set; }
        public required DbSet<OrderItem> OrderItems{ get; set; }
        public required DbSet<Product> Products{ get; set; }
        public required DbSet<Province> Provinces{ get; set; }
        public required DbSet<ProductImage> ProductImages{ get; set; }
        public required DbSet<ProductSpecification> ProductSpecifications{ get; set; }
        public required DbSet<ShoppingCartItem> ShoppingCartItems{ get; set; }
        public required DbSet<Specification> Specifications { get; set; }
    



    }
}
