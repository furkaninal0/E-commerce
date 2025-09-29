namespace MVCEcommerce.Domain;

public class Specification
{
    public Guid Id { get; set; }
    public required string NameTr {  get; set; }
    public required string NameEn {  get; set; }
    public Guid CategoryId { get; set; }
    public Category? Category { get; set; }
}
