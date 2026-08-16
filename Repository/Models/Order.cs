namespace Repository.Models;

public class Order
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Total => Quantity * Price;
    public decimal Price { get; set; }

    public Order Clone() => new Order { Id = Id, ProductId = ProductId, Quantity = Quantity, Price = Price };
}
