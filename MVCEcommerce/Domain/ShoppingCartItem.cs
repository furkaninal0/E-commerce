namespace MVCEcommerce.Domain;

public class ShoppingCartItem
{
    public Guid Id { get; set; }
    public Guid userId { get; set; }
    public Guid productId { get; set; }
    public int Quantity{ get; set; }

    public User? User { get; set; }
    public Product?  Product { get; set; }
}
