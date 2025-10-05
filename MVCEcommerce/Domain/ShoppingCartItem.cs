﻿
namespace MVCECommerceData;

public class ShoppingCartItem
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }

    public User? User { get; set; }
    public Product? Product { get; set; }


}