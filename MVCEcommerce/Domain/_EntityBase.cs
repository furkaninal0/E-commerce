using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCEcommerce.Domain;

public class _EntityBase  // tüm varlıkların ortak özellikleri
{

    public Guid Id { get; set; }
    public Guid userId { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsEnabled { get; set; }
    public User? User { get; set; }
}

public class _EntityBaseConfiguration : IEntityTypeConfiguration<_EntityBase>
{
    public void Configure(EntityTypeBuilder<_EntityBase> builder)
    {
        //tpt
        builder.ToTable("_EntityBase");

    }
}
