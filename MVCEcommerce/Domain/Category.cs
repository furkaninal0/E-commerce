namespace MVCEcommerce.Domain;

public class Category
{
    public Guid Id { get; set; }
    public required string NameTr { get; set; }
    public required string NameEn { get; set; }   
    public byte[]? Image { get; set; }
}
