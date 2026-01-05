namespace Domain.Entities;

public class Products
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public int Quantity { get; set; }
    public int Category_id { get; set; }
    public int Seller_id { get; set; }
}