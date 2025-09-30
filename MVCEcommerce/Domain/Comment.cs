using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
 namespace MVCEcommerce.Domain;



public class Comment
{
    public Guid Id { get; set; }
    public Guid productId { get; set; }
    public DateTime Date { get; set; }
    public Guid userId { get; set; }
    public int Scor { get; set; }
    public string Text { get; set; }
    public User? User { get; set; }
    public Product? Product { get; set; }


    }
public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        //tpt
        builder.ToTable("Comments");

        builder.Property(p => p.Text)
            .IsRequired();
        
    

    }

}
