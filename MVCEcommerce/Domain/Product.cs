﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCEcommerce.Domain;

public class Product : _EntityBase
{
    public Guid categoryId { get; set; }
    public Guid? brandId { get; set; }
    public string NameTr { get; set; }
    public string NameEn { get; set; }
    public string? DescriptionTr { get; set; }
    public string? DescriptionEn { get; set; }
    public decimal Price { get; set; }

    public byte[]? Image { get; set; }
    public int Views { get; set; }
    public Brand? Brand { get; set; }
    public Category? Category { get; set; }

    public ICollection <Catalog> Catalogs { get; set; } = new List<Catalog>();

    public ICollection <Comment> Comments { get; set; } = new List<Comment>();
    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    public ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
    public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; } = new List<ShoppingCartItem>();
    }

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        //tpt
        builder.ToTable("Products");

        builder.Property(p => p.NameTr)
            .IsRequired();
        builder.Property(p => p.NameEn)
           .IsRequired();
        
        builder.HasMany(p=>p.Comments)
            .WithOne(p=>p.Product)
            .HasForeignKey(p=>p.productId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasMany(p => p.OrderItems)
            .WithOne(p => p.Product)
            .HasForeignKey(p => p.productId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasMany(p=>p.ProductImages)
            .WithOne(p=>p.Product)
            .HasForeignKey(p=>p.productId)
            .OnDelete(DeleteBehavior.Cascade);
      
        builder.HasMany(p => p.ShoppingCartItems)
          .WithOne(p => p.Product)
          .HasForeignKey(p => p.productId)
          .OnDelete(DeleteBehavior.Restrict);

    }

}