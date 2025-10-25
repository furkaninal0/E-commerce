using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCECommerceData;

namespace MVCEcommerce.Domain;

public class CreditCard
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ICollection<Installment> Installments{ get; set; } = new List<Installment>();      
}
public class CreditCardConfiguration : IEntityTypeConfiguration<CreditCard>
{
    public void Configure(EntityTypeBuilder<CreditCard> builder)
    {
        builder
            .ToTable("CreditCards");


        builder
            .Property(p => p.Name)
            .IsRequired();

        builder
            .HasMany(p => p.Installments)
            .WithOne(p => p.CreditCard)
            .HasForeignKey(p => p.CreditCardId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasData(
            new CreditCard { Id =  Guid.Parse("{FCE20EA5-7ACE-4965-9024-3792BEDCA3F1}"), Name="axess" },
            new CreditCard { Id =  Guid.Parse("{FCE20EA5-7ACE-4965-9024-3792BEDCA3F2}"), Name="world" },
            new CreditCard { Id =  Guid.Parse("{FCE20EA5-7ACE-4965-9024-3792BEDCA3F3}"), Name="bonus" },
            new CreditCard { Id =  Guid.Parse("{FCE20EA5-7ACE-4965-9024-3792BEDCA3F4}"), Name="maximum" },
            new CreditCard { Id =  Guid.Parse("{FCE20EA5-7ACE-4965-9024-3792BEDCA3F5}"), Name="advantage" },
            new CreditCard { Id =  Guid.Parse("{FCE20EA5-7ACE-4965-9024-3792BEDCA3F6}"), Name= "bankkart" }
            );
    }
}


public class Installment
{
    public Guid Id { get; set; }
    public Guid CreditCardId { get; set; }
    public int Count { get; set; }
    public decimal Rate { get; set; } //oran
    public CreditCard? CreditCard{ get; set; }
}
public class InstallmentConfiguration : IEntityTypeConfiguration<Installment>
{
    public void Configure(EntityTypeBuilder<Installment> builder)
    {
        builder
            .ToTable("Installments");
        builder
            .HasData(
            new Installment { Id = Guid.Parse("{AB107747-F610-4752-8A97-2EBCAC3C3ED0}"), CreditCardId = Guid.Parse("{FCE20EA5-7ACE-4965-9024-3792BEDCA3F1}"), Count = 2 , Rate = 1 },
            new Installment { Id = Guid.Parse("{AB107747-F610-4752-8A97-2EBCAC3C3ED1}"), CreditCardId = Guid.Parse("{FCE20EA5-7ACE-4965-9024-3792BEDCA3F1}"), Count = 3 , Rate = 1 },
            new Installment { Id = Guid.Parse("{AB107747-F610-4752-8A97-2EBCAC3C3EB3}"), CreditCardId = Guid.Parse("{FCE20EA5-7ACE-4965-9024-3792BEDCA3F1}"), Count = 4 , Rate = 1 },
            new Installment { Id = Guid.Parse("{AB107747-F610-4752-8A97-2EBCAC3C3ED4}"), CreditCardId = Guid.Parse("{FCE20EA5-7ACE-4965-9024-3792BEDCA3F1}"), Count = 6 , Rate = 1 },
            new Installment { Id = Guid.Parse("{AB107747-F610-4752-8A97-2EBCAC3C3ED5}"), CreditCardId = Guid.Parse("{FCE20EA5-7ACE-4965-9024-3792BEDCA3F1}"), Count = 8 , Rate = 1.10m },
            new Installment { Id = Guid.Parse("{AB107747-F610-4752-8A97-2EBCAC3C3ED6}"), CreditCardId = Guid.Parse("{FCE20EA5-7ACE-4965-9024-3792BEDCA3F1}"), Count = 9 , Rate = 1.20m },
            new Installment { Id = Guid.Parse("{AB107747-F610-4752-8A97-2EBCAC3C3ED7}"), CreditCardId = Guid.Parse("{FCE20EA5-7ACE-4965-9024-3792BEDCA3F1}"), Count = 12 , Rate = 1.30m },


            new Installment { Id = Guid.Parse("{AB107747-F610-4752-8A97-2EBCAC3C3E08}"), CreditCardId = Guid.Parse("{FCE20EA5-7ACE-4965-9024-3792BEDCA3F2}"), Count = 2, Rate = 1 },
            new Installment { Id = Guid.Parse("{AB107747-F610-4752-8A97-2EBCAC3C3ED9}"), CreditCardId = Guid.Parse("{FCE20EA5-7ACE-4965-9024-3792BEDCA3F2}"), Count = 3, Rate = 1 },
            new Installment { Id = Guid.Parse("{AB107747-F610-4752-8A97-2EBCAC3C3E10}"), CreditCardId = Guid.Parse("{FCE20EA5-7ACE-4965-9024-3792BEDCA3F2}"), Count = 6, Rate = 1 },
            new Installment { Id = Guid.Parse("{AB107747-F610-4752-8A97-2EBCAC3C3E11}"), CreditCardId = Guid.Parse("{FCE20EA5-7ACE-4965-9024-3792BEDCA3F2}"), Count = 8, Rate = 1.15m },
            new Installment { Id = Guid.Parse("{AB107747-F610-4752-8A97-2EBCAC3C3E12}"), CreditCardId = Guid.Parse("{FCE20EA5-7ACE-4965-9024-3792BEDCA3F2}"), Count = 9, Rate = 1.22m },
            new Installment { Id = Guid.Parse("{AB107747-F610-4752-8A97-2EBCAC3C3E13}"), CreditCardId = Guid.Parse("{FCE20EA5-7ACE-4965-9024-3792BEDCA3F2}"), Count = 12, Rate = 1.28m }


            );
    }   
}