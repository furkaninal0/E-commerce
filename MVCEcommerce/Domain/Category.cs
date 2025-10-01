﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCEcommerce.Domain;

public class Category : _EntityBase  
{
  
    public  string NameTr { get; set; }
    public  string NameEn { get; set; }   
    public byte[]? Image { get; set; }

    public ICollection<Product> Products { get; set; } = new List<Product>();
}
public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        //tpt
        builder.ToTable("Categories");

        builder.Property(p => p.NameTr)
            .IsRequired();
        builder.Property(p => p.NameEn )
            .IsRequired();
        builder.HasMany(p=>p.Products)
                .WithOne(p=>p.Category)
                .HasForeignKey(p=>p.categoryId)
                .OnDelete(DeleteBehavior.Restrict);


    }

}