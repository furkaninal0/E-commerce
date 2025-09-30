namespace MVCEcommerce.Domain;

public class Specification : _EntityBase
{
    public  string NameTr {  get; set; }
    public  string NameEn {  get; set; }
    public Guid CategoryId { get; set; }
    public Category? Category { get; set; }
}
